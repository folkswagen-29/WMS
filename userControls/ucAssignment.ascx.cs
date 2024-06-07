using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.userControls
{
    public partial class ucAssignment : System.Web.UI.UserControl
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public string zpath_attachment = ConfigurationManager.AppSettings["path_attachment"].ToString();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                iniData(); 
            }
        }
        public void bindData(string xpid)
        {
            hidPID.Value = xpid;
            iniData(); 
        }
        public void iniData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("no", typeof(string));
            dt.Columns.Add("assignto", typeof(string));
            dt.Columns.Add("detail", typeof(string));
            dt.Columns.Add("taskstatus", typeof(string));
            dt.Columns.Add("remark", typeof(string));
            var dr = dt.NewRow(); 
            for (int i =0; i < 2; i++)
            {
                dr = dt.NewRow();
                dr["no"] = (i+1).ToString("0");
                dr["assignto"] = " ";
                dr["detail"] = "";
                dr["taskstatus"] = "";
                dr["remark"] = "";
                dt.Rows.Add(dr);
            }
            bind_gv(dt);
        }
        private void bind_gv(DataTable dt)
        {
            gv1.DataSource = dt;
            gv1.DataBind(); 

        }
    }
}