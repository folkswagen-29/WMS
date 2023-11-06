using Microsoft.Office.Interop.Word;
using onlineLegalWF.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        //public string zconnstr = ConfigurationSettings.AppSettings["BMPDB"].ToString();
        public string zconnstr = ConfigurationManager.AppSettings["BMPDB"].ToString();
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

            string templatefile = @"C:\WordTemplate\Insurance\InsuranceTemplate2.docx";
            string outputfoler = @"C:\WordTemplate\Insurance\Output";
            string outputfn = outputfoler + @"\inreq_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

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
            dr0["tagname"] = "#company#";
            dr0["tagvalue"] = xcompany.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#to#";
            dr0["tagvalue"] = xto.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#subject#";
            dr0["tagvalue"] = xsubject.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#reqdate#";
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
            var requestor = "คุณรุ่งเรือง วิโรจน์ชีวัน";
            var requestorpos = "Head of Operations";
            var requestordate = System.DateTime.Now.ToString("dd/MM/yyyy");
            var apv1 = "คุณจรูณศักดิ์ นามะฮง";
            var apv1pos = "Insurance Specialist";
            var apv1date = "";
            var apv2 = "คุณชโลทร ศรีสมวงษ์";
            var apv2pos = "Head of Legal";
            var apv2date = "";
            var apv3 = "คุณชยุต อมตวนิช";
            var apv3pos = "Head of Risk Management";
            var apv3date = "";

            var apv4 = "ดร.สิเวศ โรจนสุนทร";
            var apv4pos = "CCO";
            var apv4date = "";
            var apv4cb1 = "";
            var apv4cb2 = "";
            var apv4remark = "";

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

            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#name5#";
            dr0["tagvalue"] = apv4.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#position5#";
            dr0["tagvalue"] = apv4pos.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#date5#";
            dr0["tagvalue"] = apv4date.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#sign_name5#";
            dr0["tagvalue"] = apv4remark.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#cb1#";
            dr0["tagvalue"] = apv4cb1.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#cb2#";
            dr0["tagvalue"] = apv4cb2.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#remark5#";
            dr0["tagvalue"] = apv4remark.Replace(",", "!comma");
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
            //var dataGV = iniDataTable();

            //for (int i = 0; i < dataGV.Rows.Count; i++)
            //{
            //    var drGV = dataGV.Rows[i];

            //    DataRow dr1 = dt.NewRow();
            //    dr1["tagname"] = "#table1#";
            //    dr1["No"] = drGV["No"].ToString();
            //    dr1["Property Insured"] = drGV["PropertyInsured"].ToString();  // "xxxxx";//.Text.Replace(",", "!comma");
            //    dr1["Indemnity Period"] = drGV["IndemnityPeriod"].ToString(); // "1,000,000".Replace(",", "!comma"); ;
            //    dr1["Sum Insured"] = drGV["SumInsured"].ToString();  // "15,000".Replace(",", "!comma"); ;
            //    dr1["Start Date"] = drGV["StartDate"].ToString();
            //    dr1["End Date"] = drGV["EndDate"].ToString();
            //    dt.Rows.Add(dr1);
            //}

            //Assign DataTable for #table#
            DataRow dr1 = dt.NewRow();
            dr1["tagname"] = "#table1#";
            dr1["No"] = "1";
            dr1["Property Insured"] = xtype_pi.Replace(",", "!comma");  // "xxxxx";//.Text.Replace(",", "!comma");
            dr1["Indemnity Period"] = xindemnity_period.Replace(",", "!comma"); // "1,000,000".Replace(",", "!comma"); ;
            dr1["Sum Insured"] = xsum_insured.Replace(",", "!comma");  // "15,000".Replace(",", "!comma"); ;
            dr1["Start Date"] = xstart_date.ToString().Replace(",", "!comma");
            dr1["End Date"] = xend_date.ToString().Replace(",", "!comma");
            dt.Rows.Add(dr1);
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
                                '" + outputfoler + @"', 
                                '" + outputfn + @"',  
                                '" + "0" + @"'
                            ) ";

            zdb.ExecNonQuery(sql, zconnstr);

            var outputbyte = rdoc.ReplaceData2(jsonDTStr, jsonDTProperties1, jsonDTdata, templatefile, outputfoler, outputfn, false);

            repl.convertDOCtoPDF(outputfn, outputfn.Replace(".docx", ".pdf"), false);
            // Dowload Word 
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.AddHeader("content-disposition", $"attachment; filename={outputfn}");
            Response.BinaryWrite(outputbyte);
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.End();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int res = SaveRequest();

            if (res > 0) 
            {
                Response.Write("<script>alert('Successfully added');</script>");
                Response.Redirect("/frmInsurance/InsuranceRequestList");
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }

            
        }

        public DataTable GetTypeOfRequest()
        {
            string sql = "select * from li_type_of_request order by row_sort asc";
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

            var xreq_no = req_no.Text.Trim();
            var xprocess_id = string.Format("{0:000000}", (GetMaxProcessID() + 1));
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

            string sql = @"INSERT INTO [dbo].[li_insurance_request]
                                   ([process_id],[req_no],[req_date],[toreq_code],[company_name],[document_no],[subject],[dear],[objective],[reason],[approved_desc],[status])
                             VALUES
                                   ('"+ xprocess_id + @"'
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
                                   ,'"+ xstatus + @"')";

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
            }


            return ret;
        }
    }
}