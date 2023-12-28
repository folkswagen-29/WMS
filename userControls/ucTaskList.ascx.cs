using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.userControls
{
    public partial class ucTaskList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void bindData(string xlogin_name, string xmode)
        {
            hidLogin.Value = xlogin_name;
            hidMode.Value = xmode; 

        }
        public DataTable getDataStructure() 
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No",typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("RequestBy", typeof(string));
            dt.Columns.Add("SubmittedDate", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("LastUpdated", typeof(string));
            dt.Columns.Add("LastUpdatedBy", typeof(string));
            return dt; 
        }
        public DataTable ini_data()
        {
            var dt = getDataStructure(); 
            for (int i = 1; i<=1; i++)
            {
                var dr = dt.NewRow();
                dr["No"] = i.ToString();
                dt.Rows.Add(dr); 
            }
            return dt; 
        }
        public void bind_gv()
        {
            switch  (hidMode.Value)
            {
                case "MyRequest": {
                        getMyRequest(); 
                     };break;
                case "MyWorkList":
                    {
                        getMyWorkList(); 
                    }; break;
                case "CompleteList":
                    {
                        getCompleteList(); 
                    }; break;
               
            }
        }
        public DataTable getMyRequest()
        {
            var dt = ini_data();
           
            return dt; 
        }
        public DataTable getMyWorkList()
        {
            var dt = ini_data();
            return dt;
        }
        public DataTable getCompleteList()
        {
            var dt = ini_data();
            return dt;
        }
        #region gv1
        public void bind_gv1(DataTable dt)
        {
            gv1.DataSource = dt;
            gv1.DataBind(); 
        }
        #endregion 
    }
}