using onlineLegalWF.userControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmPermit
{
    public partial class PermitSignageTax : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        //public string zconnstr = ConfigurationSettings.AppSettings["BMPDB"].ToString();
        public string zconnstr = ConfigurationManager.AppSettings["BMPDB"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setData();
            }
        }

        private void setData()
        {
            ucHeader1.setHeader("SignageTax Request");
            string xreq_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            req_no.Text = xreq_no;
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {

        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {

        }
    }
}