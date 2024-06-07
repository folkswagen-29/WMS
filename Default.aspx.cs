using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
            Response.Redirect(host_url + "portal/loginpage.aspx");
        }
    }
}