using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using onlineLegalWF.Class;

namespace onlineLegalWF.test
{
    public partial class TestWF01 : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        //public string zconnstr = ConfigurationSettings.AppSettings["BPMDB"].ToString();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public string zpath_attachment = ConfigurationManager.AppSettings["path_attachment"].ToString();
        public WFFunctions wf = new WFFunctions(); 
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                ini_object(); 
            }
        }
        private void ini_object()
        {

            //lblPID.Text = wf.iniPID("LEGALWF");
            //ucAttachment1.ini_object(lblPID.Text); 

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            // Sample Submit
            string process_code = "INR_NEW";
            int version_no = 1;
            lblPID.Text = wf.iniPID("LEGALWF");
            txtProcessID.Text = lblPID.Text; 
            // getCurrentStep
            var wfAttr = wf.getCurrentStep(lblPID.Text, process_code, version_no);

            // set WF Attributes
            wfAttr.subject = txtSubject.Text.Trim();
            wfAttr.assto_login = "eknawat.c";
            wfAttr.wf_status = "SUBMITTED";
            wfAttr.submit_answer = "SUBMITTED";
            wfAttr.next_assto_login = "eknawat.c, worawut.m";
            wfAttr.submit_by = "eknawat.c";
            // wf.updateProcess
            wf.updateProcess(wfAttr); 

            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Sample Approve
            string process_code = "INR_NEW";
            int version_no = 1;
            lblPID.Text = txtProcessID.Text; 
            // getCurrentStep
            var wfAttr = wf.getCurrentStep(lblPID.Text, process_code, version_no);


            //// set WF Attributes for GM Approved
            //wfAttr.subject = txtSubject.Text.Trim();
            //wfAttr.submit_by = "eknawat.c";
            //wfAttr.wf_status = "GM Approved";
            //wfAttr.submit_answer = "APPROVED";
            //wfAttr.next_assto_login = "eknawat.c";
            //wfAttr.submit_by = "eknawat.c";
            //// wf.updateProcess
            //wf.updateProcess(wfAttr);

            // set WF Attributes for C-Level Approved

           

            wfAttr.subject = txtSubject.Text.Trim();
            wfAttr.submit_by = "eknawat.c";
            wfAttr.wf_status = wfAttr.step_name + " Approved"; 
            wfAttr.submit_answer = "APPROVED";
            wfAttr.submit_by = "eknawat.c";
            // wf.updateProcess
            var wfA_NextStep = wf.updateProcess(wfAttr);

            wfA_NextStep.next_assto_login = findNextStep_Assignee(wfA_NextStep.process_code, wfA_NextStep.step_name );
            wf.Insert_NextStep(wfA_NextStep); 

        }
        private string findNextStep_Assignee(string process_code, string next_step_name)
        {
            string xname = "";
            /* stepname list 
              Start
              GM Approve
              BU C - Level Approve
              Legal Insurance
              Legal Insurance Update
              End
              Edit Request
            */
            if (next_step_name == "Start") 
            {
                xname = "eknawat.c"; //Requestor = Login account
            }
            else if (next_step_name == "GM Approve")
            {
                //findGMApprove(loginname)
                //xname = findGMApprove(loginname); //Requestor = Login account
                xname = "eknawat.c"; //GM Login
            }
            else 
            {
                //findGMApprove(loginname)
                //xname = findGMApprove(loginname); //Requestor = Login account
                xname = "eknawat.c"; //GM Login
            }
            return xname; 
        }
    }
}