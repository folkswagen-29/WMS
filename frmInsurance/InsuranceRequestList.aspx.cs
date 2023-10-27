using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceRequestList : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BMPDB"].ToString();
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
            string query = "select * from li_insurance_request";

            var res = zdb.ExecSql_DataTable(query, zconnstr);

            gvReqList.DataSource = res;
            gvReqList.DataBind();
        }
    }
}