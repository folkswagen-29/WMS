using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using onlineLegalWF.Class;
using System.Configuration;
using System.Globalization;

namespace onlineLegalWF.frmLitigation
{
    public partial class LitigationRequestEditByAdmin : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        //public string zconnstr = ConfigurationSettings.AppSettings["BPMDB"].ToString();
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
            ucHeader1.setHeader("Litigation Edit Request");

            type_req.DataSource = GetTypeOfRequest();
            type_req.DataBind();
            type_req.DataTextField = "tof_litigationreq_desc";
            type_req.DataValueField = "tof_litigationreq_code";
            type_req.DataBind();

            string sql = "select * from li_litigation_request where process_id='" + id + "'";

            var res = zdb.ExecSql_DataTable(sql, zconnstr);
            if (res.Rows.Count > 0)
            {

                req_no.Text = res.Rows[0]["req_no"].ToString();
                req_date.Value = Convert.ToDateTime(res.Rows[0]["req_date"]).ToString("yyyy-MM-dd");
                doc_no.Text = res.Rows[0]["document_no"].ToString();
                type_req.SelectedValue = res.Rows[0]["tof_litigationreq_code"].ToString();
                if (type_req.SelectedValue == "01")
                {
                    row_gv_data.Visible = true;
                }
                else
                {
                    row_gv_data.Visible = false;
                }
                subject.Text = res.Rows[0]["lit_subject"].ToString();
                desc.Text = res.Rows[0]["lit_desc"].ToString();

                string sqlcase = "select * from li_litigation_req_case where req_no='" + res.Rows[0]["req_no"].ToString() + "'";
                var rescase = zdb.ExecSql_DataTable(sqlcase, zconnstr);

                if (rescase.Rows.Count > 0)
                {
                    List<LitigationCivilCaseData> listCivilCaseData = new List<LitigationCivilCaseData>();
                    foreach (DataRow item in rescase.Rows)
                    {
                        LitigationCivilCaseData civilCaseData = new LitigationCivilCaseData();
                        civilCaseData.req_no = item["req_no"].ToString();
                        civilCaseData.case_no = item["case_no"].ToString();
                        civilCaseData.no = item["no"].ToString();
                        civilCaseData.contract_no = item["contract_no"].ToString();
                        civilCaseData.bu_name = item["bu_name"].ToString();
                        civilCaseData.customer_no = item["customer_no"].ToString();
                        civilCaseData.customer_name = item["customer_name"].ToString();
                        civilCaseData.customer_room = item["customer_room"].ToString();
                        civilCaseData.overdue_desc = item["overdue_desc"].ToString();
                        civilCaseData.outstanding_debt = item["outstanding_debt"].ToString();
                        civilCaseData.outstanding_debt_ack_of_debt = item["outstanding_debt_ack_of_debt"].ToString();
                        civilCaseData.fine_debt = item["fine_debt"].ToString();
                        civilCaseData.total_net = item["total_net"].ToString();
                        civilCaseData.retention_money = item["retention_money"].ToString();
                        civilCaseData.total_after_retention_money = item["total_after_retention_money"].ToString();
                        civilCaseData.remark = item["remark"].ToString();
                        civilCaseData.status = item["status"].ToString();
                        civilCaseData.assto_login = item["assto_login"].ToString();
                        listCivilCaseData.Add(civilCaseData);
                    }
                    gvExcelFile.DataSource = listCivilCaseData;
                    gvExcelFile.DataBind();
                }

                string pid = res.Rows[0]["process_id"].ToString();
                lblPID.Text = pid;
                hid_PID.Value = pid;
                ucAttachment1.ini_object(pid);
                ucCommentlog1.ini_object(pid);
            }
        }

        public DataTable GetTypeOfRequest()
        {
            string sql = "select * from li_type_of_litigationrequest order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        public class LitigationCivilCaseData
        {
            public string req_no { get; set; }
            public string case_no { get; set; }
            public string no { get; set; }
            public string contract_no { get; set; }
            public string bu_name { get; set; }
            public string customer_no { get; set; }
            public string customer_name { get; set; }
            public string customer_room { get; set; }
            public string overdue_desc { get; set; }
            public string outstanding_debt { get; set; }
            public string outstanding_debt_ack_of_debt { get; set; }
            public string fine_debt { get; set; }
            public string total_net { get; set; }
            public string retention_money { get; set; }
            public string total_after_retention_money { get; set; }
            public string remark { get; set; }
            public string status { get; set; }
            public string assto_login { get; set; }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "openModal")
            {
                int i = System.Convert.ToInt32(e.CommandArgument);
                //var xreq_no = ((HiddenField)gvExcelFile.Rows[i].FindControl("gv_req_no")).Value;
                var xcase_no = ((HiddenField)gvExcelFile.Rows[i].FindControl("gv_case_no")).Value;
                var xcontract_no = ((Label)gvExcelFile.Rows[i].FindControl("gv_contract_no")).Text;
                var xcustomer_no = ((Label)gvExcelFile.Rows[i].FindControl("gv_customer_no")).Text;
                var xcustomer_name = ((Label)gvExcelFile.Rows[i].FindControl("gv_customer_name")).Text;

                ucLitigationCaseAttachment1.ini_object(xcase_no, xcontract_no, xcustomer_no, xcustomer_name);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalEditData();", true);
            }
        }

    }
}