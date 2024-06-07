using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.frmInsurance
{
    public partial class InsuranceRequestList : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setDataRequestList();
            }
        }

        private void setDataRequestList() 
        {
            ucHeader1.setHeader("My Request List");

            string sql = "select * from li_insurance_request where toreq_code='01'";

            var res = zdb.ExecSql_DataTable(sql, zconnstr);

            lvReqList.DataSource = res;
            lvReqList.DataBind();
        }
    }
}