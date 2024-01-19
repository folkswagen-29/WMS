using onlineLegalWF.Class;
using onlineLegalWF.userControls;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceRenewRequestEdit : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public WFFunctions zwf = new WFFunctions();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    setDataEditRenewRequest(id);
                }

            }
        }

        private void setDataEditRenewRequest(string id)
        {
            ucHeader1.setHeader("Edit Renew Request");

            ddl_bu.DataSource = GetBusinessUnit();
            ddl_bu.DataBind();
            ddl_bu.DataTextField = "bu_desc";
            ddl_bu.DataValueField = "bu_code";
            ddl_bu.DataBind();

            string sql = "select * from li_insurance_request where req_no='" + id + "'";

            var res = zdb.ExecSql_DataTable(sql, zconnstr);

            if (res.Rows.Count > 0)
            {
                req_no.Text = res.Rows[0]["req_no"].ToString();
                req_date.Value = Convert.ToDateTime(res.Rows[0]["req_date"]).ToString("yyyy-MM-dd");
                type_req.SelectedValue = res.Rows[0]["toreq_code"].ToString();
                company_name.Text = res.Rows[0]["company_name"].ToString();
                doc_no.Text = res.Rows[0]["document_no"].ToString();
                subject.Text = res.Rows[0]["subject"].ToString();
                to.Text = res.Rows[0]["dear"].ToString();
                purpose.Text = res.Rows[0]["objective"].ToString();
                background.Text = res.Rows[0]["reason"].ToString();
                ddl_bu.SelectedValue = res.Rows[0]["bu_code"].ToString();
                prop_ins_name.Text = res.Rows[0]["property_insured_name"].ToString();
                lblPID.Text = res.Rows[0]["process_id"].ToString();
                hid_PID.Value = res.Rows[0]["process_id"].ToString();
                ucAttachment1.ini_object(hid_PID.Value = res.Rows[0]["process_id"].ToString());
                ucCommentlog1.ini_object(hid_PID.Value = res.Rows[0]["process_id"].ToString());
            }

            var dt = iniDataTable(id);
            gv1.DataSource = dt;
            gv1.DataBind();

        }
        public DataTable GetBusinessUnit()
        {
            string sql = "select * from li_business_unit order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        public DataTable iniDataTable(string id)
        {
            //getData
            var dt = iniDTStructure();
            var dr = dt.NewRow();

            var dt_top_ins = GetTypeOfPropertyInsured();
            var dt_prop_ins = GetDataPropertyInsuredByReqNo(id);

            if (dt_top_ins.Rows.Count > 0)
            {
                int no = 0;

                foreach (DataRow dr_ins in dt_top_ins.Rows)
                {
                    //init Data PropertyInsured
                    dr = dt.NewRow();
                    dr["No"] = (no + 1);
                    dr["PropertyInsured"] = dr_ins["top_ins_desc"].ToString();

                    //check Data from Db
                    if (dt_prop_ins.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt_prop_ins.Rows) 
                        {
                            //check data ins_code tb master == ins_code detail assign value
                            if (item["top_ins_code"].ToString() == dr_ins["top_ins_code"].ToString())
                            {
                                
                                dr["IndemnityPeriod"] = item["indemnityperiod"].ToString();
                                dr["SumInsured"] = item["suminsured"].ToString();
                                dr["StartDate"] = Convert.ToDateTime(item["startdate"]).ToString("yyyy-MM-dd");
                                dr["EndDate"] = Convert.ToDateTime(item["enddate"]).ToString("yyyy-MM-dd");
                                
                            }
                        }
                        
                    }
                    else 
                    {
                        dr["IndemnityPeriod"] = "";
                        dr["SumInsured"] = "";
                        dr["StartDate"] = "";
                        dr["EndDate"] = "";
                    }

                    dr["Top_Ins_Code"] = dr_ins["top_ins_code"].ToString();
                    dt.Rows.Add(dr);



                    no++;
                }
            }

            return dt;
        }

        public DataTable iniDTStructure()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(string));
            dt.Columns.Add("PropertyInsured", typeof(string));
            dt.Columns.Add("IndemnityPeriod", typeof(string));
            dt.Columns.Add("SumInsured", typeof(string));
            dt.Columns.Add("StartDate", typeof(string));
            dt.Columns.Add("EndDate", typeof(string));
            dt.Columns.Add("Top_Ins_Code", typeof(string));
            return dt;
        }

        public DataTable GetTypeOfPropertyInsured()
        {
            string sql = "select * from li_type_of_property_insured order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        public DataTable GetDataPropertyInsuredByReqNo(string id)
        {
            string sqlPropIns = "select * from li_insurance_req_property_insured where req_no='" + id + "'";
            DataTable dt = zdb.ExecSql_DataTable(sqlPropIns, zconnstr);

            return dt;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int res = UpdateRenewRequest();

            if (res > 0)
            {
                Response.Write("<script>alert('Successfully Updated');</script>");
                //Response.Redirect("/frmInsurance/InsuranceRenewRequestList");
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
        }

        private int UpdateRenewRequest()
        {
            int ret = 0;

            var xreq_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xreq_no = req_no.Text.Trim();
            var xtype_req = type_req.SelectedValue.ToString();
            var xbu_code = ddl_bu.SelectedValue.ToString();
            var xcompany_name = ddl_bu.SelectedItem.Text.ToString();
            var xdoc_no = doc_no.Text.Trim();
            var xsubject = subject.Text.Trim();
            var xto = to.Text.Trim();
            var xpurpose = purpose.Text.Trim();
            var xbackground = background.Text.Trim();
            var xprop_ins_name = prop_ins_name.Text.Trim();


            //Get Data from gv1 Insurance Detail
            List<InsurancePropData> listInsurancePropData = new List<InsurancePropData>();
            foreach (GridViewRow row in gv1.Rows)
            {
                InsurancePropData data = new InsurancePropData();
                data.TypeOfPropertyInsured = (row.FindControl("gv1txttop_ins_code") as HiddenField).Value;
                data.PropertyInsured = (row.FindControl("gv1txtPropertyInsured") as TextBox).Text;
                data.IndemnityPeriod = (row.FindControl("gv1txtIndemnityPeriod") as TextBox).Text;
                data.SumInsured = (row.FindControl("gv1txtSumInsured") as TextBox).Text;
                data.StartDate = (row.FindControl("gv1txtSdate") as TextBox).Text;
                data.EndDate = (row.FindControl("gv1txtEdate") as TextBox).Text;

                if (!string.IsNullOrEmpty(data.IndemnityPeriod) && !string.IsNullOrEmpty(data.SumInsured) && !string.IsNullOrEmpty(data.StartDate) && !string.IsNullOrEmpty(data.EndDate))
                {
                    listInsurancePropData.Add(data);
                }

            }

            string sql = @"UPDATE [dbo].[li_insurance_request]
                               SET [toreq_code] = '" + xtype_req + @"'
                                  ,[company_name] = '" + xcompany_name + @"'
                                  ,[document_no] = '" + xdoc_no + @"'
                                  ,[subject] = '" + xsubject + @"'
                                  ,[dear] = '" + xto + @"'
                                  ,[objective] = '" + xpurpose + @"'
                                  ,[reason] = '" + xbackground + @"'
                                  ,[updated_datetime] = '" + xreq_date + @"'
                                  ,[bu_code] = '" + xbu_code + @"'
                                  ,[property_insured_name] = '" + xprop_ins_name + @"'
                             WHERE [req_no] ='" + xreq_no + "'";

            ret = zdb.ExecNonQueryReturnID(sql, zconnstr);

            if (ret > 0)
            {
                if (listInsurancePropData.Count > 0)
                {
                    string sqlDeletePropIns = @"DELETE FROM [li_insurance_req_property_insured] WHERE req_no='" + xreq_no + "'";

                    ret = zdb.ExecNonQueryReturnID(sqlDeletePropIns, zconnstr);

                    if (ret > 0) 
                    {
                        foreach (var item in listInsurancePropData)
                        {
                            string sqlInsertPropIns = @"INSERT INTO [dbo].[li_insurance_req_property_insured]
                                                   ([req_no],[top_ins_code],[indemnityperiod],[suminsured],[startdate],[enddate],[created_datetime],[updated_datetime])
                                             VALUES
                                                   ('" + xreq_no + @"'
                                                   ,'" + item.TypeOfPropertyInsured + @"'
                                                   ,'" + item.IndemnityPeriod + @"'
                                                   ,'" + item.SumInsured + @"'
                                                   ,'" + item.StartDate + @"'
                                                   ,'" + item.EndDate + @"'
                                                   ,'" + xreq_date + @"'
                                                   ,'" + xreq_date + @"')";

                            ret = zdb.ExecNonQueryReturnID(sqlInsertPropIns, zconnstr);
                        }
                    }
                    
                }

            }

            return ret;
        }

        public class InsurancePropData
        {
            public string TypeOfPropertyInsured { get; set; }
            public string PropertyInsured { get; set; }
            public string IndemnityPeriod { get; set; }
            public string SumInsured { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {
            GenDocumnet();
        }
        private void GenDocumnet()
        {
            // Replace Doc
            var xreq_date = Utillity.ConvertStringToDate(req_date.Value);
            var xreq_no = req_no.Text.Trim();
            var xbu_code = ddl_bu.SelectedValue.ToString();
            var xcompany_name = ddl_bu.SelectedItem.Text.ToString();
            var xdoc_no = doc_no.Text.Trim();
            var xsubject = subject.Text.Trim();
            var xto = to.Text.Trim();
            var xpurpose = purpose.Text.Trim();
            var xbackground = background.Text.Trim();
            var xapprove_des = "We, therefore, request for your approval to renew mentioned insurance policy.";

            string templatefile = @"C:\WordTemplate\Insurance\InsuranceTemplateRenew.docx";
            string outputfolder = @"C:\WordTemplate\Insurance\Output";
            string outputfn = outputfolder + @"\inreq_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

            var rdoc = new ReplaceDocx.Class.ReplaceDocx();

            #region prepare data
            //Replace TAG STRING
            DataTable dtStr = new DataTable();
            dtStr.Columns.Add("tagname", typeof(string));
            dtStr.Columns.Add("tagvalue", typeof(string));

            DataRow dr0 = dtStr.NewRow();
            dr0["tagname"] = "#docno#";
            dr0["tagvalue"] = xdoc_no.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#from#";
            dr0["tagvalue"] = xcompany_name.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#attn#";
            dr0["tagvalue"] = xto.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#re#";
            dr0["tagvalue"] = xsubject.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#reqdate#";
            //dr0["tagvalue"] = xreq_date.ToString("dd/MM/yyyy").Replace(",", "!comma");
            dr0["tagvalue"] = Utillity.ConvertDateToLongDateTime(xreq_date, "en");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#objective#";
            dr0["tagvalue"] = xpurpose.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#reason#";
            dr0["tagvalue"] = xbackground.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#approve#";
            dr0["tagvalue"] = xapprove_des.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            #endregion

            //DOA
            #region DOA 

            var requestordate = System.DateTime.Now.ToString("dd/MM/yyyy");


            ///get gm heam_am c_level
            string sqlbu = @"select * from li_business_unit where bu_code = '" + xbu_code + "'";
            var res = zdb.ExecSql_DataTable(sqlbu, zconnstr);

            var requestor = "";
            var requestorpos = "";
            var gmname = "";
            var amname = "";
            var clevelname = "";
            if (res.Rows.Count > 0)
            {
                var empFunc = new EmpInfo();
                if (Session["user_login"] != null)
                {
                    var xlogin_name = Session["user_login"].ToString();
                    var emp = empFunc.getEmpInfo(xlogin_name);
                    requestor = emp.full_name_en;
                    requestorpos = emp.position_en;
                }
                string xgm = res.Rows[0]["gm"].ToString();
                string xam = res.Rows[0]["head_am"].ToString();
                string xclevel = res.Rows[0]["c_level"].ToString();
                //get data am user
                if (!string.IsNullOrEmpty(xam))
                {
                    var empam = empFunc.getEmpInfo(xam);
                    if (empam.user_login != null)
                    {
                        amname = empam.full_name_en;
                    }
                }
                //get data gm user
                if (!string.IsNullOrEmpty(xgm))
                {
                    var empgm = empFunc.getEmpInfo(xgm);
                    if (empgm.user_login != null)
                    {
                        gmname = empgm.full_name_en;
                    }
                }
                //get data c_level user
                if (!string.IsNullOrEmpty(xclevel))
                {
                    var empc = empFunc.getEmpInfo(xclevel);
                    if (empc.user_login != null)
                    {
                        clevelname = empc.full_name_en;
                    }
                }
            }

            var apv1 = gmname;
            var apv1pos = "GM";
            var apv1date = "";
            var apv2 = amname;
            var apv2pos = "AM";
            var apv2date = "";
            var apv3 = clevelname;
            var apv3pos = "C-Level";
            var apv3date = "";
            var signname1 = "";
            var signname2 = "";
            var signname3 = "";
            var signname4 = "";


            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#sign_name1#";
            dr0["tagvalue"] = signname1;
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#name1#";
            dr0["tagvalue"] = requestor.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#position1#";
            dr0["tagvalue"] = requestorpos.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#date1#";
            dr0["tagvalue"] = requestordate.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);

            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#sign_name2#";
            dr0["tagvalue"] = signname2;
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#name2#";
            dr0["tagvalue"] = apv1.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#position2#";
            dr0["tagvalue"] = apv1pos.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#date2#";
            dr0["tagvalue"] = apv1date.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);

            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#sign_name3#";
            dr0["tagvalue"] = signname3;
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#name3#";
            dr0["tagvalue"] = apv2.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#position3#";
            dr0["tagvalue"] = apv2pos.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#date3#";
            dr0["tagvalue"] = apv2date.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);

            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#sign_name4#";
            dr0["tagvalue"] = signname4;
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#name4#";
            dr0["tagvalue"] = apv3.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#position4#";
            dr0["tagvalue"] = apv3pos.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#date4#";
            dr0["tagvalue"] = apv3date.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);

            #endregion 

            #region Sample ReplaceTable

            //DataTable Column Properties
            //col_name, col_width, col_align, col_valign,
            DataTable dtProperties1 = new DataTable();
            dtProperties1.Columns.Add("tagname", typeof(string));
            dtProperties1.Columns.Add("col_name", typeof(string));
            dtProperties1.Columns.Add("col_width", typeof(string));
            dtProperties1.Columns.Add("col_align", typeof(string)); //Left, Right, Center
            dtProperties1.Columns.Add("col_valign", typeof(string)); //Top, Middle, Bottom
            dtProperties1.Columns.Add("col_font", typeof(string));
            dtProperties1.Columns.Add("col_fontsize", typeof(string));
            dtProperties1.Columns.Add("col_fontcolor", typeof(string));
            dtProperties1.Columns.Add("col_color", typeof(string));
            dtProperties1.Columns.Add("header_height", typeof(string));
            dtProperties1.Columns.Add("header_color", typeof(string));
            dtProperties1.Columns.Add("header_font", typeof(string));
            dtProperties1.Columns.Add("header_fontsize", typeof(string));
            dtProperties1.Columns.Add("header_fontbold", typeof(string));
            dtProperties1.Columns.Add("header_align", typeof(string)); //Left, Right, Center
            dtProperties1.Columns.Add("header_valign", typeof(string)); //Top, Middle, Bottom
            dtProperties1.Columns.Add("header_fontcolor", typeof(string));
            dtProperties1.Columns.Add("row_height", typeof(string));
            // Replace #table1# ------------------------------------------------------
            DataRow dr = dtProperties1.NewRow();
            dr["tagname"] = "#table1#";
            dr["col_name"] = "No";
            dr["col_width"] = "100";
            dr["col_align"] = "Center";
            dr["col_valign"] = "Top";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            dr = dtProperties1.NewRow();
            dr["tagname"] = "#table1#";
            dr["col_name"] = "Property Insured";
            dr["col_width"] = "200";
            dr["col_align"] = "Left";
            dr["col_valign"] = "Top";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            dr = dtProperties1.NewRow();
            dr["tagname"] = "#table1#";
            dr["col_name"] = "Indemnity Period";
            dr["col_width"] = "200";
            dr["col_align"] = "Center";
            dr["col_valign"] = "Top";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            dr = dtProperties1.NewRow();
            dr["tagname"] = "#table1#";
            dr["col_name"] = "Sum Insured";
            dr["col_width"] = "200";
            dr["col_align"] = "Center";
            dr["col_valign"] = "top";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            dr = dtProperties1.NewRow();
            dr["tagname"] = "#table1#";
            dr["col_name"] = "Start Date";
            dr["col_width"] = "150";
            dr["col_align"] = "left";
            dr["col_valign"] = "top";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            dr = dtProperties1.NewRow();
            dr["tagname"] = "#table1#";
            dr["col_name"] = "End Date";
            dr["col_width"] = "150";
            dr["col_align"] = "left";
            dr["col_valign"] = "top";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            //  DataTable dt = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("tagname", typeof(string));
            dt.Columns.Add("No", typeof(string));
            dt.Columns.Add("Property Insured", typeof(string));
            dt.Columns.Add("Indemnity Period", typeof(string));
            dt.Columns.Add("Sum Insured", typeof(string));
            dt.Columns.Add("Start Date", typeof(string));
            dt.Columns.Add("End Date", typeof(string));

            //DataTable for #table1#
            //Get Data from gv1 Insurance Detail
            List<InsurancePropData> listInsurancePropData = new List<InsurancePropData>();
            foreach (GridViewRow row in gv1.Rows)
            {
                InsurancePropData data = new InsurancePropData();
                data.TypeOfPropertyInsured = (row.FindControl("gv1txttop_ins_code") as HiddenField).Value;
                data.PropertyInsured = (row.FindControl("gv1txtPropertyInsured") as TextBox).Text;
                data.IndemnityPeriod = (row.FindControl("gv1txtIndemnityPeriod") as TextBox).Text;
                data.SumInsured = (row.FindControl("gv1txtSumInsured") as TextBox).Text;
                data.StartDate = (row.FindControl("gv1txtSdate") as TextBox).Text;
                data.EndDate = (row.FindControl("gv1txtEdate") as TextBox).Text;

                if (!string.IsNullOrEmpty(data.IndemnityPeriod) && !string.IsNullOrEmpty(data.SumInsured) && !string.IsNullOrEmpty(data.StartDate) && !string.IsNullOrEmpty(data.EndDate))
                {
                    listInsurancePropData.Add(data);
                }

            }
            //Assign Data From gv1
            var drGV = dt.NewRow();

            if (listInsurancePropData.Count > 0)
            {
                int no = 0;

                foreach (var item in listInsurancePropData)
                {
                    drGV = dt.NewRow();
                    drGV["tagname"] = "#table1#";
                    drGV["No"] = (no + 1);
                    drGV["Property Insured"] = item.PropertyInsured;
                    drGV["Indemnity Period"] = item.IndemnityPeriod;
                    drGV["Sum Insured"] = item.SumInsured;
                    drGV["Start Date"] = Utillity.ConvertDateToLongDateTime(Utillity.ConvertStringToDate(item.StartDate), "en");
                    drGV["End Date"] = Utillity.ConvertDateToLongDateTime(Utillity.ConvertStringToDate(item.EndDate), "en");
                    dt.Rows.Add(drGV);

                    no++;
                }
            }

            // Convert to JSONString
            DataTable dtTagPropsTable = new DataTable();
            dtTagPropsTable.Columns.Add("tagname", typeof(string));
            dtTagPropsTable.Columns.Add("jsonstring", typeof(string));

            DataTable dtTagDataTable = new DataTable();
            dtTagDataTable.Columns.Add("tagname", typeof(string));
            dtTagDataTable.Columns.Add("jsonstring", typeof(string));
            ReplaceDocx.Class.ReplaceDocx repl = new ReplaceDocx.Class.ReplaceDocx();
            var jsonDTStr = repl.DataTableToJSONWithStringBuilder(dtStr);
            var jsonDTProperties1 = repl.DataTableToJSONWithStringBuilder(dtProperties1);
            //var jsonDTProperties2 = repl.DataTableToJSONWithStringBuilder(dtProperties2);
            var jsonDTdata = repl.DataTableToJSONWithStringBuilder(dt);
            //var jsonDTdata2 = repl.DataTableToJSONWithStringBuilder(dt2);
            //end prepare data

            // Save to Database z_replacedocx_log

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
            // Dowload Word 
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.AddHeader("content-disposition", $"attachment; filename={outputfn}");
            Response.BinaryWrite(outputbyte);
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.End();


            #endregion
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            // Sample Submit
            string process_code = "INR_RENEW";
            int version_no = 1;
            string xbu_code = ddl_bu.SelectedValue;

            // getCurrentStep
            var wfAttr = zwf.getCurrentStep(lblPID.Text, process_code, version_no);

            // check session_user
            if (Session["user_login"] != null)
            {
                var xlogin_name = Session["user_login"].ToString();
                var empFunc = new EmpInfo();

                //get data user
                var emp = empFunc.getEmpInfo(xlogin_name);

                // set WF Attributes
                wfAttr.subject = subject.Text.Trim();
                wfAttr.assto_login = emp.next_line_mgr_login;
                wfAttr.wf_status = "SUBMITTED";
                wfAttr.submit_answer = "SUBMITTED";
                //wfAttr.next_assto_login = emp.next_line_mgr_login;
                wfAttr.submit_by = emp.user_login;
                wfAttr.next_assto_login = zwf.findNextStep_Assignee(wfAttr.process_code, wfAttr.step_name, emp.user_login, wfAttr.submit_by, lblPID.Text, xbu_code);
                wfAttr.updated_by = emp.user_login;
                
                // wf.updateProcess
                var wfA_NextStep = zwf.updateProcess(wfAttr);
                //wfA_NextStep.next_assto_login = emp.next_line_mgr_login;
                wfA_NextStep.next_assto_login = zwf.findNextStep_Assignee(wfA_NextStep.process_code, wfA_NextStep.step_name, emp.user_login, wfAttr.submit_by, lblPID.Text, xbu_code);
                string status = zwf.Insert_NextStep(wfA_NextStep);

                if (status == "Success")
                {
                    Response.Redirect("/legalportal/legalportal.aspx?m=myworklist");
                }

            }


        }
    }
}