using onlineLegalWF.Class;
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
    public partial class PermitLicenseEdit : System.Web.UI.Page
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
            ucHeader1.setHeader("License Request Edit");

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

            string sql = "select * from li_permit_request where permit_no='" + id + "'";

            var res = zdb.ExecSql_DataTable(sql, zconnstr);

            if (res.Rows.Count > 0) 
            {
                req_date.Value = Convert.ToDateTime(res.Rows[0]["permit_date"]).ToString("yyyy-MM-dd");
                lblPID.Text = res.Rows[0]["process_id"].ToString();
                hid_PID.Value = res.Rows[0]["process_id"].ToString();
                ucAttachment1.ini_object(res.Rows[0]["process_id"].ToString());
                ucCommentlog1.ini_object(res.Rows[0]["process_id"].ToString());
                req_no.Text = res.Rows[0]["permit_no"].ToString();
                doc_no.Text = res.Rows[0]["document_no"].ToString();
                permit_desc.Text = res.Rows[0]["permit_desc"].ToString();
                type_requester.SelectedValue = res.Rows[0]["tof_requester_code"].ToString();
                tof_requester_other_desc.Text = res.Rows[0]["tof_requester_other_desc"].ToString();
                if (res.Rows[0]["tof_requester_code"].ToString() == "03")
                {
                    tof_requester_other_desc.Enabled = true;
                }
                else 
                {
                    tof_requester_other_desc.Enabled = false;
                }
                type_project.SelectedValue = res.Rows[0]["bu_code"].ToString();
                type_req_license.SelectedValue = res.Rows[0]["tof_permitreq_code"].ToString();
                tof_permitreq_other_desc.Text = res.Rows[0]["tof_permitreq_other_desc"].ToString();
                if (type_req_license.SelectedValue == "04" || type_req_license.SelectedValue == "03")
                {
                    tof_permitreq_other_desc.Enabled = true;
                    license_code.Enabled = false;
                    ddl_sublicense.Visible = false;
                    refdoc.Visible = false;
                    ddl_refdoc.Visible = false;
                }
                else
                {
                    license_code.Enabled = true;
                    ddl_sublicense.Visible = true;
                    refdoc.Visible = true;
                    ddl_refdoc.Visible = true;
                    tof_permitreq_other_desc.Enabled = false;
                }
                license_code.SelectedValue = res.Rows[0]["license_code"].ToString();
                if (!string.IsNullOrEmpty(res.Rows[0]["sublicense_code"].ToString())) 
                {
                    ddl_sublicense.SelectedValue = res.Rows[0]["sublicense_code"].ToString();

                    dtSublicense = GetSubPermitLicense(license_code.SelectedValue);

                    if (dtSublicense.Rows.Count > 0)
                    {
                        ddl_sublicense.Visible = true;
                    }

                   dtSublicenseRefdoc = GetSubPermitLicenseRefDoc(ddl_sublicense.SelectedValue);

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
                contact_agency.Text = res.Rows[0]["contact_agency"].ToString();
                attorney_name.Text = res.Rows[0]["attorney_name"].ToString();
            }


        }

        protected void ddl_type_requester_Changed(object sender, EventArgs e)
        {
            if (type_requester.SelectedValue == "03")
            {
                tof_requester_other_desc.Enabled = true;
            }
            else
            {
                tof_requester_other_desc.Enabled = false;
            }
        }

        protected void type_req_license_Changed(object sender, EventArgs e)
        {
            if (type_req_license.SelectedValue == "04" || type_req_license.SelectedValue == "03")
            {
                tof_permitreq_other_desc.Enabled = true;
                license_code.Enabled = false;
                ddl_sublicense.Visible = false;
                refdoc.Visible = false;
                ddl_refdoc.Visible = false;
            }
            else
            {
                license_code.Enabled = true;
                ddl_sublicense.Visible = true;
                refdoc.Visible = true;
                ddl_refdoc.Visible = true;
                tof_permitreq_other_desc.Enabled = false;
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
            int res = UpdateRequest();

            if (res > 0)
            {
                Response.Write("<script>alert('Successfully Udated');</script>");
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
                            where license.[license_code] = '" + xlicense_code + "' order by license.[row_sort] asc";
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
        private int UpdateRequest()
        {
            int ret = 0;

            var xpermit_no = req_no.Text.Trim();
            var xtof_requester_code = type_requester.SelectedValue;
            var xtof_requester_other_desc = tof_requester_other_desc.Text.Trim();
            var xpermit_updatedate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xproject_code = type_project.SelectedValue;
            var xtof_permitreq_code = type_req_license.SelectedValue;
            var xtof_permitreq_other_desc = tof_permitreq_other_desc.Text.Trim();
            var xlicense_code = license_code.SelectedValue;
            var xsublicense_code = "";
            if (license_code.SelectedValue == "11" || license_code.SelectedValue == "13") 
            {
                xsublicense_code = ddl_sublicense.SelectedValue;
            }
            var xpermit_desc = permit_desc.Text.Trim();
            var xcontact_agency = contact_agency.Text.Trim();
            var xattorney_name = attorney_name.Text.Trim();

            string sql = @"UPDATE [dbo].[li_permit_request]
                           SET [permit_desc] = '" +xpermit_desc+ @"'
                              ,[tof_requester_code] = '"+xtof_requester_code+@"'
                              ,[tof_requester_other_desc] = '"+xtof_requester_other_desc+@"'
                              ,[tof_permitreq_code] = '"+xtof_permitreq_code+@"'
                              ,[tof_permitreq_other_desc] = '"+xtof_permitreq_other_desc+@"'
                              ,[license_code] = '"+xlicense_code+@"'
                              ,[sublicense_code] = '"+xsublicense_code+@"'
                              ,[contact_agency] = '"+xcontact_agency+@"'
                              ,[attorney_name] = '"+xattorney_name+@"'
                              ,[bu_code] = '"+xproject_code+@"'
                              ,[updated_datetime] = '"+xpermit_updatedate+@"'
                         WHERE [permit_no] = '"+ xpermit_no + "'";

            ret = zdb.ExecNonQueryReturnID(sql, zconnstr);


            return ret;
        }
    }
}