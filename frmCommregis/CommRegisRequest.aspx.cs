using Newtonsoft.Json.Linq;
using onlineLegalWF.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace onlineLegalWF.frmCommregis
{
    public partial class CommRegisRequest : System.Web.UI.Page
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
            ucHeader1.setHeader("Commercial Registration Request");
            string xreq_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            req_no.Text = xreq_no;

            type_comm_regis.DataSource = GetTypeOfRequest();
            type_comm_regis.DataBind();
            type_comm_regis.DataTextField = "toc_regis_desc";
            type_comm_regis.DataValueField = "toc_regis_code";
            type_comm_regis.DataBind();

            ddl_subsidiary.DataSource = GetSubsidiary();
            ddl_subsidiary.DataBind();
            ddl_subsidiary.DataTextField = "subsidiary_name_th";
            ddl_subsidiary.DataValueField = "subsidiary_code";
            ddl_subsidiary.DataBind();

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

        public DataTable GetSubsidiary()
        {
            string sql = "select * from li_comm_regis_subsidiary order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int ret = 0;
            string xtype_comm_regis = type_comm_regis.SelectedValue;

            if (doc_no.Text.Trim() == "")
            {
                doc_no.Text = zwf.genDocNo("CCR-" + System.DateTime.Now.ToString("yyyy", new CultureInfo("en-US")) + "-", 4);
            }

            var xdoc_no = doc_no.Text.Trim();
            var xreq_no = req_no.Text.Trim();
            var xprocess_id = hid_PID.Value.ToString();
            var xreq_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xmt_res_desc = mt_res_desc.Text.Trim();
            var xmt_res_no = mt_res_no.Text.Trim();
            var xmt_res_date = mt_res_date.Text.Trim();
            var xstatus = "verify";

            string sql = "";

            if (xtype_comm_regis == "02") 
            {
                var xcompany_name_th = company_name_th.Text.Trim();
                var xcompany_name_en = company_name_en.Text.Trim();
                var xddl_subsidiary = ddl_subsidiary.SelectedValue;

                sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[subsidiary_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[company_name_th],[company_name_en],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'" + xtype_comm_regis + @"'
                               ,'" + xddl_subsidiary + @"'
                               ,'" + xdoc_no + @"'
                               ,'" + xmt_res_desc + @"'
                               ,'" + xmt_res_no + @"'
                               ,'" + xmt_res_date + @"'
                               ,'" + xcompany_name_th + @"'
                               ,'" + xcompany_name_en + @"'
                               ,'" + xstatus + @"')";

                ret = zdb.ExecNonQueryReturnID(sql, zconnstr);

                if (ret > 0) 
                {
                    string sqlupdate = @"UPDATE [dbo].[li_comm_regis_subsidiary]
                                           SET [subsidiary_name_th] = '"+ xcompany_name_th + @"'
                                              ,[subsidiary_name_en] = '"+ xcompany_name_en + @"'
                                         WHERE subsidiary_code = '"+ xddl_subsidiary +"'";

                    zdb.ExecNonQuery(sqlupdate, zconnstr);
                }
            }
            else 
            {
                if (xtype_comm_regis == "01")
                {
                    var xisrdregister = sec1_cb_rd.Checked;
                    var xcompany_name_th = company_name_th.Text.Trim();
                    var xcompany_name_en = company_name_en.Text.Trim();
                    sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[company_name_th],[company_name_en],[isrdregister],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'" + xtype_comm_regis + @"'
                               ,'" + xdoc_no + @"'
                               ,'" + xmt_res_desc + @"'
                               ,'" + xmt_res_no + @"'
                               ,'" + xmt_res_date + @"'
                               ,'" + xcompany_name_th + @"'
                               ,'" + xcompany_name_en + @"'
                               ,'" + xisrdregister + @"'
                               ,'" + xstatus + @"')";

                    ret = zdb.ExecNonQueryReturnID(sql, zconnstr);
                }
                else 
                {
                    var xddl_subsidiary = ddl_subsidiary.SelectedValue;
                    var xisrdregister = false;

                    if (xtype_comm_regis == "06") 
                    {
                        xisrdregister = sec6_cb_rd.Checked;
                    }

                    if (xtype_comm_regis == "08")
                    {
                        xisrdregister = sec8_cb_rd.Checked;
                    }

                    sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[subsidiary_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[company_name_th],[company_name_en],[isrdregister],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'" + xtype_comm_regis + @"'
                               ,'" + xddl_subsidiary + @"'
                               ,'" + xdoc_no + @"'
                               ,'" + xmt_res_desc + @"'
                               ,'" + xmt_res_no + @"'
                               ,'" + xmt_res_date + @"'
                               ,'" + xisrdregister + @"'
                               ,'" + xstatus + @"')";

                    ret = zdb.ExecNonQueryReturnID(sql, zconnstr);
                }
            }

            if (ret > 0)
            {
                Response.Write("<script>alert('Successfully Insert');</script>");
                var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
                Response.Redirect(host_url + "frmCommregis/CommRegisRequestEdit.aspx?id=" + req_no.Text.Trim());
            }
            else 
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {

        }

    }
}