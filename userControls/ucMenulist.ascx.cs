using onlineLegalWF.frmInsurance;
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
    public partial class ucMenulist : System.Web.UI.UserControl
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        //public string zconnstr = ConfigurationSettings.AppSettings["BMPDB"].ToString();
        public string zconnstr = ConfigurationManager.AppSettings["BMPDB"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
            
            }
        }
        public void bind_menu(string userrole)
        {
            var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
            string sql = @"select * from (
                            select distinct menu_code, menu_group_name, ( '"+host_url+@"' + menu_icon_filename) as menu_icon_filename , row_sort

            from m_portal_menu where menu_url = '' ) as t1 
							order by t1.row_sort

            ";
           
            var ds = zdb.ExecSql_DataSet(sql, zconnstr);
            gv.DataSource = ds.Tables[0];
            gv.DataBind(); 

        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
            if (e.CommandName == "expandmenu") 
            {
                
                int i = System.Convert.ToInt32(e.CommandArgument);
                //gv.Rows[i].FindControl("gvlbtnMenu").Focus();
                var xmenu_group_name = ((Label)gv.Rows[i].FindControl("gvlblMenuGroupName")).Text;
                var gvA = ((GridView)gv.Rows[i].FindControl("gvA"));
                string sql = @"
           select  menu_code, menu_name, ( '" + host_url + @"' + menu_icon_filename) as menu_icon_filename, menu_url , row_sort

            from m_portal_menu 
            where menu_group_name = '"+ xmenu_group_name + @"' and menu_url <> '' 
            order by row_sort";
                var ds = zdb.ExecSql_DataSet(sql, zconnstr);
                gvA.DataSource = ds;
                gvA.DataBind(); 
            }
        }
        private void bind_gvA(DataSet ds)
        {

        }
        //gvA_RowCommand
        protected void gvA_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
            //string xurl = "";
            if (e.CommandName == "openprogram")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridView grid = sender as GridView;

                //var xmenu_code = ((Label)grid.Rows[index].FindControl("gvAlblMenuCode")).Text;
                var xurl = ((Label)grid.Rows[index].FindControl("gvAlblMenuUrl")).Text;
                Response.Redirect(xurl);

            }
        }
    }
}