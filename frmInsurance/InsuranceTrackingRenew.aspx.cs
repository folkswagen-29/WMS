using Newtonsoft.Json.Linq;
using onlineLegalWF.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceTrackingRenew : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setDataTrackingRenew();
            }
        }

        public void setDataTrackingRenew() 
        {
            ucHeader1.setHeader("Tracking Renew");
            string sqlreqres = "select req.process_id,req.req_no,req.req_date,req.[status],bu.bu_desc from li_insurance_request as req inner join li_business_unit as bu on bu.bu_code = req.bu_code where req.toreq_code='02'";

            var reqres = zdb.ExecSql_DataTable(sqlreqres, zconnstr);

            if (reqres.Rows.Count > 0)
            {
                List<InsuranceRequestResponse> listRequestResponse = new List<InsuranceRequestResponse>();

                foreach (DataRow drReq in reqres.Rows)
                {
                    InsuranceRequestResponse requestResponse = new InsuranceRequestResponse();
                    requestResponse.ProcressID = drReq["process_id"].ToString();
                    requestResponse.RequestNo = drReq["req_no"].ToString();
                    requestResponse.BuName = drReq["bu_desc"].ToString();
                    requestResponse.Status = drReq["status"].ToString();
                    requestResponse.RequestDate = Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(drReq["req_date"]), "en");

                    string sqlreqinsres = "select reqpropins.req_no,reqpropins.suminsured,tofins.top_ins_code,top_ins_desc from [dbo].[li_insurance_req_property_insured] as reqpropins inner join li_type_of_property_insured as tofins on tofins.top_ins_code = reqpropins.top_ins_code where req_no='" + drReq["req_no"].ToString() + "'";

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


                }

                ListView1.DataSource = listRequestResponse;
                ListView1.DataBind();
            }
        }

        public class InsuranceRequestResponse
        {
            public string ProcressID { get; set; }
            public string RequestNo { get; set; }
            public string BuName { get; set; }
            public string Status { get; set; }
            public string RequestDate { get; set; }
            public string IARSumInsured { get; set; }
            public string BISumInsured { get; set; }
            public string CGLPLSumInsured { get; set; }
            public string PVSumInsured { get; set; }
            public string LPGSumInsured { get; set; }
            public string DOSumInsured { get; set; }
        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            List<string> listreq_no = new List<string>();
            foreach (ListViewItem row in ListView1.Items)
            {
                CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                if (cb != null)
                {
                    if (cb.Checked == true)
                    {
                        HiddenField xreq_no = (HiddenField)row.FindControl("req_no");
                        if (xreq_no != null)
                        {
                            string refreq_no = xreq_no.Value;
                            listreq_no.Add(refreq_no);
                        }
                    }
                }
            }

            string reslistreq_no = string.Join(", ", listreq_no);
        }
    }
}