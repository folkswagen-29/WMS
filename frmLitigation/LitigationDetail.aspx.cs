using WMS.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.frmLitigation
{
    public partial class LitigationDetail : System.Web.UI.Page
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
            string sql = @"select lit.[process_id],reqcase.[req_no],[case_no],[no],[contract_no],[bu_name],[customer_no],[customer_name],[customer_room],[overdue_desc],[outstanding_debt],[outstanding_debt_ack_of_debt],[fine_debt]
                              ,[total_net],[retention_money],[total_after_retention_money],[remark],reqcase.[status],[assto_login],reqcase.[updated_datetime]
                          from [li_litigation_req_case] as reqcase
                          inner join li_litigation_request as lit on lit.req_no = reqcase.req_no
                          where case_no='" + id + "'";

            var res = zdb.ExecSql_DataTable(sql, zconnstr);
            if (res.Rows.Count > 0)
            {
                List<LitigationCivilCaseData> listCivilCaseData = new List<LitigationCivilCaseData>();

                LitigationCivilCaseData civilCaseData = new LitigationCivilCaseData();
                civilCaseData.req_no = res.Rows[0]["req_no"].ToString();
                civilCaseData.case_no = res.Rows[0]["case_no"].ToString();
                civilCaseData.no = res.Rows[0]["no"].ToString();
                civilCaseData.contract_no = res.Rows[0]["contract_no"].ToString();
                civilCaseData.bu_name = res.Rows[0]["bu_name"].ToString();
                civilCaseData.customer_no = res.Rows[0]["customer_no"].ToString();
                civilCaseData.customer_name = res.Rows[0]["customer_name"].ToString();
                civilCaseData.customer_room = res.Rows[0]["customer_room"].ToString();
                civilCaseData.overdue_desc = res.Rows[0]["overdue_desc"].ToString();
                civilCaseData.outstanding_debt = res.Rows[0]["outstanding_debt"].ToString();
                civilCaseData.outstanding_debt_ack_of_debt = res.Rows[0]["outstanding_debt_ack_of_debt"].ToString();
                civilCaseData.fine_debt = res.Rows[0]["fine_debt"].ToString();
                civilCaseData.total_net = res.Rows[0]["total_net"].ToString();
                civilCaseData.retention_money = res.Rows[0]["retention_money"].ToString();
                civilCaseData.total_after_retention_money = res.Rows[0]["total_after_retention_money"].ToString();
                civilCaseData.remark = res.Rows[0]["remark"].ToString();
                civilCaseData.status = res.Rows[0]["status"].ToString();
                civilCaseData.assto_login = res.Rows[0]["assto_login"].ToString();

                listCivilCaseData.Add(civilCaseData);

                gvExcelFile.DataSource = listCivilCaseData;
                gvExcelFile.DataBind();

                ucHeader1.setHeader("Litigation Detail " + "รหัสลูกค้า "+ res.Rows[0]["customer_no"].ToString() + " ชื่อ "+ res.Rows[0]["customer_name"].ToString());

                ucLitigationCaseAttachment1.ini_object(res.Rows[0]["case_no"].ToString(), res.Rows[0]["contract_no"].ToString(), res.Rows[0]["customer_no"].ToString(), res.Rows[0]["customer_name"].ToString());

                string pid = res.Rows[0]["process_id"].ToString();
                lblPID.Text = pid;
                hid_PID.Value = pid;
                hid_caseNo.Value = res.Rows[0]["case_no"].ToString();
                //ucAttachment1.ini_object(pid);
                //ucCommentlog1.ini_object(pid);
            }
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
            public string url_detail { get; set; }
        }
        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "openModal")
            {
                int i = System.Convert.ToInt32(e.CommandArgument);
                var xcase_no = ((HiddenField)gvExcelFile.Rows[i].FindControl("gv_case_no")).Value.ToString();
                var xcontract_no = ((Label)gvExcelFile.Rows[i].FindControl("gv_contract_no")).Text.ToString();
                var xcustomer_no = ((Label)gvExcelFile.Rows[i].FindControl("gv_customer_no")).Text.ToString();
                var xcustomer_name = ((Label)gvExcelFile.Rows[i].FindControl("gv_customer_name")).Text.ToString();

                ucLitigationCaseAttachment1.ini_object(xcase_no, xcontract_no, xcustomer_no, xcustomer_name);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalEditData();", true);
            }
            else if (e.CommandName == "openModalAssign")
            {
                int i = System.Convert.ToInt32(e.CommandArgument);
                var xcase_no = ((HiddenField)gvExcelFile.Rows[i].FindControl("gv_case_no")).Value.ToString();
                var xassto_login = ((Label)gvExcelFile.Rows[i].FindControl("gv_assto_login")).Text.ToString();
                var xstatus = ((Label)gvExcelFile.Rows[i].FindControl("gv_status")).Text.ToString();
                hid_case_no.Value = xcase_no;
                if (!string.IsNullOrEmpty(xassto_login))
                {
                    ddlNameList.SelectedValue = xassto_login;
                }

                rdlAction.SelectedValue = xstatus;

                btn_update_modal.Visible = true;
                btn_update_all_modal.Visible = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalAssign();", true);
            }
        }

        protected void btn_litigation_Click(object sender, EventArgs e)
        {
            var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
            var xurl = host_url + "frmlitigation/litigationcasedetail.aspx?id=" + hid_caseNo.Value;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('" + xurl + "','_blank');", true);
        }

        protected void Assign_Update_Click(object sender, EventArgs e)
        {
            var xcase_no = hid_case_no.Value.Trim();
            var xassto_login = ddlNameList.SelectedValue.Trim();
            var xstatus = rdlAction.SelectedValue.Trim();
            var xupdate_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            int ret = 0;
            string sqlupdate = @"UPDATE [li_litigation_req_case]
                                   SET [status] = '" + xstatus + @"'
                                      ,[assto_login] = '" + xassto_login + @"'
	                                  ,[updated_datetime] = '" + xupdate_date + @"'
                                 WHERE [case_no] = '" + xcase_no + "'";

            ret = zdb.ExecNonQueryReturnID(sqlupdate, zconnstr);
            if (ret > 0)
            {
                Response.Write("<script>alert('Successfully Updated');</script>");
                setData(hid_PID.Value);

                //      if (xstatus == "In Progress")
                //      {
                //          //send mail
                //          string subject = "";
                //          string body = "";
                //          string sqlmail = @"SELECT [process_id],commreg.[req_no],[req_date],commreg.[toc_regis_code],toc.[toc_regis_desc],[document_no],addi.subsidiary_code,comsub.subsidiary_name_th
                //                              FROM li_comm_regis_request AS commreg
                //INNER JOIN li_comm_regis_request_additional as addi on commreg.req_no = addi.req_no
                //                              LEFT OUTER JOIN li_comm_regis_subsidiary AS comsub ON addi.subsidiary_code = comsub.subsidiary_code
                //                              INNER JOIN li_type_of_comm_regis AS toc ON commreg.toc_regis_code = toc.toc_regis_code
                //where commreg.[req_no] = '" + xreq_no + "' and addi.subsidiary_code = '" + xsubsidiary_code + "'";
                //          var dt = zdb.ExecSql_DataTable(sqlmail, zconnstr);
                //          if (dt.Rows.Count > 0)
                //          {
                //              var dr = dt.Rows[0];
                //              string id = dr["req_no"].ToString();
                //              subject = "เรื่อง " + dr["toc_regis_desc"].ToString().Trim() + " " + dr["subsidiary_name_th"].ToString().Trim();
                //              var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
                //              body = "คุณได้รับมอบหมายงาน " + dr["document_no"].ToString() + " กรุณาตรวจสอบและดำเนินการผ่านระบบ <a target='_blank' href='" + host_url + "frmcommregis/commregisrequesteditbyadmin.aspx?id=" + xreq_no + "'>Click</a>";



                //              string pathfileins = "";

                //              string sqlfile = "select top 1 * from z_replacedocx_log where replacedocx_reqno='" + id + "' order by row_id desc";

                //              var resfile = zdb.ExecSql_DataTable(sqlfile, zconnstr);

                //              if (resfile.Rows.Count > 0)
                //              {
                //                  pathfileins = resfile.Rows[0]["output_filepath"].ToString().Replace(".docx", ".pdf");

                //                  string email = "";

                //                  var isdev = ConfigurationManager.AppSettings["isDev"].ToString();
                //                  ////get mail from db
                //                  /////send mail to next_approve
                //                  if (isdev != "true")
                //                  {
                //                      string sqlbpm = "select * from li_user where user_login = '" + xassto_login + "' ";
                //                      System.Data.DataTable dtbpm = zdb.ExecSql_DataTable(sqlbpm, zconnstr);

                //                      if (dtbpm.Rows.Count > 0)
                //                      {
                //                          email = dtbpm.Rows[0]["email"].ToString();

                //                      }
                //                      else
                //                      {
                //                          string sqlpra = "select * from Rpa_Mst_HrNameList where Login = 'ASSETWORLDCORP-\\" + xassto_login + "' ";
                //                          System.Data.DataTable dtrpa = zdb.ExecSql_DataTable(sqlpra, zconnstrrpa);

                //                          if (dtrpa.Rows.Count > 0)
                //                          {
                //                              email = dtrpa.Rows[0]["Email"].ToString();
                //                          }
                //                          else
                //                          {
                //                              email = "";
                //                          }

                //                      }
                //                  }
                //                  else
                //                  {
                //                      ////fix mail test
                //                      email = "legalwfuat2024@gmail.com";
                //                  }

                //                  if (!string.IsNullOrEmpty(email))
                //                  {
                //                      _ = zsendmail.sendEmail(subject, email, body, pathfileins);
                //                  }

                //              }

                //          }
                //      }
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
        }
    }
}