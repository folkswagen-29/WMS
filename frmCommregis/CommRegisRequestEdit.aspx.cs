using DocumentFormat.OpenXml.ExtendedProperties;
using iTextSharp.text.pdf;
using onlineLegalWF.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static onlineLegalWF.Class.ReplaceCommRegis;

namespace onlineLegalWF.frmCommregis
{
    public partial class CommRegisRequestEdit : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public WFFunctions zwf = new WFFunctions();
        public ReplaceCommRegis zreplacecommregis = new ReplaceCommRegis();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setDataDDL();

                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    setDataEditRequest(id);
                }

            }
        }

        private void setDataDDL()
        {
            ucHeader1.setHeader("Edit Request");

            type_comm_regis.DataSource = GetTypeOfRequest();
            type_comm_regis.DataBind();
            type_comm_regis.DataTextField = "toc_regis_desc";
            type_comm_regis.DataValueField = "toc_regis_code";
            type_comm_regis.DataBind();

            ddl_subsidiary.DataSource = GetSubsidiary();
            ddl_subsidiary.DataBind();
            ddl_subsidiary.DataTextField = "subsidiary_name_th";
            ddl_subsidiary.DataValueField = "subsidiary_code";
            ddl_subsidiary.DataBind();
        }

        public DataTable GetTypeOfRequest()
        {
            string sql = "select * from li_type_of_comm_regis order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        public DataTable GetSubsidiary()
        {
            string sql = "select * from li_comm_regis_subsidiary order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        private void setDataEditRequest(string id)
        {
            string sql = "select * from li_comm_regis_request where req_no='" + id + "'";

            var res = zdb.ExecSql_DataTable(sql, zconnstr);

            if (res.Rows.Count > 0)
            {
                req_no.Text = res.Rows[0]["req_no"].ToString();
                req_date.Value = Convert.ToDateTime(res.Rows[0]["req_date"]).ToString("yyyy-MM-dd");
                type_comm_regis.SelectedValue = res.Rows[0]["toc_regis_code"].ToString();
                if (!string.IsNullOrEmpty(res.Rows[0]["subsidiary_code"].ToString())) 
                {
                    ddl_subsidiary.SelectedValue = res.Rows[0]["subsidiary_code"].ToString();
                }
                doc_no.Text = res.Rows[0]["document_no"].ToString();
                mt_res_no.Text = res.Rows[0]["mt_res_no"].ToString();
                mt_res_desc.Text = res.Rows[0]["mt_res_desc"].ToString();
                mt_res_date.Text = Convert.ToDateTime(res.Rows[0]["mt_res_date"]).ToString("yyyy-MM-dd");
                company_name_th.Text = res.Rows[0]["company_name_th"].ToString();
                company_name_en.Text = res.Rows[0]["company_name_en"].ToString();
                lblPID.Text = res.Rows[0]["process_id"].ToString();
                hid_PID.Value = res.Rows[0]["process_id"].ToString();
                ucAttachment1.ini_object(res.Rows[0]["process_id"].ToString());
                ucCommentlog1.ini_object(res.Rows[0]["process_id"].ToString());

                string js = "$('#section1').hide();";
                if (type_comm_regis.SelectedValue == "01") 
                {
                    if (Convert.ToBoolean(res.Rows[0]["isrdregister"].ToString())) 
                    {
                        sec1_cb_rd.Checked = true;
                    }
                    js += "$('#section1').show();$('.subsidiary').hide();$('.company').show();";
                }
                else if (type_comm_regis.SelectedValue == "02")
                {
                    js += "$('#section2').show();$('.subsidiary').show();$('.company').show();";
                }
                else if (type_comm_regis.SelectedValue == "03")
                {
                    js += "$('#section3').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "04")
                {
                    js += "$('#section4').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "05")
                {
                    js += "$('#section5').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "06")
                {
                    if (Convert.ToBoolean(res.Rows[0]["isrdregister"].ToString()))
                    {
                        sec6_cb_rd.Checked = true;
                    }
                    js += "$('#section6').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "07")
                {
                    js += "$('#section7').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "08")
                {
                    if (Convert.ToBoolean(res.Rows[0]["isrdregister"].ToString()))
                    {
                        sec8_cb_rd.Checked = true;
                    }
                    js += "$('#section8').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "09")
                {
                    js += "$('#section9').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "10")
                {
                    js += "$('#section10').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "11")
                {
                    js += "$('#section11').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "12")
                {
                    js += "$('#section12').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "13")
                {
                    js += "$('#section13').show();$('.subsidiary').show();$('.company').hide();";
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "changeType", js, true);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

        }

        private int UpdateRequest()
        {
            int ret = 0;

            string xtype_comm_regis = type_comm_regis.SelectedValue;
            var xreq_no = req_no.Text.Trim();
            var xupdate_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xmt_res_desc = mt_res_desc.Text.Trim();
            var xmt_res_no = mt_res_no.Text.Trim();
            var xmt_res_date = mt_res_date.Text.Trim();
            var xddl_subsidiary = ddl_subsidiary.SelectedValue;

            string sql = "";

            if (xtype_comm_regis == "02")
            {
                var xcompany_name_th = company_name_th.Text.Trim();
                var xcompany_name_en = company_name_en.Text.Trim();

                sql = @"UPDATE [dbo].[li_comm_regis_request]
                           SET [mt_res_desc] = '"+ xmt_res_desc +@"'
                              ,[mt_res_no] = '" +xmt_res_no+ @"'
                              ,[mt_res_date] = '"+ xmt_res_date + @"'
                              ,[toc_regis_code] = '" + xtype_comm_regis + @"'
                              ,[subsidiary_code] = '" + xddl_subsidiary + @"'
                              ,[company_name_th] = '"+ xcompany_name_th +@"'
                              ,[company_name_en] = '"+ xcompany_name_en +@"'
                              ,[updated_datetime] = '" + xupdate_date + @"'
                         WHERE [req_no] = '"+ xreq_no + "'";

                ret = zdb.ExecNonQueryReturnID(sql, zconnstr);
            }
            else
            {
                if (xtype_comm_regis == "01")
                {
                    var xisrdregister = sec1_cb_rd.Checked;
                    var xcompany_name_th = company_name_th.Text.Trim();
                    var xcompany_name_en = company_name_en.Text.Trim();
                    sql = @"UPDATE [dbo].[li_comm_regis_request]
                           SET [mt_res_desc] = '" + xmt_res_desc + @"'
                              ,[mt_res_no] = '" + xmt_res_no + @"'
                              ,[mt_res_date] = '" + xmt_res_date + @"'
                              ,[toc_regis_code] = '" + xtype_comm_regis + @"'
                              ,[company_name_th] = '"+ xcompany_name_th +@"'
                              ,[company_name_en] = '"+ xcompany_name_en +@"'
                              ,[isrdregister] = '" + xisrdregister + @"'
                              ,[updated_datetime] = '" + xupdate_date + @"'
                         WHERE [req_no] = '" + xreq_no + "'";

                    ret = zdb.ExecNonQueryReturnID(sql, zconnstr);
                }
                else
                {
                    var xisrdregister = false;

                    if (xtype_comm_regis == "06")
                    {
                        xisrdregister = sec6_cb_rd.Checked;
                    }

                    if (xtype_comm_regis == "08")
                    {
                        xisrdregister = sec8_cb_rd.Checked;
                    }

                    sql = @"UPDATE [dbo].[li_comm_regis_request]
                           SET [mt_res_desc] = '" + xmt_res_desc + @"'
                              ,[mt_res_no] = '" + xmt_res_no + @"'
                              ,[mt_res_date] = '" + xmt_res_date + @"'
                              ,[toc_regis_code] = '" + xtype_comm_regis + @"'
                              ,[subsidiary_code] = '" + xddl_subsidiary + @"'
                              ,[isrdregister] = '" + xisrdregister + @"'
                              ,[updated_datetime] = '" + xupdate_date + @"'
                         WHERE [req_no] = '" + xreq_no + "'";

                    ret = zdb.ExecNonQueryReturnID(sql, zconnstr);
                }
            }


            return ret;
        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {
            GenDocumnet();
        }

        private void GenDocumnet()
        {
            // Replace Doc
            var xtype_comm_regis = type_comm_regis.SelectedValue;
            var xtype_comm_regis_text = type_comm_regis.SelectedItem.Text;
            var xdoc_no = doc_no.Text.Trim();
            var xprocess_id = hid_PID.Value.ToString();
            var xreq_date = Utillity.ConvertStringToDate(req_date.Value);
            var xmt_res_desc = mt_res_desc.Text.Trim();
            var xmt_res_no = mt_res_no.Text.Trim();
            var xmt_res_date = mt_res_date.Text.Trim();
            var xcompany_name_th = "";
            var xcompany_name_en = "";
            var xddl_subsidiary = ddl_subsidiary.SelectedValue;

            if (xtype_comm_regis == "01" || xtype_comm_regis == "02")
            {
                xcompany_name_th = company_name_th.Text.Trim();
                xcompany_name_en = company_name_en.Text.Trim();
            }
            else
            {
                string sql_commsub = "SELECT * FROM [BPM].[dbo].[li_comm_regis_subsidiary] where subsidiary_code = '" + xddl_subsidiary + "'";
                var rescommsub = zdb.ExecSql_DataTable(sql_commsub, zconnstr);

                if (rescommsub.Rows.Count > 0)
                {
                    xcompany_name_th = rescommsub.Rows[0]["subsidiary_name_th"].ToString();
                    xcompany_name_en = rescommsub.Rows[0]["subsidiary_name_en"].ToString();
                }
            }

            var path_template = ConfigurationManager.AppSettings["WT_Template_commregistration"].ToString();
            string templatefile = "";
            if (xtype_comm_regis == "12" || xtype_comm_regis == "13" || xtype_comm_regis == "14")
            {
                templatefile = path_template + @"\InsuranceComregis2.docx";
            }
            else
            {
                templatefile = path_template + @"\InsuranceComregis.docx";
            }
            string outputfolder = path_template + @"\Output";
            string outputfn = outputfolder + @"\commregis_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

            var rdoc = new ReplaceDocx.Class.ReplaceDocx();

            #region gentagstr data form
            ReplaceCommRegis_TagData data = new ReplaceCommRegis_TagData();

            data.docno = xdoc_no.Replace(",", "!comma");
            data.subject = xtype_comm_regis_text.Replace(",", "!comma");
            data.companyname_th = xcompany_name_th.Replace(",", "!comma");
            data.companyname_en = xcompany_name_en.Replace(",", "!comma");
            data.reqdate = Utillity.ConvertDateToLongDateTime(xreq_date, "th");
            data.mt_res_desc = xmt_res_desc.Replace(",", "!comma");
            data.mt_res_no = xmt_res_no.Replace(",", "!comma");
            data.mt_res_date = Utillity.ConvertDateToLongDateTime(Utillity.ConvertStringToDate(xmt_res_date), "th").Replace(",", "!comma");

            var requestor = "";
            var requestorpos = "";
            var supervisor = "";
            var supervisorpos = "";

            // check session_user
            if (Session["user_login"] != null)
            {
                var xlogin_name = Session["user_login"].ToString();
                var empFunc = new EmpInfo();

                //get data user
                var emp = empFunc.getEmpInfo(xlogin_name);
                if (!string.IsNullOrEmpty(emp.full_name_en))
                {
                    requestor = emp.full_name_en;
                    requestorpos = emp.position_en;
                }

                //get supervisor data
                var empSupervisor = empFunc.getEmpInfo(emp.next_line_mgr_login);
                if (!string.IsNullOrEmpty(empSupervisor.full_name_en))
                {
                    supervisor = empSupervisor.full_name_en;
                    supervisorpos = empSupervisor.position_en;
                }

            }

            data.sign_name1 = "";
            data.name1 = requestor;
            data.position1 = requestorpos;
            data.date1 = "";

            data.sign_name2 = "";
            data.name2 = supervisor;
            data.position2 = supervisorpos;
            data.date2 = "";


            DataTable dtStr = zreplacecommregis.genTagData(data);
            #endregion


            // Convert to JSONString
            //DataTable dtTagPropsTable = new DataTable();
            //dtTagPropsTable.Columns.Add("tagname", typeof(string));
            //dtTagPropsTable.Columns.Add("jsonstring", typeof(string));

            //DataTable dtTagDataTable = new DataTable();
            //dtTagDataTable.Columns.Add("tagname", typeof(string));
            //dtTagDataTable.Columns.Add("jsonstring", typeof(string));
            ReplaceDocx.Class.ReplaceDocx repl = new ReplaceDocx.Class.ReplaceDocx();
            var jsonDTStr = repl.DataTableToJSONWithStringBuilder(dtStr);
            //var jsonDTProperties1 = repl.DataTableToJSONWithStringBuilder(dtProperties1);
            //var jsonDTdata = repl.DataTableToJSONWithStringBuilder(dt);
            var jsonDTProperties1 = "";
            var jsonDTdata = "";
            //end prepare data

            // Save to Database z_replacedocx_log
            string xreq_no = req_no.Text.Trim();
            string sql = @"insert into z_replacedocx_log (replacedocx_reqno,jsonTagString, jsonTableProp, jsonTableData,template_filepath , output_directory,output_filepath, delete_output ) 
                        values('" + xreq_no + @"',
                               '" + jsonDTStr + @"', 
                                '" + jsonDTProperties1 + @"', 
                                '" + jsonDTdata + @"', 
                                '" + templatefile + @"', 
                                '" + outputfolder + @"', 
                                '" + outputfn + @"',  
                                '" + "0" + @"'
                            ) ";

            zdb.ExecNonQuery(sql, zconnstr);

            var outputbyte = rdoc.ReplaceData2(jsonDTStr, jsonDTProperties1, jsonDTdata, templatefile, outputfolder, outputfn, false);

            repl.convertDOCtoPDF(outputfn, outputfn.Replace(".docx", ".pdf"), false);

            string filePath = outputfn.Replace(".docx", ".pdf");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalDoc();", true);
            var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
            pdf_render.Attributes["src"] = host_url + "render/pdf?id=" + filePath;
        }
    }
}