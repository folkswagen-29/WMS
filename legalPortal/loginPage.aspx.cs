using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using onlineLegalWF.Class; 

namespace onlineLegalWF.legalPortal
{
    public partial class loginPage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                
            
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Check Authen
            var token = "xxxx";//getAuthen(txtLoginName.Text.Trim(), txtPassword.Text.Trim());
            if (!String.IsNullOrEmpty(token))
            {
                // clear session 
                addSession(txtLoginName.Text);
                Response.Redirect("legalPortal.aspx"); 
            }
        }
        public void checkAuthen(string xusername, string xpassword) 
        { 
            
        }
        public void addSession(string xusername) 
        {
            var empFunc = new EmpInfo();

            var emp = empFunc.getEmpInfo(xusername); 
            Session.Clear();
            Session.Add("user_login", emp.user_login);
            Session.Add("user_name", emp.user_name);
            Session.Add("user_position", emp.position);
            Session.Add("division", emp.divisiton);
            Session.Add("department", emp.department);
            Session.Add("bu", emp.bu);

        }

    }
}