using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceRenewRequestList : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BMPDB"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setDataRenewRequestList();
            }
        }

        private void setDataRenewRequestList()
        {
            string sql = "select * from li_insurance_request where toreq_code='02'";

            var res = zdb.ExecSql_DataTable(sql, zconnstr);

            gvRenewReqList.DataSource = res;
            gvRenewReqList.DataBind();

        }
    }
}