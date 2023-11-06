using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceClaimList : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BMPDB"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setDataClaimList();
            }
        }

        private void setDataClaimList()
        {
            string sql = "select * from li_insurance_claim order by process_id asc";

            var res = zdb.ExecSql_DataTable(sql, zconnstr);

            gvClaimList.DataSource = res;
            gvClaimList.DataBind();
        }
    }
}