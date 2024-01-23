﻿using onlineLegalWF.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static onlineLegalWF.Class.ReplaceInsRenewAWC;

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceRenewAWCEdit : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public WFFunctions zwf = new WFFunctions();
        public ReplaceInsRenewAWC zreplaceinsrenewawc = new ReplaceInsRenewAWC();
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
            ucHeader1.setHeader("AWCRenew Insurance Memo Edit");

            iniData(id);

            string pid = id;
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucCommentlog1.ini_object(pid);

            string sqlmemo = @"select * from li_insurance_renew_awc_memo where process_id = '" + id + "'";
            DataTable dt = zdb.ExecSql_DataTable(sqlmemo, zconnstr);

            if (dt.Rows.Count > 0) 
            {
                DataRow dr = dt.Rows[0];

                doc_no.Text = dr["document_no"].ToString();
                to.Text = dr["dear"].ToString();
                company_name.Text = dr["company_name"].ToString();
                subject.Text = dr["subject"].ToString();
                description.Text = dr["description"].ToString();
                req_date.Value = dr["req_date"].ToString();
                hid_reqno.Value = dr["req_no"].ToString();

                string sqlreq = @"select * from li_insurance_renew_awc_memo_req where process_id = '" + id + "'";
                DataTable dtreq = zdb.ExecSql_DataTable(sqlreq, zconnstr);

                if (dtreq.Rows.Count > 0) 
                {
                    List<string> listreq_no = new List<string>();
                    foreach(DataRow drreq in dtreq.Rows) 
                    {
                        string item = "'" + drreq["req_no"].ToString() + "'";
                        listreq_no.Add(item);
                    }

                    string listid = string.Join(", ", listreq_no);
                    bindDataListPropTable(listid);
                }
                
            }
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

            var dt_sum = GetSumInsurance(id);

            if (dt_sum.Rows.Count > 0)
            {
                foreach (DataRow dr_sum in dt_sum.Rows)
                {
                    dr = dt.NewRow();
                    dr["TYPE_PROP"] = dr_sum["type_prop"].ToString();
                    dr["IAR"] = dr_sum["sum_iar"].ToString();
                    dr["BI"] = dr_sum["sum_bi"].ToString();
                    dr["CGL_PL"] = dr_sum["sum_cgl_pv"].ToString();
                    dr["PV"] = dr_sum["sum_pv"].ToString();
                    dr["LPG"] = dr_sum["sum_lpg"].ToString();
                    dr["D_O"] = dr_sum["sum_d_o"].ToString();
                    dr["Row_Sort"] = dr_sum["row_sort"].ToString();
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
            dt.Columns.Add("Row_Sort", typeof(string));
            return dt;
        }

        public DataTable GetSumInsurance(string id)
        {
            string sql = @"select row_sort,type_prop
                                  ,format(isnull(cast(sum_iar as int),0), '##,##0') as sum_iar
                                  ,format(isnull(cast(sum_bi as int),0), '##,##0') as sum_bi
                                  ,format(isnull(cast(sum_cgl_pv as int),0), '##,##0') as sum_cgl_pv
                                  ,format(isnull(cast(sum_pv as int),0), '##,##0') as sum_pv
                                  ,format(isnull(cast(sum_lpg as int),0), '##,##0') as sum_lpg
                                  ,format(isnull(cast(sum_d_o as int),0), '##,##0') as sum_d_o
                            from li_insurance_renew_awc_memo_sumins where process_id = '" + id + "'";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }
        #endregion

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int res = EditRenewRequest();

            if (res > 0)
            {
                Response.Write("<script>alert('Successfully Edited');</script>");
                //Response.Redirect("/frmInsurance/InsuranceRenewAWCEdit.aspx?id=" + lblPID.Text.Trim());
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }

        }

        private int EditRenewRequest()
        {
            int ret = 0;

            var xreq_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xprocess_id = hid_PID.Value.ToString();
            var xfrom = company_name.Text.ToString();
            var xsubject = subject.Text.Trim();
            var xto = to.Text.Trim();
            var xdescription = description.Text.Trim();


            //Get Data from gv1 Sum Insurance Detail
            List<SummaryInsurance> listInsuranceSumData = new List<SummaryInsurance>();
            foreach (GridViewRow row in gv1.Rows)
            {
                SummaryInsurance data = new SummaryInsurance();
                data.TYPE_PROP = (row.FindControl("gv1txtTYPE_PROP") as TextBox).Text;
                data.IAR = (row.FindControl("gv1txtIAR") as TextBox).Text;
                data.BI = (row.FindControl("gv1txtBI") as TextBox).Text;
                data.CGL_PL = (row.FindControl("gv1txtCGL_PL") as TextBox).Text;
                data.PV = (row.FindControl("gv1txtPV") as TextBox).Text;
                data.LPG = (row.FindControl("gv1txtLPG") as TextBox).Text;
                data.D_O = (row.FindControl("gv1txtD_O") as TextBox).Text;
                data.Row_Sort = (row.FindControl("gv1txtRow_Sort") as HiddenField).Value;

                listInsuranceSumData.Add(data);
            }

            string sqlmemo = @"UPDATE [dbo].[li_insurance_renew_awc_memo]
                               SET [dear] = '"+xto+@"'
                                  ,[company_name] = '"+xfrom+@"'
                                  ,[subject] = '"+xsubject+@"'
                                  ,[description] = '"+xdescription+@"'
                                  ,[updated_datetime] = '"+xreq_date+@"'
                             WHERE process_id = '"+xprocess_id+"'";

            ret = zdb.ExecNonQueryReturnID(sqlmemo, zconnstr);

            if (ret > 0)
            {

                if (listInsuranceSumData.Count > 0)
                {
                    string sqlDeletePropIns = @"DELETE FROM [li_insurance_renew_awc_memo_sumins] WHERE process_id='" + xprocess_id + "'";

                    ret = zdb.ExecNonQueryReturnID(sqlDeletePropIns, zconnstr);
                    if (ret > 0) 
                    {
                        foreach (var item in listInsuranceSumData)
                        {
                            string sqlsum = @"INSERT INTO [li_insurance_renew_awc_memo_sumins]
                                           ([process_id],[row_sort],[type_prop],[sum_iar],[sum_bi],[sum_cgl_pv],[sum_pv],[sum_lpg],[sum_d_o])
                                     VALUES
                                           ('" + xprocess_id + @"'
                                           ,'" + item.Row_Sort + @"'
                                           ,'" + item.TYPE_PROP + @"'
                                           ,'" + int.Parse(item.IAR, NumberStyles.AllowThousands) + @"'
                                           ,'" + int.Parse(item.BI, NumberStyles.AllowThousands) + @"'
                                           ,'" + int.Parse(item.CGL_PL, NumberStyles.AllowThousands) + @"'
                                           ,'" + int.Parse(item.PV, NumberStyles.AllowThousands) + @"'
                                           ,'" + int.Parse(item.LPG, NumberStyles.AllowThousands) + @"'
                                           ,'" + int.Parse(item.D_O, NumberStyles.AllowThousands) + "')";

                            ret = zdb.ExecNonQueryReturnID(sqlsum, zconnstr);

                        }
                    }
                    
                }

            }

            return ret;
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
            public string Row_Sort { get; set; }
        }

        public void bindDataListPropTable(string id)
        {
            string sqlreqres = "select req.property_insured_name,req.req_no,req.req_date,req.[status],bu.bu_desc from li_insurance_request as req inner join li_business_unit as bu on bu.bu_code = req.bu_code where req.toreq_code='07' and req_no in (" + id + ")";

            var reqres = zdb.ExecSql_DataTable(sqlreqres, zconnstr);

            if (reqres.Rows.Count > 0)
            {
                List<InsuranceRequestResponse> listRequestResponse = new List<InsuranceRequestResponse>();

                int no = 1;
                foreach (DataRow drReq in reqres.Rows)
                {
                    InsuranceRequestResponse requestResponse = new InsuranceRequestResponse();
                    requestResponse.No = no.ToString();
                    requestResponse.PropertyInsured = drReq["property_insured_name"].ToString();

                    string sqlreqinsres = "select reqpropins.req_no,format(isnull(cast(reqpropins.suminsured as int),0), '##,##0') as suminsured,tofins.top_ins_code,top_ins_desc from [dbo].[li_insurance_req_property_insured] as reqpropins inner join li_type_of_property_insured as tofins on tofins.top_ins_code = reqpropins.top_ins_code where req_no='" + drReq["req_no"].ToString() + "'";

                    var reqinsres = zdb.ExecSql_DataTable(sqlreqinsres, zconnstr);

                    if (reqinsres.Rows.Count > 0)
                    {
                        foreach (DataRow drReqIns in reqinsres.Rows)
                        {
                            var topInsCode = drReqIns["top_ins_code"].ToString();
                            if (topInsCode == "01")
                            {
                                requestResponse.IARSumInsured = drReqIns["suminsured"].ToString();
                            }
                            else if (topInsCode == "02")
                            {
                                requestResponse.BISumInsured = drReqIns["suminsured"].ToString();
                            }
                            else if (topInsCode == "03")
                            {
                                requestResponse.CGLPLSumInsured = drReqIns["suminsured"].ToString();
                            }
                            else if (topInsCode == "04")
                            {
                                requestResponse.PVSumInsured = drReqIns["suminsured"].ToString();
                            }
                            else if (topInsCode == "05")
                            {
                                requestResponse.LPGSumInsured = drReqIns["suminsured"].ToString();
                            }
                            else if (topInsCode == "06")
                            {
                                requestResponse.DOSumInsured = drReqIns["suminsured"].ToString();
                            }
                        }
                    }

                    listRequestResponse.Add(requestResponse);

                    no++;
                }

                gvList.DataSource = listRequestResponse;
                gvList.DataBind();
            }
        }

        public class InsuranceRequestResponse
        {
            public string No { get; set; }
            public string PropertyInsured { get; set; }
            public string IARSumInsured { get; set; }
            public string BISumInsured { get; set; }
            public string CGLPLSumInsured { get; set; }
            public string PVSumInsured { get; set; }
            public string LPGSumInsured { get; set; }
            public string DOSumInsured { get; set; }
        }

        private void GenDocumnet()
        {
            // Replace Doc
            var xreq_date = Utillity.ConvertStringToDate(req_date.Value);
            var xreq_no = hid_reqno.Value;
            var xcompany_name = company_name.Text.ToString();
            var xdoc_no = doc_no.Text.Trim();
            var xsubject = subject.Text.Trim();
            var xto = to.Text.Trim();
            var xdescription = description.Text.Trim();

            string templatefile = @"C:\WordTemplate\Insurance\InsuranceTemplateRenewAWC.docx";
            string outputfolder = @"C:\WordTemplate\Insurance\Output";
            string outputfn = outputfolder + @"\inreq_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

            var rdoc = new ReplaceDocx.Class.ReplaceDocx();

            ReplaceInsReNewAWC_TagData data = new ReplaceInsReNewAWC_TagData();

            #region prepare data
            data.docno = xdoc_no.Replace(",", "!comma");
            data.to = xto.Replace(",", "!comma");
            data.company = xcompany_name.Replace(",", "!comma");
            data.subject = xsubject.Replace(",", "!comma");
            data.reqdate = Utillity.ConvertDateToLongDateTime(xreq_date, "en");
            data.description = xdescription.Replace(",", "!comma");

            var requestor = "";
            var requestorpos = "";

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

            DataTable dtStr = zreplaceinsrenewawc.genTagData(data);

            #endregion 

            #region Sample ReplaceTable
            ////DataTable Column Properties
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
            // Replace #tablesum# ------------------------------------------------------
            DataRow dr = dtProperties1.NewRow();
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "กลุ่มธุรกิจ";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "IAR";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "BI";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "CGL/PL";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "PV";
            dr["col_width"] = "150";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "LPG";
            dr["col_width"] = "150";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "D&O";
            dr["col_width"] = "150";
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

            ////  DataTable dt = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("tagname", typeof(string));
            dt.Columns.Add("TYPE_PROP", typeof(string));
            dt.Columns.Add("IAR", typeof(string));
            dt.Columns.Add("BI", typeof(string));
            dt.Columns.Add("CGL_PL", typeof(string));
            dt.Columns.Add("PV", typeof(string));
            dt.Columns.Add("LPG", typeof(string));
            dt.Columns.Add("D_O", typeof(string));
            dt.Columns.Add("Row_Sort", typeof(string));

            ////DataTable for #tablesum#
            //Get Data from gv1 Insurance sum Detail
            List<SummaryInsurance> listInsuranceSum = new List<SummaryInsurance>();
            foreach (GridViewRow row in gv1.Rows)
            {
                SummaryInsurance datasum = new SummaryInsurance();
                datasum.TYPE_PROP = (row.FindControl("gv1txtTYPE_PROP") as TextBox).Text;
                datasum.IAR = (row.FindControl("gv1txtIAR") as TextBox).Text;
                datasum.BI = (row.FindControl("gv1txtBI") as TextBox).Text;
                datasum.CGL_PL = (row.FindControl("gv1txtCGL_PL") as TextBox).Text;
                datasum.PV = (row.FindControl("gv1txtPV") as TextBox).Text;
                datasum.LPG = (row.FindControl("gv1txtLPG") as TextBox).Text;
                datasum.D_O = (row.FindControl("gv1txtD_O") as TextBox).Text;
                datasum.Row_Sort = (row.FindControl("gv1txtRow_Sort") as HiddenField).Value;

                listInsuranceSum.Add(datasum);

            }
            ////Assign Data From gv1
            var drGV = dt.NewRow();

            if (listInsuranceSum.Count > 0)
            {
                foreach (var item in listInsuranceSum)
                {
                    drGV = dt.NewRow();
                    drGV["tagname"] = "#tablesum#";
                    drGV["TYPE_PROP"] = item.TYPE_PROP.Replace(",", "!comma");
                    drGV["IAR"] = item.IAR.Replace(",", "!comma");
                    drGV["BI"] = item.BI.Replace(",", "!comma");
                    drGV["CGL_PL"] = item.CGL_PL.Replace(",", "!comma");
                    drGV["PV"] = item.PV.Replace(",", "!comma");
                    drGV["LPG"] = item.LPG.Replace(",", "!comma");
                    drGV["D_O"] = item.LPG.Replace(",", "!comma");
                    drGV["Row_Sort"] = item.Row_Sort.Replace(",", "!comma");
                    dt.Rows.Add(drGV);
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
            var jsonDTdata = repl.DataTableToJSONWithStringBuilder(dt);
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

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {
            GenDocumnet();
        }

        private void GenDocumnetInsRenewAWC(string pid)
        {
            // Replace Doc
            string xreq_no = "";

            string templatefile = @"C:\WordTemplate\Insurance\InsuranceTemplateRenewAWC.docx";
            string outputfolder = @"C:\WordTemplate\Insurance\Output";
            string outputfn = outputfolder + @"\inreq_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

            var rdoc = new ReplaceDocx.Class.ReplaceDocx();

            ReplaceInsReNewAWC_TagData data = new ReplaceInsReNewAWC_TagData();

            #region prepare data

            string sqlinsmemo = "select * from li_insurance_renew_awc_memo where process_id='" + pid + "'";
            var resinsmemo = zdb.ExecSql_DataTable(sqlinsmemo, zconnstr);

            if (resinsmemo.Rows.Count > 0)
            {
                xreq_no = resinsmemo.Rows[0]["req_no"].ToString();
            }

            var requestor = "";
            var requestorpos = "";

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

            DataTable dtStr = zreplaceinsrenewawc.BindTagData(pid,data);

            #endregion 

            #region Sample ReplaceTable
            ////DataTable Column Properties
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
            // Replace #tablesum# ------------------------------------------------------
            DataRow dr = dtProperties1.NewRow();
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "กลุ่มธุรกิจ";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "IAR";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "BI";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "CGL/PL";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "PV";
            dr["col_width"] = "150";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "LPG";
            dr["col_width"] = "150";
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
            dr["tagname"] = "#tablesum#";
            dr["col_name"] = "D&O";
            dr["col_width"] = "150";
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

            ////DataTable for #tablesum#
            //Get Data from gv1 Insurance sum Detail
            DataTable dt = zreplaceinsrenewawc.genTagTableData(lblPID.Text);

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
            var jsonDTdata = repl.DataTableToJSONWithStringBuilder(dt);
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
            //Response.Clear();
            //Response.ContentType = "text/xml";
            //Response.AddHeader("content-disposition", $"attachment; filename={outputfn}");
            //Response.BinaryWrite(outputbyte);
            //Response.ContentEncoding = System.Text.Encoding.UTF8;
            //Response.End();


            #endregion
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string process_code = "INR_AWC_RENEW";
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
                wfAttr.wf_status = "SUBMITTED";
                wfAttr.submit_answer = "SUBMITTED";
                wfAttr.submit_by = emp.user_login;
                wfAttr.next_assto_login = zwf.findNextStep_Assignee(wfAttr.process_code, wfAttr.step_name, emp.user_login, wfAttr.submit_by, lblPID.Text);
                wfAttr.updated_by = emp.user_login;

                // wf.updateProcess
                var wfA_NextStep = zwf.updateProcess(wfAttr);
                wfA_NextStep.next_assto_login = zwf.findNextStep_Assignee(wfA_NextStep.process_code, wfA_NextStep.step_name, emp.user_login, wfAttr.submit_by, lblPID.Text);
                string status = zwf.Insert_NextStep(wfA_NextStep);

                if (status == "Success")
                {
                    GenDocumnetInsRenewAWC(lblPID.Text);
                    Response.Redirect("/legalportal/legalportal.aspx?m=myworklist");
                }

            }
        }
    }
}