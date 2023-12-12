using onlineLegalWF.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmCommregis
{
    public partial class CommRegisRequest : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        //public string zconnstr = ConfigurationSettings.AppSettings["BMPDB"].ToString();
        public string zconnstr = ConfigurationManager.AppSettings["BMPDB"].ToString();
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
            ucHeader1.setHeader("Commercial Registration Request");
            string xreq_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            req_no.Text = xreq_no;

            type_comm_regis.DataSource = GetTypeOfRequest();
            type_comm_regis.DataBind();
            type_comm_regis.DataTextField = "toc_regis_desc";
            type_comm_regis.DataValueField = "toc_regis_code";
            type_comm_regis.DataBind();

            string pid = zwf.iniPID("LEGALWF");
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucCommentlog1.ini_object(pid);
        }

        public DataTable GetTypeOfRequest()
        {
            string sql = "select * from li_type_of_comm_regis order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {

        }
    }
}