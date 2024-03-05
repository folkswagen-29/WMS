using DocumentFormat.OpenXml.ExtendedProperties;
using onlineLegalWF.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmCommregis
{
    public partial class CommRegisRequestEdit : System.Web.UI.Page
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
                setDataDDL();

                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    setDataEditRequest(id);
                }

            }
        }

        private void setDataDDL()
        {
            ucHeader1.setHeader("Edit Request");

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

        private void setDataEditRequest(string id)
        {
            string sql = "select * from li_comm_regis_request where req_no='" + id + "'";

            var res = zdb.ExecSql_DataTable(sql, zconnstr);

            if (res.Rows.Count > 0)
            {
                req_no.Text = res.Rows[0]["req_no"].ToString();
                req_date.Value = Convert.ToDateTime(res.Rows[0]["req_date"]).ToString("yyyy-MM-dd");
                type_comm_regis.SelectedValue = res.Rows[0]["toc_regis_code"].ToString();
                if (!string.IsNullOrEmpty(res.Rows[0]["subsidiary_code"].ToString())) 
                {
                    ddl_subsidiary.SelectedValue = res.Rows[0]["subsidiary_code"].ToString();
                }
                doc_no.Text = res.Rows[0]["document_no"].ToString();
                mt_res_no.Text = res.Rows[0]["mt_res_no"].ToString();
                mt_res_desc.Text = res.Rows[0]["mt_res_desc"].ToString();
                mt_res_date.Text = Convert.ToDateTime(res.Rows[0]["mt_res_date"]).ToString("yyyy-MM-dd");
                company_name_th.Text = res.Rows[0]["company_name_th"].ToString();
                company_name_en.Text = res.Rows[0]["company_name_en"].ToString();
                lblPID.Text = res.Rows[0]["process_id"].ToString();
                hid_PID.Value = res.Rows[0]["process_id"].ToString();
                ucAttachment1.ini_object(res.Rows[0]["process_id"].ToString());
                ucCommentlog1.ini_object(res.Rows[0]["process_id"].ToString());

                string js = "$('#section1').hide();";
                if (type_comm_regis.SelectedValue == "01") 
                {
                    if (Convert.ToBoolean(res.Rows[0]["isrdregister"].ToString())) 
                    {
                        sec1_cb_rd.Checked = true;
                    }
                    js += "$('#section1').show();$('.subsidiary').hide();$('.company').show();";
                }
                else if (type_comm_regis.SelectedValue == "02")
                {
                    js += "$('#section2').show();$('.subsidiary').show();$('.company').show();";
                }
                else if (type_comm_regis.SelectedValue == "03")
                {
                    js += "$('#section3').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "04")
                {
                    js += "$('#section4').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "05")
                {
                    js += "$('#section5').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "06")
                {
                    if (Convert.ToBoolean(res.Rows[0]["isrdregister"].ToString()))
                    {
                        sec6_cb_rd.Checked = true;
                    }
                    js += "$('#section6').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "07")
                {
                    js += "$('#section7').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "08")
                {
                    if (Convert.ToBoolean(res.Rows[0]["isrdregister"].ToString()))
                    {
                        sec8_cb_rd.Checked = true;
                    }
                    js += "$('#section8').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "09")
                {
                    js += "$('#section9').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "10")
                {
                    js += "$('#section10').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "11")
                {
                    js += "$('#section11').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "12")
                {
                    js += "$('#section12').show();$('.subsidiary').show();$('.company').hide();";
                }
                else if (type_comm_regis.SelectedValue == "13")
                {
                    js += "$('#section13').show();$('.subsidiary').show();$('.company').hide();";
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "changeType", js, true);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

        }

        private int UpdateRequest()
        {
            int ret = 0;

            string xtype_comm_regis = type_comm_regis.SelectedValue;
            var xreq_no = req_no.Text.Trim();
            var xupdate_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xmt_res_desc = mt_res_desc.Text.Trim();
            var xmt_res_no = mt_res_no.Text.Trim();
            var xmt_res_date = mt_res_date.Text.Trim();
            var xddl_subsidiary = ddl_subsidiary.SelectedValue;

            string sql = "";

            if (xtype_comm_regis == "02")
            {
                var xcompany_name_th = company_name_th.Text.Trim();
                var xcompany_name_en = company_name_en.Text.Trim();

                sql = @"UPDATE [dbo].[li_comm_regis_request]
                           SET [mt_res_desc] = '"+ xmt_res_desc +@"'
                              ,[mt_res_no] = '" +xmt_res_no+ @"'
                              ,[mt_res_date] = '"+ xmt_res_date + @"'
                              ,[toc_regis_code] = '" + xtype_comm_regis + @"'
                              ,[subsidiary_code] = '" + xddl_subsidiary + @"'
                              ,[company_name_th] = '"+ xcompany_name_th +@"'
                              ,[company_name_en] = '"+ xcompany_name_en +@"'
                              ,[updated_datetime] = '" + xupdate_date + @"'
                         WHERE [req_no] = '"+ xreq_no + "'";

                ret = zdb.ExecNonQueryReturnID(sql, zconnstr);
            }
            else
            {
                if (xtype_comm_regis == "01")
                {
                    var xisrdregister = sec1_cb_rd.Checked;
                    var xcompany_name_th = company_name_th.Text.Trim();
                    var xcompany_name_en = company_name_en.Text.Trim();
                    sql = @"UPDATE [dbo].[li_comm_regis_request]
                           SET [mt_res_desc] = '" + xmt_res_desc + @"'
                              ,[mt_res_no] = '" + xmt_res_no + @"'
                              ,[mt_res_date] = '" + xmt_res_date + @"'
                              ,[toc_regis_code] = '" + xtype_comm_regis + @"'
                              ,[company_name_th] = '"+ xcompany_name_th +@"'
                              ,[company_name_en] = '"+ xcompany_name_en +@"'
                              ,[isrdregister] = '" + xisrdregister + @"'
                              ,[updated_datetime] = '" + xupdate_date + @"'
                         WHERE [req_no] = '" + xreq_no + "'";

                    ret = zdb.ExecNonQueryReturnID(sql, zconnstr);
                }
                else
                {
                    var xisrdregister = false;

                    if (xtype_comm_regis == "06")
                    {
                        xisrdregister = sec6_cb_rd.Checked;
                    }

                    if (xtype_comm_regis == "08")
                    {
                        xisrdregister = sec8_cb_rd.Checked;
                    }

                    sql = @"UPDATE [dbo].[li_comm_regis_request]
                           SET [mt_res_desc] = '" + xmt_res_desc + @"'
                              ,[mt_res_no] = '" + xmt_res_no + @"'
                              ,[mt_res_date] = '" + xmt_res_date + @"'
                              ,[toc_regis_code] = '" + xtype_comm_regis + @"'
                              ,[subsidiary_code] = '" + xddl_subsidiary + @"'
                              ,[isrdregister] = '" + xisrdregister + @"'
                              ,[updated_datetime] = '" + xupdate_date + @"'
                         WHERE [req_no] = '" + xreq_no + "'";

                    ret = zdb.ExecNonQueryReturnID(sql, zconnstr);
                }
            }


            return ret;
        }
    }
}