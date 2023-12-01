using onlineLegalWF.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF
{
    public partial class SiteLigalWorkFlow : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                SetDataLogin();
            }
        }

        private void SetDataLogin() 
        {
            if (Session["user_login"] != null) 
            {
                var user_login = Session["user_login"].ToString();
                var user_bu = Session["bu"].ToString();
                if (!string.IsNullOrEmpty(user_login))
                {
                    login_name.Text = user_login;
                    login_bu.Text = user_bu;
                }
                
            }
            else 
            {
                Response.Redirect("/legalPortal/loginPage.aspx");
            }
            
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/legalPortal/loginPage.aspx");
        }
    }
}