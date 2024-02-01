using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.userControls
{
    public partial class ucTaskList : System.Web.UI.UserControl
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["RPADB"].ToString();
        public string zconnstrbpm = ConfigurationManager.AppSettings["BPMDB"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
            {
                bind_gv();
            }
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
            dt.Columns.Add("AssignTo", typeof(string));
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
                case "myrequest": {
                        bind_gv1(getMyRequest()); 
                     };break;
                case "myworklist":
                    {
                        bind_gv1(getMyWorkList()); 
                    }; break;
                case "completelist":
                    {
                        bind_gv1(getCompleteList()); 
                    }; break;
               
            }
        }
        public DataTable getMyRequest()
        {
            var host_url = ConfigurationManager.AppSettings["host_url"].ToString(); 
            //string sql = "Select process_id,subject,submit_by,updated_by,created_datetime,wf_status,updated_datetime, ( '" + host_url+ "' + link_url_format) as link_url_format from " +
            //    "wf_routing where process_id in (Select process_id from wf_routing where submit_by = '"+ hidLogin.Value + "' and wf_status in ('SAVE','WAITATCH')) and wf_status in ('SAVE','WAITATCH')";
            string sql = "Select assto_login,process_id,subject,submit_by,updated_by,created_datetime,wf_status,updated_datetime,"+
                            "CASE "+
                                "WHEN step_name = 'Start' or wf_status in ('SAVE', 'WAITATCH') THEN ('" + host_url+ "' + link_url_format) " +
                                "ELSE '"+host_url+"legalPortal/legalportal?m=myrequest#' " +
                            "END AS link_url_format "+
                            "from wf_routing where submit_by = '"+ hidLogin.Value + "'" +
                            " and row_id in (select tb1.row_id from "+
                            "(SELECT process_id, "+
                            "MAX(row_id) as row_id "+
                            "FROM wf_routing where submit_by = '"+ hidLogin.Value + "'" +
                            "GROUP BY  process_id)as tb1) and step_name not in ('End')";

            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstrbpm);

            return dt;
        }
        public DataTable getMyWorkList()
        {
            var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
            string sql = "Select assto_login,process_id,subject,submit_by,updated_by,created_datetime,wf_status,updated_datetime, ( '" + host_url + "' + link_url_format) as link_url_format from " +
                "wf_routing where process_id in (Select process_id from wf_routing where assto_login like '" + hidLogin.Value + "' and submit_answer = '') and submit_answer = ''";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstrbpm);

            return dt;
        }
        public DataTable getCompleteList()
        {
            var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
            string sql = "Select assto_login,process_id,subject,submit_by,updated_by,created_datetime,wf_status,updated_datetime, ( '" + host_url + "' + link_url_format) as link_url_format from " +
                "wf_routing where process_id in (Select process_id from wf_routing where submit_by = '" + hidLogin.Value + "' and step_name = 'End') and step_name = 'End'";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstrbpm);

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