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

            lblPID.Text = wf.iniPID("LEGALWF");
            ucAttachment1.ini_object(lblPID.Text); 

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string process_code = "INR_NEW";
            int version_no = 1;
            // getCurrentStep
            var wfAttr = wf.getCurrentStep(lblPID.Text, process_code, version_no);

            // set WF Attributes
            wfAttr.subject = txtSubject.Text.Trim();
            wfAttr.assto_login = "eknawat.c";
            wfAttr.wf_status = "SUBMITTED";
            wfAttr.submit_answer = "";
            wfAttr.next_assto_login = "eknawat.c, worawut.m";
            wf.updateProcess(wfAttr); 

            // wf.updateProcess
        }
    }
}