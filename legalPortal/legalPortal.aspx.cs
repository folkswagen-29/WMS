using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.legalPortal
{
    public partial class legalPortal : System.Web.UI.Page
    {
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

                if (!string.IsNullOrEmpty(xhid_mode)) 
                {
                    ucTaskList1.bindData(xlogin_name, xhid_mode);
                }
                
            }

        }

    }
}