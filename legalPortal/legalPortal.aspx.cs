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

        }
        public void checkSession() 
        {
            var is_login = Session["is_login"].ToString(); 
            if (is_login == "Y")
            {
                // Load Menu
                
            }
            else
            {
                // go to Login page
                Response.Redirect("loginPage.aspx"); 
            }
        }
    }
}