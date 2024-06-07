using WMS.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WMS.userControls
{
    public partial class ucWorkflowlist : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // iniData(); 
            }
        }
        public void iniData()
        {
            var dt = iniDataTable();
            gv1.DataSource = dt;
            gv1.DataBind();
        }
        public DataTable iniDataTable()
        {
            //getData
            var dt = iniDTStructure();
            var dr = dt.NewRow();
            dr["No"] = "1";
            dr["processid"] = "0001";
            dr["processname"] = "Insurance - New Request";
            dr["documentno"] = "li2307001";
            dr["subject"] = "Request new insurance xxx";
            dr["requesteddate"] = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            dr["status"] = "New";
            dt.Rows.Add(dr);
            return dt;
        }
        public DataTable iniDTStructure()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(string));
            dt.Columns.Add("ProcessID", typeof(string));
            dt.Columns.Add("ProcessName", typeof(string));
            dt.Columns.Add("DocumentNo", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("RequestedDate", typeof(string));
            dt.Columns.Add("SubmittedDate", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            return dt;
        }
        public void LoadData(DataTable dt, string mode)
        {
            gv1.DataSource = dt;
            gv1.DataBind();
            hidMode.Value = mode;
        }

        protected void Assign_Click(object sender, EventArgs e)
        {
            //process_id.Text = "I am called";
            submitted_date.Text = Utillity.ConvertDateToLongDateTime(System.DateTime.Now, "en");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        protected void btn_assign_Click(object sender, EventArgs e)
        {
            //lblMessage.Text = "I am Assign";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
    }
}