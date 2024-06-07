﻿using WMS.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.forms
{
    public partial class RequesterCloseJob : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public WFFunctions zwf = new WFFunctions();
        public SendMail zsendmail = new SendMail();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string req = Request.QueryString["req"];
                string process_code = Request.QueryString["pc"];

                if (!string.IsNullOrEmpty(req) && !string.IsNullOrEmpty(process_code))
                {
                    setData(req, process_code);
                }

            }
        }

        private void setData(string req, string process_code)
        {
            string id = "";

            ucHeader1.setHeader(process_code + " Approve");
            if (process_code == "INR_NEW" || process_code == "INR_RENEW")
            {
                string sqlinsreq = "select * from li_insurance_request where process_id='" + req + "'";
                var resinsreq = zdb.ExecSql_DataTable(sqlinsreq, zconnstr);

                //get data ins req
                if (resinsreq.Rows.Count > 0)
                {
                    id = resinsreq.Rows[0]["req_no"].ToString();
                    req_no.Value = resinsreq.Rows[0]["req_no"].ToString();
                    req_date.Text = Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(resinsreq.Rows[0]["req_date"]), "en");
                    from.Text = resinsreq.Rows[0]["company_name"].ToString();
                    doc_no.Text = resinsreq.Rows[0]["document_no"].ToString();
                    subject.Text = resinsreq.Rows[0]["subject"].ToString();
                    hid_bucode.Value = resinsreq.Rows[0]["bu_code"].ToString();

                    //init data UcAttachAndCommentLogs
                    initDataAttachAndComment(resinsreq.Rows[0]["process_id"].ToString());

                    getDocument(id);
                }
            }
            else if (process_code == "INR_CLAIM" || process_code == "INR_CLAIM_2" || process_code == "INR_CLAIM_3")
            {
                string sqlinsclaim = "select * from li_insurance_claim where process_id='" + req + "'";
                var resinsclaim = zdb.ExecSql_DataTable(sqlinsclaim, zconnstr);

                //get data ins req
                if (resinsclaim.Rows.Count > 0)
                {
                    id = resinsclaim.Rows[0]["claim_no"].ToString();
                    req_no.Value = resinsclaim.Rows[0]["claim_no"].ToString();
                    req_date.Text = Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(resinsclaim.Rows[0]["claim_date"]), "en");
                    from.Text = resinsclaim.Rows[0]["company_name"].ToString();
                    doc_no.Text = resinsclaim.Rows[0]["document_no"].ToString();
                    subject.Text = resinsclaim.Rows[0]["incident"].ToString();
                    hid_bucode.Value = resinsclaim.Rows[0]["bu_code"].ToString();

                    //init data UcAttachAndCommentLogs
                    initDataAttachAndComment(resinsclaim.Rows[0]["process_id"].ToString());

                    getDocument(id);
                }
            }
        }

        private void getDocument(string id)
        {
            string sqlfile = "select top 1 * from z_replacedocx_log where replacedocx_reqno='" + id + "' order by row_id desc";

            var resfile = zdb.ExecSql_DataTable(sqlfile, zconnstr);

            if (resfile.Rows.Count > 0)
            {
                string pathfile = resfile.Rows[0]["output_filepath"].ToString().Replace(".docx", ".pdf");
                var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
                pdf_render.Attributes["src"] = host_url + "render/pdf?id=" + pathfile;
            }
        }

        private void initDataAttachAndComment(string pid)
        {
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucCommentlog1.ini_object(pid);
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string process_code = Request.QueryString["pc"];
            int version_no = 1;

            if (!string.IsNullOrEmpty(process_code))
            {
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
                    wfAttr.wf_status = "COMPLETED";
                    wfAttr.submit_answer = "COMPLETED";
                    wfAttr.next_assto_login = zwf.findNextStep_Assignee(wfAttr.process_code, wfAttr.step_name, emp.user_login, wfAttr.submit_by, hid_bucode.Value);
                    wfAttr.updated_by = emp.user_login;
                    wfAttr.submit_by = wfAttr.submit_by;
                    // wf.updateProcess
                    var wfA_NextStep = zwf.updateProcess(wfAttr);
                    wfA_NextStep.submit_by = wfAttr.submit_by;
                    wfA_NextStep.wf_status = "COMPLETED";
                    string status = zwf.Insert_NextStep(wfA_NextStep);

                    if (status == "Success")
                    {
                        if (wfA_NextStep.step_name == "End" && wfAttr.process_code == "INR_NEW")
                        {
                            string sqlupdate = @"update li_insurance_request set status='approved',updated_datetime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where process_id = '" + wfAttr.process_id + "'";
                            zdb.ExecNonQuery(sqlupdate, zconnstr);
                        }
                        else if (wfA_NextStep.step_name == "End" && wfAttr.process_code == "INR_CLAIM")
                        {
                            string sqlupdate = @"update li_insurance_claim set status='approved',updated_datetime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where process_id = '" + wfAttr.process_id + "'";
                            zdb.ExecNonQuery(sqlupdate, zconnstr);
                        }
                        else if (wfA_NextStep.step_name == "End" && wfAttr.process_code == "INR_RENEW")
                        {
                            string sqlupdate = @"update li_insurance_request set status='approved',updated_datetime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where process_id = '" + wfAttr.process_id + "'";
                            zdb.ExecNonQuery(sqlupdate, zconnstr);
                        }
                        var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
                        Response.Redirect(host_url+"Portal/Portal.aspx?m=completelist");
                    }

                }
            }
        }

        public void sendEmail(string subject,string mailto,string body, string filepath)
        {
            //string filepath = @"D:\Users\worawut.m\Downloads\mergePdf_20240115_124616.pdf";
            //string subject = "Test Send Mail to worawut";
            //string mailto = "legalwfuat2024@gmail.com";
            //string body = "Test attach file to worawut";

            _ = zsendmail.sendEmail(subject, mailto, body, filepath);
        }
    }
}