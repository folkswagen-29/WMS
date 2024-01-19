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
    public partial class InsuranceRenewAWCEdit : System.Web.UI.Page
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
    }
}