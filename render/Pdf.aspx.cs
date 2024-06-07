using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.render
{
    public partial class Pdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(id))
            {
                Response.Clear();
                string filePath = id;
                Response.ContentType = "application/pdf";
                Response.WriteFile(filePath);
                Response.End();
            }
        }
    }
}