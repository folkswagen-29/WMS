using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.legalPortal
{
    public partial class legalPortal : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                checkSession();
            }
        }
        public void checkSession() 
        {
            ucHeader1.setHeader("Legal Portal");
            //var is_login = Session["is_login"].ToString(); 
            //if (is_login == "Y")
            //{
            //    // Load Menu

            //}
            //else
            //{
            //    // go to Login page
            //    Response.Redirect("loginPage.aspx"); 
            //}
            if (Session["user_login"] != null) 
            {
                var xlogin_name = Session["user_login"].ToString();
                var xhid_mode = Request.QueryString["m"];

                setNotificationInbox(xlogin_name);
                if (!string.IsNullOrEmpty(xhid_mode)) 
                {
                    ucTaskList1.bindData(xlogin_name, xhid_mode);
                }
                
            }

        }

        public void setNotificationInbox(string login_name)
        {
            string numnotify = "0";
            string sql = "Select count(submit_by) as total from wf_routing where process_id in (Select process_id from wf_routing where assto_login like '" + login_name + "' and submit_answer = '') and submit_answer = ''";
            System.Data.DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            if (dt.Rows.Count > 0)
            {
                numnotify = dt.Rows[0]["total"].ToString();
            }
            string js = "$('#inbox_notify').html('" + numnotify + "');";

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SetNotify", js, true);
        }

    }
}