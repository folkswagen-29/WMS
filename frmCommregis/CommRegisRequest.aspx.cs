using DocumentFormat.OpenXml.ExtendedProperties;
using iTextSharp.text.pdf;
using Newtonsoft.Json.Linq;
using onlineLegalWF.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static onlineLegalWF.Class.ReplaceCommRegis;

namespace onlineLegalWF.frmCommregis
{
    public partial class CommRegisRequest : System.Web.UI.Page
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
                setData();
            }
        }

        private void setData()
        {
            ucHeader1.setHeader("Commercial Registration Request");
            string xreq_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            req_no.Text = xreq_no;

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

            cb_subsidiary_multi.DataSource = GetSubsidiary();
            cb_subsidiary_multi.DataBind();
            cb_subsidiary_multi.DataTextField = "subsidiary_name_th";
            cb_subsidiary_multi.DataValueField = "subsidiary_code";
            cb_subsidiary_multi.DataBind();

            string pid = zwf.iniPID("LEGALWF");
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucCommentlog1.ini_object(pid);

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

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int ret = 0;
            string xtype_comm_regis = type_comm_regis.SelectedValue;

            //check is cbmore loop subsidiary_code
            var xiscb_more = cb_more.Checked;
            List<string> selected = new List<string>();
            foreach (ListItem item in cb_subsidiary_multi.Items) 
            {
                if (item.Selected) 
                {
                    selected.Add(item.Value);
                } 
            }
                

            if (doc_no.Text.Trim() == "")
            {
                doc_no.Text = zwf.genDocNo("CCR-" + System.DateTime.Now.ToString("yyyy", new CultureInfo("en-US")) + "-", 4);
            }

            var xdoc_no = doc_no.Text.Trim();
            var xreq_no = req_no.Text.Trim();
            var xprocess_id = hid_PID.Value.ToString();
            var xreq_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xmt_res_desc = mt_res_desc.Text.Trim();
            var xmt_res_no = mt_res_no.Text.Trim();
            var xmt_res_date = mt_res_date.Text.Trim();
            var xstatus = "verify";

            string sql = "";

            if (xtype_comm_regis == "02") 
            {
                var xcompany_name_th = company_name_th.Text.Trim();
                var xcompany_name_en = company_name_en.Text.Trim();
                var xddl_subsidiary = ddl_subsidiary.SelectedValue;

                sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[subsidiary_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[company_name_th],[company_name_en],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'" + xtype_comm_regis + @"'
                               ,'" + xddl_subsidiary + @"'
                               ,'" + xdoc_no + @"'
                               ,'" + xmt_res_desc + @"'
                               ,'" + xmt_res_no + @"'
                               ,'" + xmt_res_date + @"'
                               ,'" + xcompany_name_th + @"'
                               ,'" + xcompany_name_en + @"'
                               ,'" + xstatus + @"')";

                ret = zdb.ExecNonQueryReturnID(sql, zconnstr);

                //if (ret > 0) 
                //{
                //    string sqlupdate = @"UPDATE [dbo].[li_comm_regis_subsidiary]
                //                           SET [subsidiary_name_th] = '"+ xcompany_name_th + @"'
                //                              ,[subsidiary_name_en] = '"+ xcompany_name_en + @"'
                //                         WHERE subsidiary_code = '"+ xddl_subsidiary +"'";

                //    zdb.ExecNonQuery(sqlupdate, zconnstr);
                //}
            }
            else 
            {
                if (xtype_comm_regis == "01")
                {
                    var xisrdregister = sec1_cb_rd.Checked;
                    var xcompany_name_th = company_name_th.Text.Trim();
                    var xcompany_name_en = company_name_en.Text.Trim();
                    sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[company_name_th],[company_name_en],[isrdregister],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'" + xtype_comm_regis + @"'
                               ,'" + xdoc_no + @"'
                               ,'" + xmt_res_desc + @"'
                               ,'" + xmt_res_no + @"'
                               ,'" + xmt_res_date + @"'
                               ,'" + xcompany_name_th + @"'
                               ,'" + xcompany_name_en + @"'
                               ,'" + xisrdregister + @"'
                               ,'" + xstatus + @"')";

                    ret = zdb.ExecNonQueryReturnID(sql, zconnstr);
                }
                else 
                {
                    var xddl_subsidiary = ddl_subsidiary.SelectedValue;
                    var xisrdregister = false;

                    if (xtype_comm_regis == "06") 
                    {
                        xisrdregister = sec6_cb_rd.Checked;
                    }

                    if (xtype_comm_regis == "08")
                    {
                        xisrdregister = sec8_cb_rd.Checked;
                    }

                    sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[subsidiary_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[company_name_th],[company_name_en],[isrdregister],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'" + xtype_comm_regis + @"'
                               ,'" + xddl_subsidiary + @"'
                               ,'" + xdoc_no + @"'
                               ,'" + xmt_res_desc + @"'
                               ,'" + xmt_res_no + @"'
                               ,'" + xmt_res_date + @"'
                               ,'" + xisrdregister + @"'
                               ,'" + xstatus + @"')";

                    ret = zdb.ExecNonQueryReturnID(sql, zconnstr);
                }
            }

            if (ret > 0)
            {
                Response.Write("<script>alert('Successfully Insert');</script>");
                var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
                Response.Redirect(host_url + "frmCommregis/CommRegisRequestEdit.aspx?id=" + req_no.Text.Trim());
            }
            else 
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
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
            var xreq_date = System.DateTime.Now;
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
                string sql_commsub = "SELECT * FROM [BPM].[dbo].[li_comm_regis_subsidiary] where subsidiary_code = '"+ xddl_subsidiary + "'";
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