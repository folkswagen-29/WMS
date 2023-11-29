using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmLitigation
{
    public partial class LitigationCaseDetail : System.Web.UI.Page
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
            ucHeader1.setHeader("Case Detail");
            string xcase_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            case_no.Text = xcase_no;
        }
    }
}