using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.userControls
{
    public partial class ucCommentlogdata : System.Web.UI.UserControl
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ini_data();
            }
        }
        public void ini_object(string xPID)
        {
            hidPID.Value = xPID;
        }

        private void ini_data()
        {
            string sql = "select * from wf_comment_log where pid = '" + hidPID.Value + "' ";

            var ds = zdb.ExecSql_DataSet(sql, zconnstr);

            commentGV.DataSource = ds;
            commentGV.DataBind();

        }
    }
}