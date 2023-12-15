using onlineLegalWF.Class;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmPermit
{
    public partial class PermitLicense : System.Web.UI.Page
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
                setData();
            }
        }

        private void setData()
        {
            ucHeader1.setHeader("License Request");
            string xreq_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            req_no.Text = xreq_no;

            string pid = zwf.iniPID("LEGALWF");
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucCommentlog1.ini_object(pid);
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            int res = SaveRequest();

            if (res > 0)
            {
                Response.Write("<script>alert('Successfully added');</script>");
                //Response.Redirect("/frmInsurance/InsuranceRequestList");
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {

        }

        private int SaveRequest()
        {
            int ret = 0;

            if (doc_no.Text.Trim() == "")
            {
                doc_no.Text = zwf.genDocNo("PMT-" + System.DateTime.Now.ToString("yyyy", new CultureInfo("en-US")) + "-", 4);
            }
            var xpermit_no = req_no.Text.Trim();
            var xprocess_id = hid_PID.Value.ToString();
            var xtof_requester_code = type_requester.SelectedValue;
            var xpermit_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xproject_code = type_project.SelectedValue;
            var xtof_permitreq_code = type_req_license.SelectedValue;
            var xlicense_code = license_code.SelectedValue;
            var xcontact_agency = contact_agency.Text.Trim();
            var xattorney_name = attorney_name.Text.Trim();
            var xstatus = "verify";

            string sql = @"INSERT INTO [dbo].[li_permit_request]
                                   ([process_id],[permit_no],[permit_date],[tof_requester_code],[project_code],[tof_permitreq_code],[license_code],[contact_agency],[attorney_name],[status])
                             VALUES
                                   ('" + xprocess_id + @"'
                                   ,'" + xpermit_no + @"'
                                   ,'" + xpermit_date + @"'
                                   ,'" + xtof_requester_code + @"'
                                   ,'" + xproject_code + @"'
                                   ,'" + xtof_permitreq_code + @"'
                                   ,'" + xlicense_code + @"'
                                   ,'" + xcontact_agency + @"'
                                   ,'" + xattorney_name + @"'
                                   ,'" + xstatus + @"')";

            ret = zdb.ExecNonQueryReturnID(sql, zconnstr);


            return ret;
        }
    }
}