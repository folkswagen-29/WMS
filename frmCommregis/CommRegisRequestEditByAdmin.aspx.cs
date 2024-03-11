using DocumentFormat.OpenXml.Office2010.Excel;
using iTextSharp.text.pdf;
using onlineLegalWF.Class;
using onlineLegalWF.userControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static onlineLegalWF.Class.ReplaceCommRegis;

namespace onlineLegalWF.frmCommregis
{
    public partial class CommRegisRequestEditByAdmin : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public string zconnstrrpa = ConfigurationManager.AppSettings["RPADB"].ToString();
        public WFFunctions zwf = new WFFunctions();
        public ReplaceCommRegis zreplacecommregis = new ReplaceCommRegis();
        public SendMail zsendmail = new SendMail();
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

            string js = "$('#section1').hide();";
            if (type_comm_regis.SelectedValue == "01")
            {
                js += "$('#section1').show();$('.subsidiary').hide();$('.company').show();$('.moresubsidiary').hide();";
            }
            else if (type_comm_regis.SelectedValue == "02")
            {
                js += "$('#section2').show();$('.subsidiary').show();$('.company').show();$('.moresubsidiary').hide();";
            }
            else if (type_comm_regis.SelectedValue == "03")
            {
                js += "$('#section3').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }
            else if (type_comm_regis.SelectedValue == "04")
            {
                js += "$('#section4').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }
            else if (type_comm_regis.SelectedValue == "05")
            {
                js += "$('#section5').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }
            else if (type_comm_regis.SelectedValue == "06")
            {
                js += "$('#section6').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }
            else if (type_comm_regis.SelectedValue == "07")
            {
                js += "$('#section7').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }
            else if (type_comm_regis.SelectedValue == "08")
            {
                js += "$('#section8').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }
            else if (type_comm_regis.SelectedValue == "09")
            {
                js += "$('#section9').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }
            else if (type_comm_regis.SelectedValue == "10")
            {
                js += "$('#section10').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }
            else if (type_comm_regis.SelectedValue == "11")
            {
                js += "$('#section11').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }
            else if (type_comm_regis.SelectedValue == "12")
            {
                js += "$('#section12').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }
            else if (type_comm_regis.SelectedValue == "13")
            {
                js += "$('#section13').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }
            else if (type_comm_regis.SelectedValue == "14")
            {
                js += "$('#section14').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "changeType", js, true);
        }

        private void setDataDDL()
        {
            ucHeader1.setHeader("Commercial Registration Request Admin Edit");

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

            //cb_subsidiary_multi.DataSource = GetSubsidiary();
            //cb_subsidiary_multi.DataBind();
            //cb_subsidiary_multi.DataTextField = "subsidiary_name_th";
            //cb_subsidiary_multi.DataValueField = "subsidiary_code";
            //cb_subsidiary_multi.DataBind();
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
                cb_more.Checked = Convert.ToBoolean(res.Rows[0]["ismoresubsidiary"].ToString());

                type_comm_regis.Enabled = false;
                ddl_subsidiary.Enabled = false;
                mt_res_desc.Enabled = false;
                mt_res_no.Enabled = false;
                mt_res_date.Enabled = false;
                cb_more.Enabled = false;

                if (cb_more.Checked)
                {
                    string sqladditional = @"select [req_no],commaddi.[subsidiary_code],commsub.[subsidiary_name_th],[assto_login],[status],[created_datetime]
                                                ,[updated_datetime] from li_comm_regis_request_additional as commaddi
                                                inner join li_comm_regis_subsidiary as commsub on commaddi.subsidiary_code = commsub.subsidiary_code
                                                where req_no='" + id + "'";
                    var resadditional = zdb.ExecSql_DataTable(sqladditional, zconnstr);



                    if (resadditional.Rows.Count > 0)
                    {
                        var dt = iniDTStructure();
                        int no = 0;

                        foreach (DataRow item in resadditional.Rows)
                        {
                            var dr = dt.NewRow();
                            dr = dt.NewRow();
                            dr["No"] = (no + 1);
                            dr["req_no"] = item["req_no"].ToString();
                            dr["subsidiary_code"] = item["subsidiary_code"].ToString();
                            dr["subsidiary_name_th"] = item["subsidiary_name_th"].ToString();
                            dr["assto_login"] = item["assto_login"].ToString();
                            dr["status"] = item["status"].ToString();
                            dr["created_datetime"] = Convert.ToDateTime(item["created_datetime"]).ToString("yyyy-MM-dd");
                            dr["updated_datetime"] = (!string.IsNullOrEmpty(item["updated_datetime"].ToString()) ? Convert.ToDateTime(item["updated_datetime"]).ToString("yyyy-MM-dd") : "");
                            dt.Rows.Add(dr);
                            no++;
                        }

                        gv1.DataSource = dt;
                        gv1.DataBind();

                    }
                }

                string js = "$('#section1').hide();";
                if (type_comm_regis.SelectedValue == "01")
                {
                    js += "$('#section1').show();$('.subsidiary').hide();$('.company').show();$('.moresubsidiary').hide();";
                }
                else if (type_comm_regis.SelectedValue == "02")
                {
                    js += "$('#section2').show();$('.subsidiary').show();$('.company').show();$('.moresubsidiary').hide();";
                }
                else if (type_comm_regis.SelectedValue == "03")
                {
                    js += "$('#section3').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }
                else if (type_comm_regis.SelectedValue == "04")
                {
                    js += "$('#section4').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }
                else if (type_comm_regis.SelectedValue == "05")
                {
                    js += "$('#section5').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }
                else if (type_comm_regis.SelectedValue == "06")
                {
                    js += "$('#section6').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }
                else if (type_comm_regis.SelectedValue == "07")
                {
                    js += "$('#section7').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }
                else if (type_comm_regis.SelectedValue == "08")
                {
                    js += "$('#section8').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }
                else if (type_comm_regis.SelectedValue == "09")
                {
                    js += "$('#section9').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }
                else if (type_comm_regis.SelectedValue == "10")
                {
                    js += "$('#section10').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }
                else if (type_comm_regis.SelectedValue == "11")
                {
                    js += "$('#section11').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }
                else if (type_comm_regis.SelectedValue == "12")
                {
                    js += "$('#section12').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }
                else if (type_comm_regis.SelectedValue == "13")
                {
                    js += "$('#section13').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }
                else if (type_comm_regis.SelectedValue == "14")
                {
                    js += "$('#section14').show();$('.subsidiary').show();$('.company').hide();$('.moresubsidiary').show();if ($('#ContentPlaceHolder1_cb_more').is(':checked') == true) {$('.more_cb_sub').show();}else {$('.more_cb_sub').hide();}";
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "changeType", js, true);
            }
        }

        public DataTable iniDTStructure()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("no", typeof(string));
            dt.Columns.Add("req_no", typeof(string));
            dt.Columns.Add("subsidiary_code", typeof(string));
            dt.Columns.Add("subsidiary_name_th", typeof(string));
            dt.Columns.Add("assto_login", typeof(string));
            dt.Columns.Add("status", typeof(string));
            dt.Columns.Add("created_datetime", typeof(string));
            dt.Columns.Add("updated_datetime", typeof(string));
            return dt;
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "openModal")
            {
                int i = System.Convert.ToInt32(e.CommandArgument);
                var xreq_no = ((HiddenField)gv1.Rows[i].FindControl("gv1txtreq_no")).Value;
                var xsubsidiary_code = ((HiddenField)gv1.Rows[i].FindControl("gv1txtsubsidiary_code")).Value;
                var xassto_login = ((Label)gv1.Rows[i].FindControl("gv1txtassto_login")).Text;
                var xstatus = ((Label)gv1.Rows[i].FindControl("gv1txtstatus")).Text;

                if (!string.IsNullOrEmpty(xassto_login)) 
                {
                    ddlNameList.SelectedValue = xassto_login;
                }

                rdlAction.SelectedValue = xstatus;
                md_req_no.Value = xreq_no;
                md_subsidiary_code.Value = xsubsidiary_code;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalEditData();", true);
            }
        }

        protected void Assign_Update_Click(object sender, EventArgs e)
        {
            var xreq_no = md_req_no.Value.Trim();
            var xsubsidiary_code = md_subsidiary_code.Value.Trim();
            var xassto_login = ddlNameList.SelectedValue.Trim();
            var xstatus = rdlAction.SelectedValue.Trim();
            var xupdate_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            int ret = 0;
            string sqlupdate = @"update li_comm_regis_request_additional
                                   set assto_login = '"+ xassto_login +@"'
                                      ,status = '"+ xstatus +@"'
                                      ,updated_datetime = '"+ xupdate_date +@"'
                                 where req_no = '"+ xreq_no +"' and subsidiary_code = '"+ xsubsidiary_code +"'";

            ret = zdb.ExecNonQueryReturnID(sqlupdate, zconnstr);
            if (ret > 0)
            {
                Response.Write("<script>alert('Successfully Updated');</script>");
                setDataEditRequest(xreq_no);

                if (xstatus == "In Progress") 
                {
                    //send mail
                    string subject = "";
                    string body = "";
                    string sqlmail = @"SELECT [process_id],commreg.[req_no],[req_date],commreg.[toc_regis_code],toc.[toc_regis_desc],[document_no],addi.subsidiary_code,comsub.subsidiary_name_th
                                        FROM li_comm_regis_request AS commreg
										INNER JOIN li_comm_regis_request_additional as addi on commreg.req_no = addi.req_no
                                        LEFT OUTER JOIN li_comm_regis_subsidiary AS comsub ON addi.subsidiary_code = comsub.subsidiary_code
                                        INNER JOIN li_type_of_comm_regis AS toc ON commreg.toc_regis_code = toc.toc_regis_code
										where commreg.[req_no] = '" + xreq_no + "' and addi.subsidiary_code = '"+xsubsidiary_code+"'";
                    var dt = zdb.ExecSql_DataTable(sqlmail, zconnstr);
                    if (dt.Rows.Count > 0)
                    {
                        var dr = dt.Rows[0];
                        string id = dr["req_no"].ToString();
                        subject = "เรื่อง "+ dr["toc_regis_desc"].ToString().Trim() +" "+ dr["subsidiary_name_th"].ToString().Trim();
                        var host_url = ConfigurationManager.AppSettings["host_url"].ToString();
                        body = "คุณได้รับมอบหมายงาน " + dr["document_no"].ToString() + " กรุณาตรวจสอบและดำเนินการผ่านระบบ <a target='_blank' href='"+host_url+"frmcommregis/commregisrequesteditbyadmin.aspx?id=" + xreq_no+"'>Click</a>";



                        string pathfileins = "";

                        string sqlfile = "select top 1 * from z_replacedocx_log where replacedocx_reqno='" + id + "' order by row_id desc";

                        var resfile = zdb.ExecSql_DataTable(sqlfile, zconnstr);

                        if (resfile.Rows.Count > 0)
                        {
                            pathfileins = resfile.Rows[0]["output_filepath"].ToString().Replace(".docx", ".pdf");

                            string email = "";

                            var isdev = ConfigurationManager.AppSettings["isDev"].ToString();
                            ////get mail from db
                            /////send mail to next_approve
                            if (isdev != "true")
                            {
                                string sqlbpm = "select * from li_user where user_login = '" + xassto_login + "' ";
                                System.Data.DataTable dtbpm = zdb.ExecSql_DataTable(sqlbpm, zconnstr);

                                if (dtbpm.Rows.Count > 0)
                                {
                                    email = dtbpm.Rows[0]["email"].ToString();

                                }
                                else
                                {
                                    string sqlpra = "select * from Rpa_Mst_HrNameList where Login = 'ASSETWORLDCORP-\\" + xassto_login + "' ";
                                    System.Data.DataTable dtrpa = zdb.ExecSql_DataTable(sqlpra, zconnstrrpa);

                                    if (dtrpa.Rows.Count > 0)
                                    {
                                        email = dtrpa.Rows[0]["Email"].ToString();
                                    }
                                    else
                                    {
                                        email = "";
                                    }

                                }
                            }
                            else
                            {
                                ////fix mail test
                                email = "legalwfuat2024@gmail.com";
                            }

                            if (!string.IsNullOrEmpty(email))
                            {
                                _ = zsendmail.sendEmail(subject , email, body, pathfileins);
                            }

                        }

                    }
                }
            }
            else 
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
        }
    }
}