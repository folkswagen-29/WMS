using DocumentFormat.OpenXml.ExtendedProperties;
using onlineLegalWF.Class;
using Spire.Doc;
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

            type_requester.DataSource = GetTypeOfRequester();
            type_requester.DataBind();
            type_requester.DataTextField = "tof_requester_desc";
            type_requester.DataValueField = "tof_requester_code";
            type_requester.DataBind();

            type_project.DataSource = GetBusinessUnit();
            type_project.DataBind();
            type_project.DataTextField = "bu_desc";
            type_project.DataValueField = "bu_code";
            type_project.DataBind();

            license_code.DataSource = GetTypeOfPermitLicense();
            license_code.DataBind();
            license_code.DataTextField = "license_desc";
            license_code.DataValueField = "license_code";
            license_code.DataBind();

            var dtSublicense = GetSubPermitLicense(license_code.SelectedValue);

            if (dtSublicense.Rows.Count > 0) 
            {
                ddl_sublicense.Visible = true;
                ddl_sublicense.DataSource = dtSublicense;
                ddl_sublicense.DataBind();
                ddl_sublicense.DataTextField = "sublicense_desc";
                ddl_sublicense.DataValueField = "sublicense_code";
                ddl_sublicense.DataBind();
            }

            var dtSublicenseRefdoc = GetSubPermitLicenseRefDoc(ddl_sublicense.SelectedValue);

            if (dtSublicenseRefdoc.Rows.Count > 0)
            {
                refdoc.Visible = true;
                ddl_refdoc.Visible = true;
                ddl_refdoc.DataSource = dtSublicenseRefdoc;
                ddl_refdoc.DataBind();
                ddl_refdoc.DataTextField = "sublicense_refdoc_desc";
                ddl_refdoc.DataValueField = "sublicense_code";
                ddl_refdoc.DataBind();
            }


        }

        protected void ddl_license_Changed(object sender, EventArgs e)
        {
            var dtSublicense = GetSubPermitLicense(license_code.SelectedValue);

            if (dtSublicense.Rows.Count > 0)
            {
                ddl_sublicense.Visible = true;
                ddl_sublicense.DataSource = dtSublicense;
                ddl_sublicense.DataBind();
                ddl_sublicense.DataTextField = "sublicense_desc";
                ddl_sublicense.DataValueField = "sublicense_code";
                ddl_sublicense.DataBind();

                var dtSublicenseRefdoc = GetSubPermitLicenseRefDoc(ddl_sublicense.SelectedValue);

                if (dtSublicenseRefdoc.Rows.Count > 0)
                {
                    refdoc.Visible = true;
                    ddl_refdoc.Visible = true;
                    ddl_refdoc.DataSource = dtSublicenseRefdoc;
                    ddl_refdoc.DataBind();
                    ddl_refdoc.DataTextField = "sublicense_refdoc_desc";
                    ddl_refdoc.DataValueField = "sublicense_code";
                    ddl_refdoc.DataBind();
                }
                else
                {
                    refdoc.Visible = false;
                    ddl_refdoc.Visible = false;
                }
            }
            else 
            {
                ddl_sublicense.Visible = false;
                refdoc.Visible = false;
                ddl_refdoc.Visible = false;
            }
        }

        protected void ddl_sublicense_Changed(object sender, EventArgs e)
        {
            var dtSublicenseRefdoc = GetSubPermitLicenseRefDoc(ddl_sublicense.SelectedValue);

            if (dtSublicenseRefdoc.Rows.Count > 0)
            {
                refdoc.Visible = true;
                ddl_refdoc.Visible = true;
                ddl_refdoc.DataSource = dtSublicenseRefdoc;
                ddl_refdoc.DataBind();
                ddl_refdoc.DataTextField = "sublicense_refdoc_desc";
                ddl_refdoc.DataValueField = "sublicense_code";
                ddl_refdoc.DataBind();
            }
            else
            {
                refdoc.Visible = false;
                ddl_refdoc.Visible = false;
            }
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

        public DataTable GetTypeOfPermitLicense()
        {
            string sql = "select * from li_permit_license order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        public DataTable GetSubPermitLicense(string xlicense_code)
        {
            string sql = @"select license.[license_code]
                                  ,license.[sublicense_code]
	                              ,sub.[sublicense_desc]
                                  ,license.[row_sort]
                              from [li_permit_group_license] as license
                            inner join li_permit_sublicense as sub on sub.sublicense_code = license.sublicense_code
                            where license.[license_code] = '"+xlicense_code+"' order by license.[row_sort] asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }
        public DataTable GetSubPermitLicenseRefDoc(string xsublicense_code)
        {
            string sql = @"select * from li_permit_sublicense_refdoc
                            where sublicense_code = '" + xsublicense_code + "' order by row_sort asc";
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