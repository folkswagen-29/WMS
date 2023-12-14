using onlineLegalWF.Class;
using onlineLegalWF.userControls;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceClaimEdit : System.Web.UI.Page
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

                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    setDataEditClaimRequest(id);
                }

            }
        }

        private void setDataEditClaimRequest(string id) 
        {
            ucHeader1.setHeader("Claim Edit Request");

            ddl_bu.DataSource = GetBusinessUnit();
            ddl_bu.DataBind();
            ddl_bu.DataTextField = "bu_desc";
            ddl_bu.DataValueField = "bu_code";
            ddl_bu.DataBind();

            string sql = "select * from li_insurance_claim where claim_no='" + id + "'";

            var res = zdb.ExecSql_DataTable(sql, zconnstr);

            if (res.Rows.Count > 0)
            {
                claim_no.Value = res.Rows[0]["claim_no"].ToString();
                claim_date.Value = Convert.ToDateTime(res.Rows[0]["claim_date"]).ToString("yyyy-MM-dd");
                company_name.Text = res.Rows[0]["company_name"].ToString();
                doc_no.Text = res.Rows[0]["document_no"].ToString();
                ddl_bu.SelectedValue = res.Rows[0]["bu_code"].ToString();
                incident.Text = res.Rows[0]["incident"].ToString();
                occurred_date.Text = Convert.ToDateTime(res.Rows[0]["claim_date"]).ToString("yyyy-MM-dd");
                submission_date.Text = Convert.ToDateTime(res.Rows[0]["submission_date"]).ToString("yyyy-MM-dd");
                incident_summary.Text = res.Rows[0]["incident_summary"].ToString();
                surveyor_name.Text = res.Rows[0]["surveyor_name"].ToString();
                surveyor_company.Text = res.Rows[0]["surveyor_company"].ToString();
                settlement_date.Text = Convert.ToDateTime(res.Rows[0]["settlement_date"]).ToString("yyyy-MM-dd");
                settlement_day.Text = res.Rows[0]["settlement_day"].ToString();
                iar_atc.Text = res.Rows[0]["iar_atc"].ToString();
                iar_ded.Text = res.Rows[0]["iar_ded"].ToString();
                iar_pfc.Text = res.Rows[0]["iar_pfc"].ToString();
                iar_uatc.Text = res.Rows[0]["iar_uatc"].ToString();
                bi_atc.Text = res.Rows[0]["bi_atc"].ToString();
                bi_ded.Text = res.Rows[0]["bi_ded"].ToString();
                bi_pfc.Text = res.Rows[0]["bi_pfc"].ToString();
                bi_uatc.Text = res.Rows[0]["bi_uatc"].ToString();
                pl_cgl_atc.Text = res.Rows[0]["pl_cgl_atc"].ToString();
                pl_cgl_ded.Text = res.Rows[0]["pl_cgl_ded"].ToString();
                pl_cgl_pfc.Text = res.Rows[0]["pl_cgl_pfc"].ToString();
                pl_cgl_uatc.Text = res.Rows[0]["pl_cgl_uatc"].ToString();
                pv_atc.Text = res.Rows[0]["pv_atc"].ToString();
                pv_ded.Text = res.Rows[0]["pv_ded"].ToString();
                pv_pfc.Text = res.Rows[0]["pv_pfc"].ToString();
                pv_uatc.Text = res.Rows[0]["pv_uatc"].ToString();
                ttl_atc.Text = res.Rows[0]["ttl_atc"].ToString();
                ttl_ded.Text = res.Rows[0]["ttl_ded"].ToString();
                ttl_pfc.Text = res.Rows[0]["ttl_pfc"].ToString();
                ttl_uatc.Text = res.Rows[0]["ttl_uatc"].ToString();
                remark.Text = res.Rows[0]["remark"].ToString();
                lblPID.Text = res.Rows[0]["process_id"].ToString();
                hid_PID.Value = res.Rows[0]["process_id"].ToString();

                ucAttachment1.ini_object(hid_PID.Value = res.Rows[0]["process_id"].ToString());
                ucCommentlog1.ini_object(hid_PID.Value = res.Rows[0]["process_id"].ToString());
            }
        }

        public DataTable GetBusinessUnit()
        {
            string sql = "select * from li_business_unit order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int res = SaveEditClaim();

            if (res > 0)
            {
                Response.Write("<script>alert('Successfully Edited');</script>");
                Response.Redirect("/frmInsurance/InsuranceClaimList");
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
        }
        private int SaveEditClaim()
        {
            int ret = 0;

            var xcompany_name = company_name.Text.Trim();
            var xclaim_no = claim_no.Value;
            var xclaimupdate_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xdoc_no = doc_no.Text.Trim();
            var xbu_code = ddl_bu.SelectedValue.ToString();
            var xincident = incident.Text.Trim();
            var xoccurred_date = occurred_date.Text.Trim();
            var xsubmission_date = submission_date.Text.Trim();
            var xincident_summary = incident_summary.Text.Trim();
            var xsurveyor_name = surveyor_name.Text.Trim();
            var xsurveyor_company = surveyor_company.Text.Trim();
            var xsettlement_date = settlement_date.Text.Trim();
            var xsettlement_day = settlement_day.Text.Trim();
            var xiar_atc = (!string.IsNullOrEmpty(iar_atc.Text.Trim()) ? iar_atc.Text.Trim() : null);
            var xiar_ded = (!string.IsNullOrEmpty(iar_ded.Text.Trim()) ? iar_ded.Text.Trim() : null);
            var xiar_pfc = (!string.IsNullOrEmpty(iar_pfc.Text.Trim()) ? iar_pfc.Text.Trim() : null);
            var xiar_uatc = (!string.IsNullOrEmpty(iar_uatc.Text.Trim()) ? iar_uatc.Text.Trim() : null);
            var xbi_atc = (!string.IsNullOrEmpty(bi_atc.Text.Trim()) ? bi_atc.Text.Trim() : null);
            var xbi_ded = (!string.IsNullOrEmpty(bi_ded.Text.Trim()) ? bi_ded.Text.Trim() : null);
            var xbi_pfc = (!string.IsNullOrEmpty(bi_pfc.Text.Trim()) ? bi_pfc.Text.Trim() : null);
            var xbi_uatc = (!string.IsNullOrEmpty(bi_uatc.Text.Trim()) ? bi_uatc.Text.Trim() : null);
            var xpl_cgl_atc = (!string.IsNullOrEmpty(pl_cgl_atc.Text.Trim()) ? pl_cgl_atc.Text.Trim() : null);
            var xpl_cgl_ded = (!string.IsNullOrEmpty(pl_cgl_ded.Text.Trim()) ? pl_cgl_ded.Text.Trim() : null);
            var xpl_cgl_pfc = (!string.IsNullOrEmpty(pl_cgl_pfc.Text.Trim()) ? pl_cgl_pfc.Text.Trim() : null);
            var xpl_cgl_uatc = (!string.IsNullOrEmpty(pl_cgl_uatc.Text.Trim()) ? pl_cgl_uatc.Text.Trim() : null);
            var xpv_atc = (!string.IsNullOrEmpty(pv_atc.Text.Trim()) ? pv_atc.Text.Trim() : null);
            var xpv_ded = (!string.IsNullOrEmpty(pv_ded.Text.Trim()) ? pv_ded.Text.Trim() : null);
            var xpv_pfc = (!string.IsNullOrEmpty(pv_pfc.Text.Trim()) ? pv_pfc.Text.Trim() : null);
            var xpv_uatc = (!string.IsNullOrEmpty(pv_uatc.Text.Trim()) ? pv_uatc.Text.Trim() : null);
            var xttl_atc = (!string.IsNullOrEmpty(ttl_atc.Text.Trim()) ? ttl_atc.Text.Trim() : null);
            var xttl_ded = (!string.IsNullOrEmpty(ttl_ded.Text.Trim()) ? ttl_ded.Text.Trim() : null);
            var xttl_pfc = (!string.IsNullOrEmpty(ttl_pfc.Text.Trim()) ? ttl_pfc.Text.Trim() : null);
            var xttl_uatc = (!string.IsNullOrEmpty(ttl_uatc.Text.Trim()) ? ttl_uatc.Text.Trim() : null);
            var xremark = (!string.IsNullOrEmpty(remark.Text.Trim()) ? remark.Text.Trim() : null);

            string sql = @"UPDATE [dbo].[li_insurance_claim]
                               SET [company_name] = '"+ xcompany_name + @"'
                                  ,[document_no] = '" + xdoc_no + @"'
                                  ,[bu_code] = '" + xbu_code + @"'
                                  ,[incident] = '" + xincident + @"'
                                  ,[occurred_date] = '" + xoccurred_date + @"'
                                  ,[submission_date] = '" + xsubmission_date + @"'
                                  ,[incident_summary] = '" + xincident_summary + @"'
                                  ,[surveyor_name] = '" + xsurveyor_name + @"'
                                  ,[surveyor_company] = '" + xsurveyor_company + @"'
                                  ,[settlement_date] = '" + xsettlement_date + @"'
                                  ,[settlement_day] = '" + xsettlement_day + @"'
                                  ,[iar_atc] = '" + xiar_atc + @"'
                                  ,[iar_ded] = '" + xiar_ded + @"'
                                  ,[iar_pfc] = '" + xiar_pfc + @"'
                                  ,[iar_uatc] = '" + xiar_uatc + @"'
                                  ,[bi_atc] = '" + xbi_atc + @"'
                                  ,[bi_ded] = '" + xbi_ded + @"'
                                  ,[bi_pfc] = '" + xbi_pfc + @"'
                                  ,[bi_uatc] = '" + xbi_uatc + @"'
                                  ,[pl_cgl_atc] = '" + xpl_cgl_atc + @"'
                                  ,[pl_cgl_ded] = '" + xpl_cgl_ded + @"'
                                  ,[pl_cgl_pfc] = '" + xpl_cgl_pfc + @"'
                                  ,[pl_cgl_uatc] = '" + xpl_cgl_uatc + @"'
                                  ,[pv_atc] = '" + xpv_atc + @"'
                                  ,[pv_ded] = '" + xpv_ded + @"'
                                  ,[pv_pfc] = '" + xpv_pfc + @"'
                                  ,[pv_uatc] = '" + xpv_uatc + @"'
                                  ,[ttl_atc] = '" + xttl_atc + @"'
                                  ,[ttl_ded] = '" + xttl_ded + @"'
                                  ,[ttl_pfc] = '" + xttl_pfc + @"'
                                  ,[ttl_uatc] = '" + xttl_uatc + @"'
                                  ,[remark] = '" + xremark + @"'
                                  ,[updated_datetime] = '" + xclaimupdate_date + @"'
                             WHERE [claim_no] = '" + xclaim_no + "'";

            ret = zdb.ExecNonQueryReturnID(sql, zconnstr);

            return ret;
        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {
            GenDocumnet();
        }

        private void GenDocumnet()
        {
            // Replace Doc
            var xcompany_name = company_name.Text.Trim();
            var xclaim_no = claim_no.Value;
            var xdoc_no = doc_no.Text.Trim();
            var xbu_name = ddl_bu.SelectedItem.Text.ToString();
            var xincident = incident.Text.Trim();
            var xoccurred_date = Utillity.ConvertDateToLongDateTime(Utillity.ConvertStringToDate(occurred_date.Text.Trim()), "en");
            var xsubmission_date = Utillity.ConvertDateToLongDateTime(Utillity.ConvertStringToDate(submission_date.Text.Trim()), "en");
            var xsubmission_day = (Utillity.ConvertStringToDate(submission_date.Text.Trim()) - Utillity.ConvertStringToDate(occurred_date.Text.Trim())).TotalDays;
            var xincident_summary = incident_summary.Text.Trim();
            var xsurveyor_name = surveyor_name.Text.Trim();
            var xsurveyor_company = surveyor_company.Text.Trim();
            var xsettlement_date = Utillity.ConvertDateToLongDateTime(Utillity.ConvertStringToDate(settlement_date.Text.Trim()), "en");
            var xsettlement_day = settlement_day.Text.Trim();
            var xiar_atc = (!string.IsNullOrEmpty(iar_atc.Text.Trim()) ? iar_atc.Text.Trim() : null);
            var xiar_ded = (!string.IsNullOrEmpty(iar_ded.Text.Trim()) ? iar_ded.Text.Trim() : null);
            var xiar_pfc = (!string.IsNullOrEmpty(iar_pfc.Text.Trim()) ? iar_pfc.Text.Trim() : null);
            var xiar_uatc = (!string.IsNullOrEmpty(iar_uatc.Text.Trim()) ? iar_uatc.Text.Trim() : null);
            var xbi_atc = (!string.IsNullOrEmpty(bi_atc.Text.Trim()) ? bi_atc.Text.Trim() : null);
            var xbi_ded = (!string.IsNullOrEmpty(bi_ded.Text.Trim()) ? bi_ded.Text.Trim() : null);
            var xbi_pfc = (!string.IsNullOrEmpty(bi_pfc.Text.Trim()) ? bi_pfc.Text.Trim() : null);
            var xbi_uatc = (!string.IsNullOrEmpty(bi_uatc.Text.Trim()) ? bi_uatc.Text.Trim() : null);
            var xpl_cgl_atc = (!string.IsNullOrEmpty(pl_cgl_atc.Text.Trim()) ? pl_cgl_atc.Text.Trim() : null);
            var xpl_cgl_ded = (!string.IsNullOrEmpty(pl_cgl_ded.Text.Trim()) ? pl_cgl_ded.Text.Trim() : null);
            var xpl_cgl_pfc = (!string.IsNullOrEmpty(pl_cgl_pfc.Text.Trim()) ? pl_cgl_pfc.Text.Trim() : null);
            var xpl_cgl_uatc = (!string.IsNullOrEmpty(pl_cgl_uatc.Text.Trim()) ? pl_cgl_uatc.Text.Trim() : null);
            var xpv_atc = (!string.IsNullOrEmpty(pv_atc.Text.Trim()) ? pv_atc.Text.Trim() : null);
            var xpv_ded = (!string.IsNullOrEmpty(pv_ded.Text.Trim()) ? pv_ded.Text.Trim() : null);
            var xpv_pfc = (!string.IsNullOrEmpty(pv_pfc.Text.Trim()) ? pv_pfc.Text.Trim() : null);
            var xpv_uatc = (!string.IsNullOrEmpty(pv_uatc.Text.Trim()) ? pv_uatc.Text.Trim() : null);
            var xttl_atc = (!string.IsNullOrEmpty(ttl_atc.Text.Trim()) ? ttl_atc.Text.Trim() : null);
            var xttl_ded = (!string.IsNullOrEmpty(ttl_ded.Text.Trim()) ? ttl_ded.Text.Trim() : null);
            var xttl_pfc = (!string.IsNullOrEmpty(ttl_pfc.Text.Trim()) ? ttl_pfc.Text.Trim() : null);
            var xttl_uatc = (!string.IsNullOrEmpty(ttl_uatc.Text.Trim()) ? ttl_uatc.Text.Trim() : null);
            var xremark = (!string.IsNullOrEmpty(remark.Text.Trim()) ? remark.Text.Trim() : null);
            var xdocref = "1.TestDoc \r\n 2.TestDoc2 \r\n 3.TestDoc3 \r\n";

            string templatefile = @"C:\WordTemplate\Insurance\InsuranceTemplateClaim.docx";
            string outputfoler = @"C:\WordTemplate\Insurance\Output";
            string outputfn = outputfoler + @"\inreq_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

            var rdoc = new ReplaceDocx.Class.ReplaceDocx();

            #region prepare data
            //Replace TAG STRING
            DataTable dtStr = new DataTable();
            dtStr.Columns.Add("tagname", typeof(string));
            dtStr.Columns.Add("tagvalue", typeof(string));

            DataRow dr0 = dtStr.NewRow();
            dr0["tagname"] = "#company#";
            dr0["tagvalue"] = xcompany_name.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#propertyname#";
            dr0["tagvalue"] = xbu_name.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#incident#";
            dr0["tagvalue"] = xincident.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#occurreddate#";
            dr0["tagvalue"] = xoccurred_date;
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#submidate#";
            dr0["tagvalue"] = xsubmission_date;
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#submiday#";
            dr0["tagvalue"] = xsubmission_day + " days";
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#incidentsummary#";
            dr0["tagvalue"] = xincident_summary.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#docref#";
            dr0["tagvalue"] = xdocref.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#surveyor#";
            dr0["tagvalue"] = xsurveyor_name.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#companysurveyor#";
            dr0["tagvalue"] = xsurveyor_company.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#stmdate#";
            dr0["tagvalue"] = xsettlement_date;
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#stmday#";
            dr0["tagvalue"] = xsettlement_day + " days";
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#remark#";
            dr0["tagvalue"] = xremark.Replace(",", "!comma");
            dtStr.Rows.Add(dr0);
            #endregion

            //DataTable Column Properties
            DataTable dtProperties1 = new DataTable();
            dtProperties1.Columns.Add("tagname", typeof(string));
            dtProperties1.Columns.Add("col_name", typeof(string));
            dtProperties1.Columns.Add("col_width", typeof(string));
            dtProperties1.Columns.Add("col_align", typeof(string)); //Left, Right, Center
            dtProperties1.Columns.Add("col_valign", typeof(string)); //Top, Middle, Bottom
            dtProperties1.Columns.Add("col_font", typeof(string));
            dtProperties1.Columns.Add("col_fontsize", typeof(string));
            dtProperties1.Columns.Add("col_fontcolor", typeof(string));
            dtProperties1.Columns.Add("col_color", typeof(string));
            dtProperties1.Columns.Add("header_height", typeof(string));
            dtProperties1.Columns.Add("header_color", typeof(string));
            dtProperties1.Columns.Add("header_font", typeof(string));
            dtProperties1.Columns.Add("header_fontsize", typeof(string));
            dtProperties1.Columns.Add("header_fontbold", typeof(string));
            dtProperties1.Columns.Add("header_align", typeof(string)); //Left, Right, Center
            dtProperties1.Columns.Add("header_valign", typeof(string)); //Top, Middle, Bottom
            dtProperties1.Columns.Add("header_fontcolor", typeof(string));
            dtProperties1.Columns.Add("row_height", typeof(string));

            // Replace #tableeltc# ------------------------------------------------------
            DataRow dr = dtProperties1.NewRow();
            dr["tagname"] = "#tableeltc#";
            //dr["col_name"] = "Estimated losses to claim \r\n มูลค่าความเสียหาย";
            dr["col_name"] = "Estimated losses to claim";
            dr["col_width"] = "450";
            dr["col_align"] = "Left";
            dr["col_valign"] = "Bottom";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            dr = dtProperties1.NewRow();
            dr["tagname"] = "#tableeltc#";
            //dr["col_name"] = "IAR \r\n ทรัพย์สินเสียหาย";
            dr["col_name"] = "IAR";
            dr["col_width"] = "150";
            dr["col_align"] = "Right";
            dr["col_valign"] = "Bottom";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            dr = dtProperties1.NewRow();
            dr["tagname"] = "#tableeltc#";
            //dr["col_name"] = "BI \r\n ธุรกิจหยุดชะงัก";
            dr["col_name"] = "BI";
            dr["col_width"] = "150";
            dr["col_align"] = "Right";
            dr["col_valign"] = "Bottom";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            dr = dtProperties1.NewRow();
            dr["tagname"] = "#tableeltc#";
            //dr["col_name"] = "PL/CGL \r\n รับผิดบุคคลภายนอก";
            dr["col_name"] = "PL/CGL";
            dr["col_width"] = "150";
            dr["col_align"] = "Right";
            dr["col_valign"] = "Bottom";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            dr = dtProperties1.NewRow();
            dr["tagname"] = "#tableeltc#";
            //dr["col_name"] = "PV \r\n สาเหตุทางการเมือง";
            dr["col_name"] = "PV";
            dr["col_width"] = "150";
            dr["col_align"] = "Right";
            dr["col_valign"] = "Bottom";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            dr = dtProperties1.NewRow();
            dr["tagname"] = "#tableeltc#";
            //dr["col_name"] = "Total \r\n รวม";
            dr["col_name"] = "Total";
            dr["col_width"] = "150";
            dr["col_align"] = "Right";
            dr["col_valign"] = "Bottom";
            dr["col_font"] = "Tahoma";
            dr["col_fontsize"] = "9";
            dr["col_fontcolor"] = "Black";
            dr["col_color"] = "Transparent";
            dr["header_height"] = "20";
            dr["header_color"] = "Gray";
            dr["header_font"] = "Tahoma";
            dr["header_fontsize"] = "9";
            dr["header_fontbold"] = "true";
            dr["header_align"] = "Center";
            dr["header_valign"] = "Middle";
            dr["header_fontcolor"] = "White";
            dr["row_height"] = "16";
            dtProperties1.Rows.Add(dr);

            DataTable dt = new DataTable();
            dt.Columns.Add("tagname", typeof(string));
            dt.Columns.Add("Estimated losses to claim", typeof(string));
            dt.Columns.Add("IAR", typeof(string));
            dt.Columns.Add("BI", typeof(string));
            dt.Columns.Add("PL/CGL", typeof(string));
            dt.Columns.Add("PV", typeof(string));
            dt.Columns.Add("Total", typeof(string));

            //Assign DataTable for #tableeltc#
            DataRow dr1 = dt.NewRow();
            dr1["tagname"] = "#tableeltc#";
            dr1["Estimated losses to claim"] = "Amount to claim มูลค่าเรียกร้อง (a)";
            dr1["IAR"] = (!string.IsNullOrEmpty(xiar_atc) ? xiar_atc.Replace(",", "!comma") : "");
            dr1["BI"] = (!string.IsNullOrEmpty(xbi_atc) ? xbi_atc.Replace(",", "!comma") : "");
            dr1["PL/CGL"] = (!string.IsNullOrEmpty(xpl_cgl_atc) ? xpl_cgl_atc.Replace(",", "!comma") : "");
            dr1["PV"] = (!string.IsNullOrEmpty(xpv_atc) ? xpv_atc.Replace(",", "!comma") : "");
            dr1["Total"] = (!string.IsNullOrEmpty(xttl_atc) ? xttl_atc.Replace(",", "!comma") : "");
            dt.Rows.Add(dr1);

            dr1 = dt.NewRow();
            dr1["tagname"] = "#tableeltc#";
            dr1["Estimated losses to claim"] = "Deductible ค่ารับผิดส่วนแรก (b)";
            dr1["IAR"] = (!string.IsNullOrEmpty(xiar_ded) ? xiar_ded.Replace(",", "!comma") : "");
            dr1["BI"] = (!string.IsNullOrEmpty(xbi_ded) ? xbi_ded.Replace(",", "!comma") : "");
            dr1["PL/CGL"] = (!string.IsNullOrEmpty(xpl_cgl_ded) ? xpl_cgl_ded.Replace(",", "!comma") : "");
            dr1["PV"] = (!string.IsNullOrEmpty(xpv_ded) ? xpv_ded.Replace(",", "!comma") : "");
            dr1["Total"] = (!string.IsNullOrEmpty(xttl_ded) ? xttl_ded.Replace(",", "!comma") : "");
            dt.Rows.Add(dr1);

            dr1 = dt.NewRow();
            dr1["tagname"] = "#tableeltc#";
            dr1["Estimated losses to claim"] = "Proceeds from claim มูลค่าสินไหม (C)";
            dr1["IAR"] = (!string.IsNullOrEmpty(xiar_pfc) ? xiar_pfc.Replace(",", "!comma") : "");
            dr1["BI"] = (!string.IsNullOrEmpty(xbi_pfc) ? xbi_pfc.Replace(",", "!comma") : "");
            dr1["PL/CGL"] = (!string.IsNullOrEmpty(xpl_cgl_pfc) ? xpl_cgl_pfc.Replace(",", "!comma") : "");
            dr1["PV"] = (!string.IsNullOrEmpty(xpv_pfc) ? xpv_pfc.Replace(",", "!comma") : "");
            dr1["Total"] = (!string.IsNullOrEmpty(xttl_pfc) ? xttl_pfc.Replace(",", "!comma") : "");
            dt.Rows.Add(dr1);

            dr1 = dt.NewRow();
            dr1["tagname"] = "#tableeltc#";
            dr1["Estimated losses to claim"] = "Under amount to claim ส่วนต่างมูลค่าการเคลม (a-b-c)";
            dr1["IAR"] = (!string.IsNullOrEmpty(xiar_uatc) ? xiar_uatc.Replace(",", "!comma") : "");
            dr1["BI"] = (!string.IsNullOrEmpty(xbi_uatc) ? xbi_uatc.Replace(",", "!comma") : "");
            dr1["PL/CGL"] = (!string.IsNullOrEmpty(xpl_cgl_uatc) ? xpl_cgl_uatc.Replace(",", "!comma") : "");
            dr1["PV"] = (!string.IsNullOrEmpty(xpv_uatc) ? xpv_uatc.Replace(",", "!comma") : "");
            dr1["Total"] = (!string.IsNullOrEmpty(xttl_uatc) ? xttl_uatc.Replace(",", "!comma") : "");
            dt.Rows.Add(dr1);

            // Convert to JSONString
            DataTable dtTagPropsTable = new DataTable();
            dtTagPropsTable.Columns.Add("tagname", typeof(string));
            dtTagPropsTable.Columns.Add("jsonstring", typeof(string));

            DataTable dtTagDataTable = new DataTable();
            dtTagDataTable.Columns.Add("tagname", typeof(string));
            dtTagDataTable.Columns.Add("jsonstring", typeof(string));
            ReplaceDocx.Class.ReplaceDocx repl = new ReplaceDocx.Class.ReplaceDocx();
            var jsonDTStr = repl.DataTableToJSONWithStringBuilder(dtStr);
            var jsonDTProperties1 = repl.DataTableToJSONWithStringBuilder(dtProperties1);
            //var jsonDTProperties2 = repl.DataTableToJSONWithStringBuilder(dtProperties2);
            var jsonDTdata = repl.DataTableToJSONWithStringBuilder(dt);
            //var jsonDTdata2 = repl.DataTableToJSONWithStringBuilder(dt2);
            //end prepare data

            // Save to Database z_replacedocx_log

            string sql = @"insert into z_replacedocx_log (replacedocx_reqno,jsonTagString, jsonTableProp, jsonTableData,template_filepath , output_directory,output_filepath, delete_output ) 
                        values('" + xclaim_no + @"',
                               '" + jsonDTStr + @"', 
                                '" + jsonDTProperties1 + @"', 
                                '" + jsonDTdata + @"', 
                                '" + templatefile + @"', 
                                '" + outputfoler + @"', 
                                '" + outputfn + @"',  
                                '" + "0" + @"'
                            ) ";

            zdb.ExecNonQuery(sql, zconnstr);

            var outputbyte = rdoc.ReplaceData2(jsonDTStr, jsonDTProperties1, jsonDTdata, templatefile, outputfoler, outputfn, false);

            repl.convertDOCtoPDF(outputfn, outputfn.Replace(".docx", ".pdf"), false);
            // Dowload Word 
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.AddHeader("content-disposition", $"attachment; filename={outputfn}");
            Response.BinaryWrite(outputbyte);
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.End();
        }
    }
}