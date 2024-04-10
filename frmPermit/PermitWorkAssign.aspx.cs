using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmPermit
{
    public partial class PermitWorkAssign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setData();
            }

        }
        private void setData()
        {
            ucHeader1.setHeader("Permit Tracking");
            // Bind Worklist
            if (Session["user_login"] != null)
            {
                var xlogin_name = Session["user_login"].ToString();

                ucTaskList1.bindData(xlogin_name, "permitTracking");

            }
        }
    }
}