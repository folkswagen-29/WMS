using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.userControls
{
    public partial class ucCommentlog : System.Web.UI.UserControl
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string xpid = hidPID.Value;
            string xcomment = comment.Text.Trim();
            string xcreate_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", new CultureInfo("en-US"));
            string xby_login = Session["user_login"].ToString();

            // insert into db
            string sql = @"INSERT INTO [dbo].[wf_comment_log] 
                                        ([pid],[comment],[by_login],[created_datetime])
                                         VALUES
                                               ('" + xpid + @"'
                                               ,'" + xcomment + @"'
                                               ,'" + xby_login + @"'
                                               ,'" + xcreate_date + @"')";
            zdb.ExecNonQuery(sql, zconnstr);

            ini_data();
            comment.Text = "";
        }
    }
}