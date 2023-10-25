using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.legalPortal
{
    public partial class loginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var is_login = Session["is_login"].ToString();
            if (is_login == "N")
            {
                // check Login and Password
                Session.Add("is_login", "Y");
            }
            else
            {
                // clear session 
                addSession(); 
            }
        }
        public void addSession() { 
        }

    }
}