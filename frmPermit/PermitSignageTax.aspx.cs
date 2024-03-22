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
    public partial class PermitSignageTax : System.Web.UI.Page
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
            ucHeader1.setHeader("SignageTax Request");
            string xreq_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            req_no.Text = xreq_no;

            string pid = zwf.iniPID("LEGALWF");
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucCommentlog1.ini_object(pid);

            type_project.DataSource = GetBusinessUnit();
            type_project.DataBind();
            type_project.DataTextField = "bu_desc";
            type_project.DataValueField = "bu_code";
            type_project.DataBind();

            type_requester.DataSource = GetTypeOfRequester();
            type_requester.DataBind();
            type_requester.DataTextField = "tof_requester_desc";
            type_requester.DataValueField = "tof_requester_code";
            type_requester.DataBind();
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
        public DataTable GetTypeOfRequester()
        {
            string sql = "select * from li_type_of_requester order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }
        public DataTable GetBusinessUnit()
        {
            string sql = "select * from li_business_unit where isactive=1 order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }
        private int SaveRequest()
        {
            int ret = 0;

            if (doc_no.Text.Trim() == "")
            {
                doc_no.Text = zwf.genDocNo("DCP-" + System.DateTime.Now.ToString("yyyy", new CultureInfo("en-US")) + "-", 6);
            }
            var xpermit_no = req_no.Text.Trim();
            var xprocess_id = hid_PID.Value.ToString();
            var xtof_requester_code = type_requester.SelectedValue;
            var xpermit_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xproject_code = type_project.SelectedValue;
            var xtof_permitreq_code = "05";
            var xcontact_agency = contact_agency.Text.Trim();
            var xattorney_name = attorney_name.Text.Trim();
            var xstatus = "verify";

            string sql = @"INSERT INTO [dbo].[li_permit_request]
                                   ([process_id],[permit_no],[permit_date],[tof_requester_code],[project_code],[tof_permitreq_code],[contact_agency],[attorney_name],[status])
                             VALUES
                                   ('" + xprocess_id + @"'
                                   ,'" + xpermit_no + @"'
                                   ,'" + xpermit_date + @"'
                                   ,'" + xtof_requester_code + @"'
                                   ,'" + xproject_code + @"'
                                   ,'" + xtof_permitreq_code + @"'
                                   ,'" + xcontact_agency + @"'
                                   ,'" + xattorney_name + @"'
                                   ,'" + xstatus + @"')";

            ret = zdb.ExecNonQueryReturnID(sql, zconnstr);


            return ret;
        }
    }
}