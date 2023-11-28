using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmLitigation
{
    public partial class LitigationRequestEdit : System.Web.UI.Page
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
            ucHeader1.setHeader("Litigation Edit");
            string xreq_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            string xdoc_no = "LIT2311001";
            req_no.Text = xreq_no;
            doc_no.Text = xdoc_no;
            subject.Text = "Request New License";
        }
    }
}