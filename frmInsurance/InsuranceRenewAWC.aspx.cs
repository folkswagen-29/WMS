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

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceRenewAWC : System.Web.UI.Page
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
                    setData(id);
                }
                
            }
        }

        private void setData(string id)
        {
            ucHeader1.setHeader("AWCRenew Insurance Memo");

            iniData(id);

            string pid = zwf.iniPID("LEGALWF");
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucCommentlog1.ini_object(pid);
        }

        #region gv1
        public void iniData(string id)
        {
            var dt = iniDataTable(id);
            gv1.DataSource = dt;
            gv1.DataBind();

        }
        public DataTable iniDataTable(string id)
        {
            //getData
            var dt = iniDTStructure();
            var dr = dt.NewRow();

            //var dt_top_ins = GetTypeOfPropertyInsured();
            var dt_sum = GetSumInsurance(id);

            //if (dt_top_ins.Rows.Count > 0)
            //{
            //    int no = 0;

            //    foreach (DataRow dr_ins in dt_top_ins.Rows)
            //    {
            //        dr = dt.NewRow();
            //        dr["TYPE_PROP"] = (no + 1);
            //        dr["IAR"] = dr_ins["top_ins_desc"].ToString();
            //        dr["BI"] = "";
            //        dr["CGL_PL"] = "";
            //        dr["PV"] = "";
            //        dr["LPG"] = "";
            //        dr["D_O"] = dr_ins["top_ins_code"].ToString();
            //        dt.Rows.Add(dr);

            //        no++;
            //    }
            //}
            if (dt_sum.Rows.Count > 0)
            {
                foreach (DataRow dr_sum in dt_sum.Rows)
                {
                    dr = dt.NewRow();
                    dr["TYPE_PROP"] = dr_sum["TYPE_PROP"].ToString();
                    dr["IAR"] = dr_sum["IAR"].ToString();
                    dr["BI"] = dr_sum["BI"].ToString();
                    dr["CGL_PL"] = dr_sum["CGL_PL"].ToString();
                    dr["PV"] = dr_sum["PV"].ToString();
                    dr["LPG"] = dr_sum["LPG"].ToString();
                    dr["D_O"] = dr_sum["D_O"].ToString();
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
        public DataTable iniDTStructure()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TYPE_PROP", typeof(string));
            dt.Columns.Add("IAR", typeof(string));
            dt.Columns.Add("BI", typeof(string));
            dt.Columns.Add("CGL_PL", typeof(string));
            dt.Columns.Add("PV", typeof(string));
            dt.Columns.Add("LPG", typeof(string));
            dt.Columns.Add("D_O", typeof(string));
            return dt;
        }
        public DataTable GetTypeOfPropertyInsured()
        {
            string sql = "select * from li_type_of_property_insured order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        public DataTable GetSumInsurance(string id)
        {
            string sql = @"SELECT * FROM 
                            (
                            VALUES ('Commercial',
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as IAR from li_insurance_req_property_insured where top_ins_code = '01' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '01' and '06' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as BI from li_insurance_req_property_insured where top_ins_code = '02' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '01' and '06' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as CGL_PL from li_insurance_req_property_insured where top_ins_code = '03' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '01' and '06' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as PV from li_insurance_req_property_insured where top_ins_code = '04' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '01' and '06' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as LPG from li_insurance_req_property_insured where top_ins_code = '05' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '01' and '06' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as D_O from li_insurance_req_property_insured where top_ins_code = '06' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '01' and '06' and req_no in (" + id+ @")))
	                               ),('Retail&Wholesale',
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as IAR from li_insurance_req_property_insured where top_ins_code = '01' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '07' and '14' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as BI from li_insurance_req_property_insured where top_ins_code = '02' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '07' and '14' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as CGL_PL from li_insurance_req_property_insured where top_ins_code = '03' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '07' and '14' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as PV from li_insurance_req_property_insured where top_ins_code = '04' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '07' and '14' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as LPG from li_insurance_req_property_insured where top_ins_code = '05' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '07' and '14' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as D_O from li_insurance_req_property_insured where top_ins_code = '06' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '07' and '14' and req_no in (" + id+ @")))
	                               ),('Hospitality',
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as IAR from li_insurance_req_property_insured where top_ins_code = '01' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '15' and '46' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as BI from li_insurance_req_property_insured where top_ins_code = '02' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '15' and '46' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as CGL_PL from li_insurance_req_property_insured where top_ins_code = '03' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '15' and '46' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as PV from li_insurance_req_property_insured where top_ins_code = '04' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '15' and '46' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as LPG from li_insurance_req_property_insured where top_ins_code = '05' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '15' and '46' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as D_O from li_insurance_req_property_insured where top_ins_code = '06' and req_no in (select req_no from li_insurance_request where toreq_code='07' and bu_code between '15' and '46' and req_no in (" + id+ @")))
	                               ),('AWC',
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as IAR from li_insurance_req_property_insured where top_ins_code = '01' and req_no in (select req_no from li_insurance_request where toreq_code='07' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as BI from li_insurance_req_property_insured where top_ins_code = '02' and req_no in (select req_no from li_insurance_request where toreq_code='07' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as CGL_PL from li_insurance_req_property_insured where top_ins_code = '03' and req_no in (select req_no from li_insurance_request where toreq_code='07' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as PV from li_insurance_req_property_insured where top_ins_code = '04' and req_no in (select req_no from li_insurance_request where toreq_code='07' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as LPG from li_insurance_req_property_insured where top_ins_code = '05' and req_no in (select req_no from li_insurance_request where toreq_code='07' and req_no in (" + id+ @"))),
		                            (select format(isnull(sum(cast(suminsured as int)),0), '##,##0') as D_O from li_insurance_req_property_insured where top_ins_code = '06' and req_no in (select req_no from li_insurance_request where toreq_code='07' and req_no in (" + id+@")))
	                               )
                            )sum_renew_Insurance(TYPE_PROP,IAR,BI,CGL_PL,PV,LPG,D_O)";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }
        #endregion

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {
            GenDocumnet();
        }

        private void GenDocumnet()
        {
            // Replace Doc
            var xreq_date = DateTime.Now;
            var xreq_no = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            var xcompany_name = company_name.Text.ToString();
            var xdoc_no = doc_no.Text.Trim();
            var xsubject = subject.Text.Trim();
            var xto = to.Text.Trim();
            var xdescription = description.Text.Trim();
            var xapprove_des = "We, therefore, request for your approval to renew mentioned insurance policy.";

            string templatefile = @"C:\WordTemplate\Insurance\InsuranceTemplateRenew.docx";
            string outputfoler = @"C:\WordTemplate\Insurance\Output";
            string outputfn = outputfoler + @"\inreq_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

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
            dr0["tagvalue"] = Utillity.ConvertDateToLongDateTime(xreq_date, "en");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#objective#";
            dr0["tagvalue"] = xdescription.Replace(",", "!comma");
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


            #endregion
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int res = SaveRenewRequest();

            if (res > 0)
            {
                // wf save draft
                string process_code = "INR_RENEW";
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
                    wfAttr.assto_login = emp.next_line_mgr_login;
                    wfAttr.wf_status = "SAVE";
                    wfAttr.submit_answer = "SAVE";
                    //wfAttr.next_assto_login = emp.next_line_mgr_login;
                    wfAttr.submit_by = emp.user_login;
                    wfAttr.next_assto_login = zwf.findNextStep_Assignee(wfAttr.process_code, wfAttr.step_name, emp.user_login, wfAttr.submit_by);
                    //wfAttr.submit_by = wfAttr.submit_by;

                    // wf.updateProcess
                    var wfA_NextStep = zwf.updateProcess(wfAttr);

                }
                Response.Write("<script>alert('Successfully added');</script>");
                //Response.Redirect("/frmInsurance/InsuranceRenewRequestList");
                //Response.Redirect("/frmInsurance/InsuranceRenewRequestEdit.aspx?id=" + req_no.Text.Trim());
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }

        }

        private int SaveRenewRequest()
        {
            int ret = 0;
            if (doc_no.Text.Trim() == "")
            {
                doc_no.Text = zwf.genDocNo("MEMO-" + System.DateTime.Now.ToString("yyyy", new CultureInfo("en-US")) + "-", 5);
            }
            var xreq_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            //var xprocess_id = string.Format("{0:000000}", (GetMaxProcessID() + 1));
            var xprocess_id = hid_PID.Value.ToString();
            var xcompany_name = company_name.Text.ToString();
            var xdoc_no = doc_no.Text.Trim();
            var xsubject = subject.Text.Trim();
            var xto = to.Text.Trim();
            var xdescription = description.Text.Trim();


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

            //string sql = @"INSERT INTO [dbo].[li_insurance_request]
            //                       ([process_id],[req_no],[req_date],[toreq_code],[company_name],[document_no],[subject],[dear],[objective],[reason],[status],[bu_code],[property_insured_name])
            //                 VALUES
            //                       ('" + xprocess_id + @"'
            //                       ,'" + xreq_no + @"'
            //                       ,'" + xreq_date + @"'
            //                       ,'" + xtype_req + @"'
            //                       ,'" + xcompany_name + @"'
            //                       ,'" + xdoc_no + @"'
            //                       ,'" + xsubject + @"'
            //                       ,'" + xto + @"'
            //                       ,'" + xpurpose + @"'
            //                       ,'" + xbackground + @"'
            //                       ,'" + xstatus + @"'
            //                       ,'" + xbu_code + @"'
            //                       ,'" + xprop_ins_name + @"')";

            //ret = zdb.ExecNonQueryReturnID(sql, zconnstr);

            //if (ret > 0)
            //{
            //    if (listInsurancePropData.Count > 0)
            //    {
            //        foreach (var item in listInsurancePropData)
            //        {
            //            string sqlInsertPropIns = @"INSERT INTO [dbo].[li_insurance_req_property_insured]
            //                                       ([req_no],[top_ins_code],[indemnityperiod],[suminsured],[startdate],[enddate],[created_datetime])
            //                                 VALUES
            //                                       ('" + xreq_no + @"'
            //                                       ,'" + item.TypeOfPropertyInsured + @"'
            //                                       ,'" + item.IndemnityPeriod + @"'
            //                                       ,'" + item.SumInsured + @"'
            //                                       ,'" + item.StartDate + @"'
            //                                       ,'" + item.EndDate + @"'
            //                                       ,'" + xreq_date + @"')";

            //            ret = zdb.ExecNonQueryReturnID(sqlInsertPropIns, zconnstr);
            //        }
            //    }

            //}

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

        public class SummaryInsurance
        {
            public string TYPE_PROP { get; set; }
            public string IAR { get; set; }
            public string BI { get; set; }
            public string CGL_PL { get; set; }
            public string PV { get; set; }
            public string LPG { get; set; }
            public string D_O { get; set; }
        }
    }
}