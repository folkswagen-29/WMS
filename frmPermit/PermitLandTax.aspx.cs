using onlineLegalWF.Class;
using onlineLegalWF.userControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmPermit
{
    public partial class PermitLandTax : System.Web.UI.Page
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
            ucHeader1.setHeader("Land and Building Tax Request");
            string xreq_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            req_no.Text = xreq_no;

            string pid = zwf.iniPID("LEGALWF");
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucCommentlog1.ini_object(pid);

            type_lt_project.DataSource = GetTypeOfLtProject();
            type_lt_project.DataBind();
            type_lt_project.DataTextField = "lt_project_desc";
            type_lt_project.DataValueField = "lt_project_code";
            type_lt_project.DataBind();
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            int res = SaveRequest();

            if (res > 0)
            {
                Response.Write("<script>alert('Successfully added');</script>");
                //Response.Redirect("frmInsurance/InsuranceRequestList");
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {

        }

        public DataTable GetTypeOfLtProject()
        {
            string sql = "select * from li_permit_lt_project order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
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
            var xlt_project_code = type_lt_project.SelectedValue;
            var xtof_permitreq_code = "06";
            var xcontact_agency = contact_agency.Text.Trim();
            var xattorney_name = attorney_name.Text.Trim();
            var xemail_accounting = email_accounting.Text.Trim();
            var xstatus = "verify";

            string sql = @"INSERT INTO [dbo].[li_permit_request]
                                   ([process_id],[permit_no],[permit_date],[tof_requester_code],[lt_project_code],[tof_permitreq_code],[contact_agency],[attorney_name],[email_accounting],[status])
                             VALUES
                                   ('" + xprocess_id + @"'
                                   ,'" + xpermit_no + @"'
                                   ,'" + xpermit_date + @"'
                                   ,'" + xtof_requester_code + @"'
                                   ,'" + xlt_project_code + @"'
                                   ,'" + xtof_permitreq_code + @"'
                                   ,'" + xcontact_agency + @"'
                                   ,'" + xattorney_name + @"'
                                   ,'" + xemail_accounting + @"'
                                   ,'" + xstatus + @"')";

            ret = zdb.ExecNonQueryReturnID(sql, zconnstr);


            return ret;
        }
    }
}