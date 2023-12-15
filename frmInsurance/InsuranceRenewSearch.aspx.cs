using onlineLegalWF.Class;
using onlineLegalWF.userControls;
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
    public partial class InsuranceRenewSearch : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public WFFunctions zwf = new WFFunctions();
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
            ucHeader1.setHeader("Insurance Search and Report");

            type_req.DataSource = GetTypeOfRequest();
            type_req.DataBind();
            type_req.DataTextField = "toreq_desc";
            type_req.DataValueField = "toreq_code";
            type_req.DataBind();

            ddl_bu.DataSource = GetBusinessUnit();
            ddl_bu.DataBind();
            ddl_bu.DataTextField = "bu_desc";
            ddl_bu.DataValueField = "bu_code";
            ddl_bu.DataBind();
        }

        public DataTable GetTypeOfRequest()
        {
            string sql = "select * from li_type_of_request order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }
        public DataTable GetBusinessUnit()
        {
            string sql = "select * from li_business_unit order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblyear.Text = year.Text.Trim();
            var xyear = year.Text.Trim();
            var xbu_code = ddl_bu.SelectedValue;
            var xtoreq_code = type_req.SelectedValue;

            string sql = "select req.process_id,req.toreq_code,req.req_no,req.req_date,req.[status],req.bu_code,bu.bu_desc from li_insurance_request as req inner join li_business_unit as bu on bu.bu_code = req.bu_code where year(req_date) = "+ xyear + " and toreq_code = "+ xtoreq_code + " and req.bu_code = "+ xbu_code;
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);

            resGV.DataSource = dt;
            resGV.DataBind();
        }
    }
}