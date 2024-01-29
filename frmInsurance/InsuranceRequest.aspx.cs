using Microsoft.Office.Interop.Word;
using onlineLegalWF.Class;
using onlineLegalWF.userControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataTable = System.Data.DataTable;

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceRequest : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        //public string zconnstr = ConfigurationSettings.AppSettings["BPMDB"].ToString();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public string zconnstrrpa = ConfigurationManager.AppSettings["RPADB"].ToString();
        public WFFunctions zwf = new WFFunctions();
        public ReplaceInsNew zreplaceinsnew = new ReplaceInsNew();
        public MargePDF zmergepdf = new MargePDF();
        public SendMail zsendmail = new SendMail();
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
            ucHeader1.setHeader("New Request");
            string xreq_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            req_no.Text = xreq_no;

            type_req.DataSource = GetTypeOfRequest();
            type_req.DataBind();
            type_req.DataTextField = "toreq_desc";
            type_req.DataValueField = "toreq_code";
            type_req.DataBind();

            type_pi.DataSource = GetTypeOfPropertyInsured();
            type_pi.DataBind();
            type_pi.DataTextField = "top_ins_desc";
            type_pi.DataValueField = "top_ins_code";
            type_pi.DataBind();

            ddl_bu.DataSource = GetBusinessUnit();
            ddl_bu.DataBind();
            ddl_bu.DataTextField = "bu_desc";
            ddl_bu.DataValueField = "bu_code";
            ddl_bu.DataBind();

            string pid = zwf.iniPID("LEGALWF");
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucCommentlog1.ini_object(pid);

            

        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {
            GenDocumnet();
        }

        private void GenDocumnet() 
        {
            // Replace Doc
            var xtype_req = type_req.SelectedValue.ToString();
            var xcompany = company.Text.Trim();
            var xdoc_no = doc_no.Text.Trim();
            var xreq_date = System.DateTime.Now;
            var xsubject = subject.Text.Trim();
            var xto = to.Text.Trim();
            var xpurpose = purpose.Text.Trim();
            var xbackground = background.Text.Trim();
            var xtype_pi = type_pi.SelectedValue.ToString();
            var xindemnity_period = indemnity_period.Text.Trim();
            var xsum_insured = sum_insured.Text.Trim();
            var xstart_date = start_date.Text.Trim();
            var xend_date = end_date.Text.Trim();
            var xapprove_des = approve_des.Text.Trim();

            string templatefile = @"C:\WordTemplate\Insurance\InsuranceTemplateRequest.docx";
            string outputfolder = @"C:\WordTemplate\Insurance\Output";
            string outputfn = outputfolder + @"\inreq_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

            var rdoc = new ReplaceDocx.Class.ReplaceDocx();

            #region gentagstr data form
            ReplaceInsNew_TagData data = new ReplaceInsNew_TagData();

            data.docno = xdoc_no.Replace(",", "!comma");
            data.company = xcompany.Replace(",", "!comma");
            data.to = xto.Replace(",", "!comma");
            data.subject = xsubject.Replace(",", "!comma");
            data.reqdate = Utillity.ConvertDateToLongDateTime(xreq_date, "en");
            data.objective = xpurpose.Replace(",", "!comma");
            data.reason = xbackground.Replace(",", "!comma");
            data.approve = xapprove_des.Replace(",", "!comma");

            ////get gm or am check external domain
            string xbu_code = ddl_bu.SelectedValue.ToString();
            string sqlbu = @"select * from li_business_unit where bu_code = '" + xbu_code + "'";

            var res = zdb.ExecSql_DataTable(sqlbu, zconnstr);

            var requestor = "";
            var requestorpos = "";
            if (res.Rows.Count > 0)
            {
                string xexternal_domain = res.Rows[0]["external_domain"].ToString();
                string xgm = res.Rows[0]["gm"].ToString();
                string xam = res.Rows[0]["head_am"].ToString();
                var empFunc = new EmpInfo();

                if (xexternal_domain == "Y")
                {
                    //get data user
                    var emp = empFunc.getEmpInfo(xam);
                    requestor = emp.full_name_en;
                    requestorpos = emp.position_en;
                }
                else
                {
                    //get data user
                    var emp = empFunc.getEmpInfo(xgm);
                    requestor = emp.full_name_en;
                    requestorpos = emp.position_en;
                }


            }

            var apv1 = "คุณจรูณศักดิ์ นามะฮง";
            var apv1pos = "Insurance Specialist";
            var apv1_2 = "คุณวารินทร์ เกลียวไพศาล";
            var apv2 = "คุณชโลทร ศรีสมวงษ์";
            var apv2pos = "Head of Legal";
            var apv3 = "คุณชยุต อมตวนิช";
            var apv3pos = "Head of Risk Management";

            var apv4 = "ดร.สิเวศ โรจนสุนทร";
            var apv4pos = "CCO";

            data.sign_name1 = "";
            data.name1 = requestor;
            data.position1 = requestorpos;
            data.date1 = "";

            data.sign_name2 = "";
            data.name2 = apv1;
            data.position2 = apv1pos;
            data.date2 = "";

            data.sign_name22 = "";
            data.name22 = apv1_2;
            data.date22 = "";

            data.sign_name3 = "";
            data.name3 = apv2;
            data.position3 = apv2pos;
            data.date3 = "";

            data.sign_name4 = "";
            data.name4 = apv3;
            data.position4 = apv3pos;
            data.date4 = "";

            data.sign_name5 = "";
            data.name5 = apv4;
            data.position5 = apv4pos;
            data.date5 = "";
            data.cb1 = "";
            data.cb2 = "";
            data.remark5 = "";

            DataTable dtStr = zreplaceinsnew.genTagData(data);
            #endregion

            #region prepare data
            ////Replace TAG STRING

            //DataTable dtStr = new DataTable();
            //dtStr.Columns.Add("tagname", typeof(string));
            //dtStr.Columns.Add("tagvalue", typeof(string));

            //DataRow dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#docno#";
            //dr0["tagvalue"] = xdoc_no.Replace(",", "!comma");
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#company#";
            //dr0["tagvalue"] = xcompany.Replace(",", "!comma");
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#to#";
            //dr0["tagvalue"] = xto.Replace(",", "!comma");
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#subject#";
            //dr0["tagvalue"] = xsubject.Replace(",", "!comma");
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#reqdate#";
            //dr0["tagvalue"] = Utillity.ConvertDateToLongDateTime(xreq_date, "en");
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#objective#";
            //dr0["tagvalue"] = xpurpose.Replace(",", "!comma");
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#reason#";
            //dr0["tagvalue"] = xbackground.Replace(",", "!comma");
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#approve#";
            //dr0["tagvalue"] = xapprove_des.Replace(",", "!comma");
            //dtStr.Rows.Add(dr0);
            #endregion

            //DOA
            #region DOA 

            ////get gm or am check external domain
            //string xbu_code = ddl_bu.SelectedValue.ToString();
            //string sqlbu = @"select * from li_business_unit where bu_code = '"+ xbu_code + "'";

            //var res = zdb.ExecSql_DataTable(sqlbu, zconnstr);


            //var requestor = "";
            //var requestorpos = "";
            //var requestordate = "";
            //var signname1 = "";
            //var signname2 = "";
            //var signname22 = "";
            //var signname3 = "";
            //var signname4 = "";
            //var signname5 = "";
            //if (res.Rows.Count > 0)
            //{
            //    string xexternal_domain = res.Rows[0]["external_domain"].ToString();
            //    string xgm = res.Rows[0]["gm"].ToString();
            //    string xam = res.Rows[0]["head_am"].ToString();
            //    var empFunc = new EmpInfo();

            //    if (xexternal_domain == "Y") 
            //    {
            //        //get data user
            //        var emp = empFunc.getEmpInfo(xam);
            //        requestor = emp.full_name_en;
            //        requestorpos = emp.position_en;
            //    }
            //    else 
            //    {
            //        //get data user
            //        var emp = empFunc.getEmpInfo(xgm);
            //        requestor = emp.full_name_en;
            //        requestorpos = emp.position_en;
            //    }


            //}

            //var apv1 = "คุณจรูณศักดิ์ นามะฮง";
            //var apv1pos = "Insurance Specialist";
            //var apv1date = "";
            //var apv1_2 = "คุณวารินทร์ เกลียวไพศาล";
            //var apv1_2date = "";
            //var apv2 = "คุณชโลทร ศรีสมวงษ์";
            //var apv2pos = "Head of Legal";
            //var apv2date = "";
            //var apv3 = "คุณชยุต อมตวนิช";
            //var apv3pos = "Head of Risk Management";
            //var apv3date = "";

            //var apv4 = "ดร.สิเวศ โรจนสุนทร";
            //var apv4pos = "CCO";
            //var apv4date = "";
            //var apv4cb1 = "";
            //var apv4cb2 = "";
            //var apv4remark = "";

            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#name1#";
            //dr0["tagvalue"] = requestor;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#position1#";
            //dr0["tagvalue"] = requestorpos;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#date1#";
            //dr0["tagvalue"] = requestordate;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#sign_name1#";
            //dr0["tagvalue"] = signname1;
            //dtStr.Rows.Add(dr0);

            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#name2#";
            //dr0["tagvalue"] = apv1;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#position2#";
            //dr0["tagvalue"] = apv1pos;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#date2#";
            //dr0["tagvalue"] = apv1date;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#sign_name2#";
            //dr0["tagvalue"] = signname2;
            //dtStr.Rows.Add(dr0);

            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#name22#";
            //dr0["tagvalue"] = apv1_2;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#date22#";
            //dr0["tagvalue"] = apv1_2date;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#sign_name22#";
            //dr0["tagvalue"] = signname22;
            //dtStr.Rows.Add(dr0);

            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#name3#";
            //dr0["tagvalue"] = apv2;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#position3#";
            //dr0["tagvalue"] = apv2pos;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#date3#";
            //dr0["tagvalue"] = apv2date;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#sign_name3#";
            //dr0["tagvalue"] = signname3;
            //dtStr.Rows.Add(dr0);


            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#name4#";
            //dr0["tagvalue"] = apv3;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#position4#";
            //dr0["tagvalue"] = apv3pos;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#date4#";
            //dr0["tagvalue"] = apv3date;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#sign_name4#";
            //dr0["tagvalue"] = signname4;
            //dtStr.Rows.Add(dr0);

            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#name5#";
            //dr0["tagvalue"] = apv4;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#position5#";
            //dr0["tagvalue"] = apv4pos;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#date5#";
            //dr0["tagvalue"] = apv4date;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#sign_name5#";
            //dr0["tagvalue"] = signname5;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#cb1#";
            //dr0["tagvalue"] = apv4cb1;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#cb2#";
            //dr0["tagvalue"] = apv4cb2;
            //dtStr.Rows.Add(dr0);
            //dr0 = dtStr.NewRow();
            //dr0["tagname"] = "#remark5#";
            //dr0["tagvalue"] = apv4remark;
            //dtStr.Rows.Add(dr0);
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
            dr["header_align"] = "Middle";
            dr["header_valign"] = "Center";
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
            dr["col_name"] = "Sum Insured";
            dr["col_width"] = "200";
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

            DataTable dt = zreplaceinsnew.genTagTableData(lblPID.Text);
            //DataTable dt = new DataTable();
            //dt.Columns.Add("tagname", typeof(string));
            //dt.Columns.Add("No", typeof(string));
            //dt.Columns.Add("Property Insured", typeof(string));
            //dt.Columns.Add("Indemnity Period", typeof(string));
            //dt.Columns.Add("Sum Insured", typeof(string));
            //dt.Columns.Add("Start Date", typeof(string));
            //dt.Columns.Add("End Date", typeof(string));

            ////DataTable for #table1#

            ////Assign DataTable for #table#
            //DataRow dr1 = dt.NewRow();
            //dr1["tagname"] = "#table1#";
            //dr1["No"] = "1";
            //dr1["Property Insured"] = xtype_pi.Replace(",", "!comma");  // "xxxxx";//.Text.Replace(",", "!comma");
            //dr1["Indemnity Period"] = xindemnity_period.Replace(",", "!comma"); // "1,000,000".Replace(",", "!comma"); ;
            //dr1["Sum Insured"] = xsum_insured.Replace(",", "!comma");  // "15,000".Replace(",", "!comma"); ;
            //dr1["Start Date"] = Utillity.ConvertDateToLongDateTime(Utillity.ConvertStringToDate(xstart_date), "en");
            //dr1["End Date"] = Utillity.ConvertDateToLongDateTime(Utillity.ConvertStringToDate(xend_date), "en");
            //dt.Rows.Add(dr1);
            #endregion

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
            //// Dowload Word 
            //Response.Clear();
            //Response.ContentType = "text/xml";
            //Response.AddHeader("content-disposition", $"attachment; filename={outputfn}");
            //Response.BinaryWrite(outputbyte);
            //Response.ContentEncoding = System.Text.Encoding.UTF8;
            //Response.End();
            string filePath = outputfn.Replace(".docx", ".pdf");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            pdf_render.Attributes["src"] = "/render/pdf?id=" + filePath;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrEmpty(company.Text))
                {
                    showAlertError("alertTitleErr", "Warning! Please input company");
                    return;
                }
                if (string.IsNullOrEmpty(subject.Text))
                {
                    showAlertError("alertTitleErr", "Warning! Please input subject");
                    return;
                }
                if (string.IsNullOrEmpty(to.Text))
                {
                    showAlertError("alertTitleErr", "Warning! Please input to");
                    return;
                }
                if (string.IsNullOrEmpty(purpose.Text))
                {
                    showAlertError("alertTitleErr", "Warning! Please input purpose");
                    return;
                }
                if (string.IsNullOrEmpty(background.Text))
                {
                    showAlertError("alertTitleErr", "Warning! Please input background");
                    return;
                }
                if (string.IsNullOrEmpty(prop_ins_name.Text))
                {
                    showAlertError("alertTitleErr", "Warning! Please input Property Insured Name");
                    return;
                }

                int res = SaveRequest();

                if (res > 0)
                {
                    // wf save draft
                    string process_code = "INR_NEW";
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
                        wfAttr.wf_status = "SAVE";
                        wfAttr.submit_answer = "SAVE";
                        wfAttr.submit_by = emp.user_login;
                        wfAttr.next_assto_login = zwf.findNextStep_Assignee(wfAttr.process_code, wfAttr.step_name, emp.user_login, emp.user_login,lblPID.Text, xbu_code);
                        

                        // wf.updateProcess
                        var wfA_NextStep = zwf.updateProcess(wfAttr);

                    }
                    showAlertSuccess("alertSuccess", "Insert success");
                    Response.Redirect("/frmInsurance/InsuranceRequestEdit.aspx?id=" + req_no.Text.Trim());
                    //Response.Redirect("/legalportal/legalportal.aspx?m=myrequest");
                }
                else
                {
                    showAlertError("alertErr", "Error !!!");
                }
            }
            catch (Exception ex)
            {
                showAlertError("alertErr", ex.Message);
            }
            
            
        }
        public DataTable GetBusinessUnit()
        {
            string sql = "select * from li_business_unit order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }
        public DataTable GetTypeOfRequest()
        {
            string sql = "select * from li_type_of_request where toreq_code not in (07) order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        public DataTable GetTypeOfPropertyInsured()
        {
            string sql = "select * from li_type_of_property_insured order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        public int GetMaxProcessID()
        {
            string sql = "select isnull(max(process_id),0) as id from li_insurance_request";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        private int SaveRequest() 
        {
            int ret = 0;

            if (doc_no.Text.Trim() == "")
            {
                doc_no.Text = zwf.genDocNo("INS-" + System.DateTime.Now.ToString("yyyy", new CultureInfo("en-US")) + "-", 4);
            }

            var xreq_no = req_no.Text.Trim();
            //var xprocess_id = string.Format("{0:000000}", (GetMaxProcessID() + 1));
            var xprocess_id = hid_PID.Value.ToString();
            var xtype_req = type_req.SelectedValue.ToString();
            var xcompany = company.Text.Trim();
            var xdoc_no = doc_no.Text.Trim();
            var xreq_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xsubject = subject.Text.Trim();
            var xto = to.Text.Trim();
            var xpurpose = purpose.Text.Trim();
            var xbackground = background.Text.Trim();
            var xtype_pi = type_pi.SelectedValue.ToString();
            var xindemnity_period = indemnity_period.Text.Trim();
            var xsum_insured = sum_insured.Text.Trim();
            var xstart_date = start_date.Text.Trim();
            var xend_date = end_date.Text.Trim();
            var xapprove_des = approve_des.Text.Trim();
            var xstatus = "verify";
            var xbu_code = ddl_bu.SelectedValue.ToString();
            var xprop_ins_name = prop_ins_name.Text.Trim();

            string sql = @"INSERT INTO [dbo].[li_insurance_request]
                                   ([process_id],[req_no],[req_date],[toreq_code],[company_name],[document_no],[subject],[dear],[objective],[reason],[approved_desc],[status],[bu_code],[property_insured_name])
                             VALUES
                                   ('" + xprocess_id + @"'
                                   ,'"+ xreq_no + @"'
                                   ,'"+ xreq_date + @"'
                                   ,'"+ xtype_req + @"'
                                   ,'"+ xcompany + @"'
                                   ,'"+ xdoc_no + @"'
                                   ,'"+ xsubject + @"'
                                   ,'"+ xto + @"'
                                   ,'"+ xpurpose + @"'
                                   ,'"+ xbackground + @"'
                                   ,'"+ xapprove_des + @"'
                                   ,'"+ xstatus + @"'
                                   ,'"+ xbu_code + @"'
                                   ,'"+ xprop_ins_name + @"')";

            ret = zdb.ExecNonQueryReturnID(sql, zconnstr);

            if (ret > 0) 
            {
                string sqlInsertPropIns = @"INSERT INTO [dbo].[li_insurance_req_property_insured]
                                                   ([req_no],[top_ins_code],[indemnityperiod],[suminsured],[startdate],[enddate],[created_datetime])
                                             VALUES
                                                   ('" + xreq_no + @"'
                                                   ,'" + xtype_pi + @"'
                                                   ,'" + xindemnity_period + @"'
                                                   ,'" + xsum_insured + @"'
                                                   ,'" + xstart_date + @"'
                                                   ,'" + xend_date + @"'
                                                   ,'" + xreq_date + @"')";

                ret = zdb.ExecNonQueryReturnID(sqlInsertPropIns, zconnstr);
                showAlertSuccess("alertSuccess", "Insert success");
            }


            return ret;
        }

        void showAlertSuccess(string key, string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertSuccess('" + msg + "');", true);
        }

        void showAlertError(string key, string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertError('" + msg + "');", true);
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string sqlreq = "select * from li_insurance_request where req_no='" + req_no.Text + "'";

            var res = zdb.ExecSql_DataTable(sqlreq, zconnstr);

            if (res.Rows.Count == 0) 
            {
                SaveRequest();
            }

            // Sample Submit
            string process_code = "INR_NEW";
            int version_no = 1;

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
                //wfAttr.assto_login = emp.next_line_mgr_login;
                wfAttr.wf_status = "SUBMITTED";
                wfAttr.submit_answer = "SUBMITTED";
                //wfAttr.next_assto_login = emp.next_line_mgr_login;
                wfAttr.submit_by = emp.user_login;
                wfAttr.next_assto_login = zwf.findNextStep_Assignee(wfAttr.process_code, wfAttr.step_name, emp.user_login, wfAttr.submit_by);
                wfAttr.updated_by = emp.user_login;
                
                // wf.updateProcess
                var wfA_NextStep = zwf.updateProcess(wfAttr);
                //wfA_NextStep.next_assto_login = emp.next_line_mgr_login;
                wfA_NextStep.next_assto_login = zwf.findNextStep_Assignee(wfA_NextStep.process_code, wfA_NextStep.step_name, emp.user_login, wfAttr.submit_by);
                string status = zwf.Insert_NextStep(wfA_NextStep);

                if (status == "Success")
                {
                    GenDocumnetInsNew(lblPID.Text);

                    //send mail
                    string subject = "";
                    string body = "";
                    string sqlmail = @"select * from li_insurance_request where process_id = '" + wfAttr.process_id + "'";
                    var dt = zdb.ExecSql_DataTable(sqlmail, zconnstr);
                    if (dt.Rows.Count > 0)
                    {
                        var dr = dt.Rows[0];
                        string id = dr["req_no"].ToString();
                        subject = dr["subject"].ToString();
                        body = "คุณได้รับมอบหมายให้ตรวจสอบเอกสารเลขที่ " + dr["document_no"].ToString() + " กรุณาตรวจสอบและดำเนินการผ่านระบบ";

                        string pathfileins = "";
                        string outputdirectory = "";

                        string sqlfile = "select top 1 * from z_replacedocx_log where replacedocx_reqno='" + id + "' order by row_id desc";

                        var resfile = zdb.ExecSql_DataTable(sqlfile, zconnstr);

                        if (resfile.Rows.Count > 0)
                        {
                            pathfileins = resfile.Rows[0]["output_filepath"].ToString().Replace(".docx", ".pdf");
                            outputdirectory = resfile.Rows[0]["output_directory"].ToString();

                            List<string> listpdf = new List<string>();
                            listpdf.Add(pathfileins);

                            string sqlattachfile = "select * from wf_attachment where pid = '" + wfAttr.process_id + "' and e_form IS NULL";

                            var resattachfile = zdb.ExecSql_DataTable(sqlattachfile, zconnstr);

                            if (resattachfile.Rows.Count > 0)
                            {
                                foreach (DataRow item in resattachfile.Rows)
                                {
                                    listpdf.Add(item["attached_filepath"].ToString());
                                }
                            }
                            //get list pdf file from tb z_replacedocx_log where replacedocx_reqno
                            string[] pdfFiles = listpdf.ToArray();

                            ////get mail from db
                            //string email = "";
                            //string sqlbpm = "select * from li_user where user_login = '" + wfA_NextStep.next_assto_login + "' ";
                            //System.Data.DataTable dtbpm = zdb.ExecSql_DataTable(sqlbpm, zconnstr);

                            //if (dtbpm.Rows.Count > 0)
                            //{
                            //    email = dtbpm.Rows[0]["email"].ToString();

                            //}
                            //else
                            //{
                            //    string sqlpra = "select * from Rpa_Mst_HrNameList where Login = 'ASSETWORLDCORP-\\" + wfA_NextStep.next_assto_login + "' ";
                            //    System.Data.DataTable dtrpa = zdb.ExecSql_DataTable(sqlpra, zconnstrrpa);

                            //    if (dtrpa.Rows.Count > 0)
                            //    {
                            //        email = dtrpa.Rows[0]["Email"].ToString();
                            //    }

                            //}

                            string filepath = zmergepdf.mergefilePDF(pdfFiles, outputdirectory);

                            //send mail to next_approve
                            ////fix mail test
                            string email = "worawut.m@assetworldcorp-th.com";
                            _ = zsendmail.sendEmail(subject + " Mail To Next Appove", email, body, filepath);

                        }

                    }

                    Response.Redirect("/legalportal/legalportal.aspx?m=myworklist");
                }

            }
           
            
        }
        private void GenDocumnetInsNew(string pid)
        {
            string xreq_no = "";
            string templatefile = @"C:\WordTemplate\Insurance\InsuranceTemplateRequest.docx";
            string outputfolder = @"C:\WordTemplate\Insurance\Output";
            string outputfn = outputfolder + @"\inreq_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

            var rdoc = new ReplaceDocx.Class.ReplaceDocx();

            string sqlinsreq = "select * from li_insurance_request where process_id='" + pid + "'";
            var resinsreq = zdb.ExecSql_DataTable(sqlinsreq, zconnstr);

            ReplaceInsNew_TagData data = new ReplaceInsNew_TagData();
            //get data ins req
            if (resinsreq.Rows.Count > 0)
            {
                xreq_no = resinsreq.Rows[0]["req_no"].ToString();

                ////get gm or am check external domain
                string xbu_code = resinsreq.Rows[0]["bu_code"].ToString();
                string sqlbu = @"select * from li_business_unit where bu_code = '" + xbu_code + "'";

                var res = zdb.ExecSql_DataTable(sqlbu, zconnstr);

                var requestor = "";
                var requestorpos = "";
                if (res.Rows.Count > 0)
                {
                    string xexternal_domain = res.Rows[0]["external_domain"].ToString();
                    string xgm = res.Rows[0]["gm"].ToString();
                    string xam = res.Rows[0]["head_am"].ToString();
                    var empFunc = new EmpInfo();

                    if (xexternal_domain == "Y")
                    {
                        //get data user
                        var emp = empFunc.getEmpInfo(xam);
                        requestor = emp.full_name_en;
                        requestorpos = emp.position_en;
                    }
                    else
                    {
                        //get data user
                        var emp = empFunc.getEmpInfo(xgm);
                        requestor = emp.full_name_en;
                        requestorpos = emp.position_en;
                    }

                }

                var apv1 = "คุณจรูณศักดิ์ นามะฮง";
                var apv1pos = "Insurance Specialist";
                var apv1_2 = "คุณวารินทร์ เกลียวไพศาล";
                var apv2 = "คุณชโลทร ศรีสมวงษ์";
                var apv2pos = "Head of Legal";
                var apv3 = "คุณชยุต อมตวนิช";
                var apv3pos = "Head of Risk Management";

                var apv4 = "ดร.สิเวศ โรจนสุนทร";
                var apv4pos = "CCO";

                data.sign_name1 = "";
                data.name1 = requestor;
                data.position1 = requestorpos;
                data.date1 = "";

                data.sign_name2 = "";
                data.name2 = apv1;
                data.position2 = apv1pos;
                data.date2 = "";

                data.sign_name22 = "";
                data.name22 = apv1_2;
                data.date22 = "";

                data.sign_name3 = "";
                data.name3 = apv2;
                data.position3 = apv2pos;
                data.date3 = "";

                data.sign_name4 = "";
                data.name4 = apv3;
                data.position4 = apv3pos;
                data.date4 = "";

                data.sign_name5 = "";
                data.name5 = apv4;
                data.position5 = apv4pos;
                data.date5 = "";
                data.cb1 = "";
                data.cb2 = "";
                data.remark5 = "";
            }
            System.Data.DataTable dtStr = zreplaceinsnew.BindTagData(pid, data);

            #region Sample ReplaceTable
            System.Data.DataTable dtProperties1 = new System.Data.DataTable();
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
            dr["header_align"] = "Middle";
            dr["header_valign"] = "Center";
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
            dr["col_name"] = "Sum Insured";
            dr["col_width"] = "200";
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

            System.Data.DataTable dt = zreplaceinsnew.genTagTableData(lblPID.Text);
            #endregion

            // Convert to JSONString
            System.Data.DataTable dtTagPropsTable = new System.Data.DataTable();
            dtTagPropsTable.Columns.Add("tagname", typeof(string));
            dtTagPropsTable.Columns.Add("jsonstring", typeof(string));

            System.Data.DataTable dtTagDataTable = new System.Data.DataTable();
            dtTagDataTable.Columns.Add("tagname", typeof(string));
            dtTagDataTable.Columns.Add("jsonstring", typeof(string));
            ReplaceDocx.Class.ReplaceDocx repl = new ReplaceDocx.Class.ReplaceDocx();
            var jsonDTStr = repl.DataTableToJSONWithStringBuilder(dtStr);
            var jsonDTProperties1 = repl.DataTableToJSONWithStringBuilder(dtProperties1);
            var jsonDTdata = repl.DataTableToJSONWithStringBuilder(dt);

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
            //// Dowload Word 
            //Response.Clear();
            //Response.ContentType = "text/xml";
            //Response.AddHeader("content-disposition", $"attachment; filename={outputfn}");
            //Response.BinaryWrite(outputbyte);
            //Response.ContentEncoding = System.Text.Encoding.UTF8;
            //Response.End();
        }

    }
}