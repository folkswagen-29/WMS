using onlineLegalWF.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.forms
{
    public partial class apv : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public WFFunctions zwf = new WFFunctions();
        public string zconnstrrpa = ConfigurationManager.AppSettings["RPADB"].ToString();
        public MargePDF zmergepdf = new MargePDF();
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
                    setDataApprove(req, process_code);
                }

            }
        }

        private void setDataApprove(string req, string process_code)
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

                    //init data UcAttachAndCommentLogs
                    initDataAttachAndComment(resinsreq.Rows[0]["process_id"].ToString());

                    getDocument(id);
                }
            }
            else if (process_code == "INR_CLAIM") 
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
                    //subject.Text = resinsclaim.Rows[0]["subject"].ToString();

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
                pdf_render.Attributes["src"] = "/render/pdf?id=" + pathfile;
            }
        }

        private void initDataAttachAndComment(string pid)
        {
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucCommentlog1.ini_object(pid);
        }

        protected void btn_Approve_Click(object sender, EventArgs e)
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
                    wfAttr.wf_status = wfAttr.step_name + " Approved";
                    wfAttr.submit_answer = "APPROVED";
                    //wfAttr.next_assto_login = emp.next_line_mgr_login;
                    wfAttr.next_assto_login = zwf.findNextStep_Assignee(wfAttr.process_code, wfAttr.step_name, emp.user_login, wfAttr.submit_by);
                    wfAttr.updated_by = emp.user_login;
                    wfAttr.submit_by = wfAttr.submit_by;
                    // wf.updateProcess
                    var wfA_NextStep = zwf.updateProcess(wfAttr);
                    //wfA_NextStep.next_assto_login = emp.next_line_mgr_login;
                    wfA_NextStep.next_assto_login = zwf.findNextStep_Assignee(wfA_NextStep.process_code, wfA_NextStep.step_name, emp.user_login, wfAttr.submit_by);
                    //wfA_NextStep.submit_by = emp.user_login;
                    wfA_NextStep.submit_by = wfA_NextStep.submit_by;
                    string status = zwf.Insert_NextStep(wfA_NextStep);

                    if (status == "Success") 
                    {
                        if (wfAttr.step_name == "CCO Approve" && wfAttr.process_code == "INR_NEW")
                        {
                            string subject = "";
                            string body = "";
                            string sql = @"select * from li_insurance_request where process_id = '" + wfAttr.process_id + "'";
                            var dt = zdb.ExecSql_DataTable(sql, zconnstr);
                            if (dt.Rows.Count > 0)
                            {
                                var dr = dt.Rows[0];
                                string id = dr["req_no"].ToString();
                                subject = dr["subject"].ToString();
                                body = "เอกสารเลขที่ " + dr["document_no"].ToString() + " ได้รับการอนุมัติผ่านระบบแล้ว";

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
                                    //string sqlbpm = "select * from li_user where user_login = '" + wfDefault_step.submit_by + "' ";
                                    //System.Data.DataTable dtbpm = zdb.ExecSql_DataTable(sqlbpm, zconnstr);

                                    //if (dtbpm.Rows.Count > 0)
                                    //{
                                    //    email = dtbpm.Rows[0]["email"].ToString();

                                    //}
                                    //else
                                    //{
                                    //    string sqlpra = "select * from Rpa_Mst_HrNameList where Login = 'ASSETWORLDCORP-\\" + wfDefault_step.submit_by + "' ";
                                    //    System.Data.DataTable dtrpa = zdb.ExecSql_DataTable(sqlpra, zconnstrrpa);

                                    //    if (dt.Rows.Count > 0)
                                    //    {
                                    //        email = dtrpa.Rows[0]["Email"].ToString();
                                    //    }

                                    //}

                                    string filepath = zmergepdf.mergefilePDF(pdfFiles, outputdirectory);

                                    //send mail to requester

                                    ////fix mail test
                                    string email = "worawut.m@assetworldcorp-th.com";
                                    _ = zsendmail.sendEmail(subject + " Mail To Requester", email, body, filepath);

                                    //send mait to Procurement
                                    _ = zsendmail.sendEmail(subject + " Mail To Procurement", email, body, filepath);

                                    //send mail to jaroonsak.n
                                    _ = zsendmail.sendEmail(subject + " Mail To Jaroonsak.n", email, body, filepath);

                                }

                            }
                        }

                        //Response.Redirect("/legalportal/legalportal.aspx?m=myworklist");
                    }

                }
            }

            
        }
    }
}