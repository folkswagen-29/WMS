using DocumentFormat.OpenXml.Office2010.Excel;
using onlineLegalWF.Class;
using onlineLegalWF.userControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmLitigation
{
    public partial class LitigationCaseDetail : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public string zconnstrrpa = ConfigurationManager.AppSettings["RPADB"].ToString();
        public WFFunctions zwf = new WFFunctions();
        public ReplaceLitigation zreplacelitigation = new ReplaceLitigation();
        public SendMail zsendmail = new SendMail();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
        }

        private void setData(string id)
        {
            ucHeader1.setHeader("Case Detail");

            string sqldetail = "select * from li_litigation_casedetail where case_no='"+id+"'";
            var resdetail = zdb.ExecSql_DataTable(sqldetail, zconnstr);
            hid_case_no.Value = id;
            string xcase_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            if (resdetail.Rows.Count > 0)
            {
                case_no.Text = resdetail.Rows[0]["case_no"].ToString();
                court.Text = resdetail.Rows[0]["dt_court"].ToString();
                city.Text = resdetail.Rows[0]["dt_city"].ToString();
                county.Text = resdetail.Rows[0]["dt_county"].ToString();
                judge.Text = resdetail.Rows[0]["dt_judge"].ToString();
                case_desc.Text = resdetail.Rows[0]["dt_case_desc"].ToString();
                plaintiff.Text = resdetail.Rows[0]["dt_plaintiff_name"].ToString();
                plaintiff_attorney.Text = resdetail.Rows[0]["dt_plaintiff_attorney_name"].ToString();
                defendant.Text = resdetail.Rows[0]["dt_defendant_name"].ToString();
                defendant_attorney.Text = resdetail.Rows[0]["dt_defendant_attorney_name"].ToString();
                filing_date.Text = Convert.ToDateTime(resdetail.Rows[0]["dt_filing_date"]).ToString("yyyy-MM-dd");
                trial_date.Text = Convert.ToDateTime(resdetail.Rows[0]["dt_trial_date"]).ToString("yyyy-MM-dd");

            }
            else 
            {
                case_no.Text = xcase_no;
            }

            getTaskDetail(id);

            string mode = Request.QueryString["mode"];

            if (mode == "view") 
            {
                court.Enabled = false;
                city.Enabled = false;
                county.Enabled = false;
                judge.Enabled = false;
                case_desc.Enabled = false;
                plaintiff.Enabled = false;
                plaintiff_attorney.Enabled = false;
                defendant.Enabled = false;
                defendant_attorney.Enabled = false;
                filing_date.Enabled = false;
                trial_date.Enabled = false;
                btn_task.Enabled = false;
                btn_update.Enabled = false;
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            int res = UpdateRequest();

            if (res > 0)
            {
                Response.Write("<script>alert('Successfully Update');</script>");
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
        }

        protected void btn_task_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalEditData();", true);
        }

        protected void btn_update_task_Click(object sender, EventArgs e)
        {
            var xcase_no = hid_case_no.Value;
            var xtask = task.Text.Trim();
            var xres_by = ddlResbyList.SelectedValue;
            var xplan_date = plan_date.Text.Trim();
            var xplan_desc = plan_desc.Text.Trim();
            var xactual_date = actual_date.Text.Trim();
            var xactual_desc = actual_desc.Text.Trim();
            var xstatus = status.Text.Trim();
            var xnextaction_desc = nextaction_desc.Text.Trim();
            var xupdate_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sqltask = @"INSERT INTO [li_litigation_taskdetail]
                                   ([case_no]
                                   ,[task]
                                   ,[res_by]
                                   ,[plan_date]
                                   ,[plan_desc]
                                   ,[actual_date]
                                   ,[actual_desc]
                                   ,[status]
                                   ,[nextaction_desc]
                                   ,[updated_datetime])
                             VALUES
                                   ('"+xcase_no+ @"'
                                   ,'"+xtask+@"'
                                   ,'"+xres_by+@"'
                                   ,'"+xplan_date+@"'
                                   ,'"+xplan_desc+@"'
                                   ,'"+xactual_date+@"'
                                   ,'"+xactual_desc+@"'
                                   ,'"+xstatus+@"'
                                   ,'"+xnextaction_desc+@"'
                                   ,'"+xupdate_date+"')";
            int ret = zdb.ExecNonQueryReturnID(sqltask, zconnstr);
            if (ret > 0)
            {
                Response.Write("<script>alert('Successfully Update');</script>");
                getTaskDetail(xcase_no);

                //send Email to Requester
                string sqlcase = @"select req.process_id,req_case.req_no,req_case.case_no,req.lit_subject,req.document_no from li_litigation_req_case as req_case 
                                  inner join li_litigation_request as req on req.req_no = req_case.req_no
                                  where req_case.case_no = '"+hid_case_no.Value+"'";
                var rescase = zdb.ExecSql_DataTable(sqlcase, zconnstr);

                if (rescase.Rows.Count > 0) 
                {
                    string title = rescase.Rows[0]["lit_subject"].ToString();
                    string doc_no = rescase.Rows[0]["document_no"].ToString();
                    string req_no = rescase.Rows[0]["req_no"].ToString();
                    string pid = rescase.Rows[0]["process_id"].ToString();

                    string sqlwf = @"SELECT process_id,MAX(row_id) as row_id,submit_by
                                    FROM wf_routing where process_id = '"+ pid +@"'
                                    GROUP BY process_id,submit_by";
                    var reswf = zdb.ExecSql_DataTable(sqlwf, zconnstr);
                    string submit_by = "";
                    if (reswf.Rows.Count > 0) 
                    {
                        submit_by = reswf.Rows[0]["submit_by"].ToString();

                        string subject = title;
                        var host_url_sendmail = ConfigurationManager.AppSettings["host_url"].ToString();
                        string body = "มีการอัพเดทสถานะรายการเอกสารเลขที่ " + doc_no + " กรุณาตรวจสอบผ่านระบบ <a target='_blank' href='" + host_url_sendmail + "frmlitigation/litigationcasedetail.aspx?id=" + xcase_no +"&mode=view'>Click</a>";

                        string pathfileins = "";

                        string sqlfile = "select top 1 * from z_replacedocx_log where replacedocx_reqno='" + req_no + "' order by row_id desc";

                        var resfile = zdb.ExecSql_DataTable(sqlfile, zconnstr);

                        if (resfile.Rows.Count > 0)
                        {
                            pathfileins = resfile.Rows[0]["output_filepath"].ToString().Replace(".docx", ".pdf");

                            string email = "";

                            var isdev = ConfigurationManager.AppSettings["isDev"].ToString();
                            ////get mail from db
                            /////send mail to next_approve
                            if (isdev != "true")
                            {
                                string sqlbpm = "select * from li_user where user_login = '" + submit_by + "' ";
                                System.Data.DataTable dtbpm = zdb.ExecSql_DataTable(sqlbpm, zconnstr);

                                if (dtbpm.Rows.Count > 0)
                                {
                                    email = dtbpm.Rows[0]["email"].ToString();

                                }
                                else
                                {
                                    string sqlpra = "select * from Rpa_Mst_HrNameList where Login = 'ASSETWORLDCORP-\\" + submit_by + "' ";
                                    System.Data.DataTable dtrpa = zdb.ExecSql_DataTable(sqlpra, zconnstrrpa);

                                    if (dtrpa.Rows.Count > 0)
                                    {
                                        email = dtrpa.Rows[0]["Email"].ToString();
                                    }
                                    else
                                    {
                                        email = "";
                                    }

                                }
                            }
                            else
                            {
                                ////fix mail test
                                email = "legalwfuat2024@gmail.com";
                            }

                            if (!string.IsNullOrEmpty(email))
                            {
                                _ = zsendmail.sendEmail("Update " +subject + " Mail To Requester", email, body, pathfileins);
                            }

                        }
                    }
                }
            }
            else 
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
        }

        private void getTaskDetail(string id)
        {
            string sql = "select * from li_litigation_taskdetail where case_no='"+id+"'";
            var res = zdb.ExecSql_DataTable(sql, zconnstr);

            if (res.Rows.Count > 0) 
            {
                int no = 0;
                List<TaskDetailData> listTaskDetailData = new List<TaskDetailData>();
                foreach (DataRow item in res.Rows) 
                {
                    TaskDetailData taskDetailData = new TaskDetailData();
                    taskDetailData.no = (no + 1);
                    taskDetailData.case_no = item["case_no"].ToString();
                    taskDetailData.task = item["task"].ToString();
                    taskDetailData.res_by = item["res_by"].ToString();
                    taskDetailData.plan_date = Convert.ToDateTime(item["plan_date"].ToString());
                    taskDetailData.plan_desc = item["plan_desc"].ToString();
                    taskDetailData.actual_date = Convert.ToDateTime(item["actual_date"].ToString());
                    taskDetailData.actual_desc = item["actual_desc"].ToString();
                    taskDetailData.status = item["status"].ToString();
                    taskDetailData.nextaction_desc = item["nextaction_desc"].ToString();
                    listTaskDetailData.Add(taskDetailData);
                    no++;
                }
                gvTask.DataSource = listTaskDetailData;
                gvTask.DataBind();

                section_task.Visible = true;
            }

        }
        private int UpdateRequest()
        {
            int ret = 0;

            string sqldetail = "select * from li_litigation_casedetail where case_no='" + hid_case_no.Value + "'";
            var resdetail = zdb.ExecSql_DataTable(sqldetail, zconnstr);

            string sql = "";

            var xcase_no = hid_case_no.Value;
            var xdt_case_no = case_no.Text.Trim();
            var xdt_court = court.Text.Trim();
            var xdt_city = city.Text.Trim();
            var xdt_county = county.Text.Trim();
            var xdt_judge = judge.Text.Trim();
            var xdt_case_desc = case_desc.Text.Trim();
            var xdt_plaintiff = plaintiff.Text.Trim();
            var xdt_plaintiff_attorney = plaintiff_attorney.Text.Trim();
            var xdt_defendant = defendant.Text.Trim();
            var xdt_defendant_attorney = defendant_attorney.Text.Trim();
            var xdt_filing_date = filing_date.Text.Trim();
            var xdt_trial_date = trial_date.Text.Trim();
            var xupdate_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xstatus = "verify";

            if (resdetail.Rows.Count > 0)
            {
                sql = @"UPDATE [li_litigation_casedetail]
                       SET [dt_case_no] = '"+xdt_case_no+@"'
                          ,[dt_court] = '"+xdt_court+@"'
                          ,[dt_city] = '"+xdt_city+@"'
                          ,[dt_county] = '"+xdt_county+@"'
                          ,[dt_judge] = '"+xdt_judge+@"'
                          ,[dt_case_desc] = '"+xdt_case_desc+@"'
                          ,[dt_plaintiff_name] = '"+xdt_plaintiff+@"'
                          ,[dt_plaintiff_attorney_name] = '"+xdt_plaintiff_attorney+@"'
                          ,[dt_defendant_name] = '"+xdt_defendant+@"'
                          ,[dt_defendant_attorney_name] = '"+xdt_defendant_attorney+@"'
                          ,[dt_filing_date] = '"+xdt_filing_date+@"'
                          ,[dt_trial_date] = '"+xdt_trial_date+@"'
                          ,[dt_status] = '"+xstatus+@"'
                          ,[updated_datetime] = '"+xupdate_date+@"'
                     WHERE [case_no] = '"+xcase_no+"'";
            }
            else 
            {
                sql = @"INSERT INTO [dbo].[li_litigation_casedetail]
                               ([case_no],[dt_case_no],[dt_court],[dt_city],[dt_county],[dt_judge],[dt_case_desc],[dt_plaintiff_name],[dt_plaintiff_attorney_name],[dt_defendant_name]
                                ,[dt_defendant_attorney_name],[dt_filing_date],[dt_trial_date],[dt_status],[updated_datetime])
                         VALUES
                               ('"+xcase_no+@"'
                               ,'"+xdt_case_no+@"'
                               ,'"+xdt_court+@"'
                               ,'"+xdt_city+@"'
                               ,'"+xdt_county+@"'
                               ,'"+xdt_judge+@"'
                               ,'"+xdt_case_desc+@"'
                               ,'"+xdt_plaintiff+@"'
                               ,'"+xdt_plaintiff_attorney+@"'
                               ,'"+xdt_defendant+@"'
                               ,'"+xdt_defendant_attorney+@"'
                               ,'"+xdt_filing_date+@"'
                               ,'"+xdt_trial_date+@"'
                               ,'"+xstatus+@"'
                               ,'"+xupdate_date+"')";
            }

            ret = zdb.ExecNonQueryReturnID(sql, zconnstr);

            return ret;
        }

        //protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "openModal")
        //    {
        //        int i = System.Convert.ToInt32(e.CommandArgument);
        //        string sql = @"select req_case.req_no,req_case.case_no,req.lit_subject,req.document_no from li_litigation_req_case as req_case 
        //                          inner join li_litigation_request as req on req.req_no = req_case.req_no
        //                          where req_case.case_no = '"+hid_case_no.Value+"' ";
        //        //var xcase_no = ((HiddenField)gvExcelFile.Rows[i].FindControl("gv_case_no")).Value;
        //        //var xcontract_no = ((Label)gvExcelFile.Rows[i].FindControl("gv_contract_no")).Text;
        //        //var xcustomer_no = ((Label)gvExcelFile.Rows[i].FindControl("gv_customer_no")).Text;
        //        //var xcustomer_name = ((Label)gvExcelFile.Rows[i].FindControl("gv_customer_name")).Text;

        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalEditData();", true);
        //    }
        //}

        public class TaskDetailData
        {
            public int no { get; set; }
            public string case_no { get; set; }
            public string task { get; set; }
            public string res_by { get; set; }
            public DateTime plan_date { get; set; }
            public string plan_desc { get; set; }
            public DateTime actual_date { get; set; }
            public string actual_desc { get; set; }
            public string status { get; set; }
            public string nextaction_desc { get; set; }
        }
    }
}