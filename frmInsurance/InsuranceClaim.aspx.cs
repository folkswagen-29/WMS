using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceClaim : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BMPDB"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetData_ddl();
            }
        }

        public DataTable GetBusinessUnit()
        {
            string sql = "select * from li_business_unit order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }
        public int GetMaxProcessID()
        {
            string sql = "select isnull(max(process_id),0) as id from li_insurance_claim";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        private void SetData_ddl() 
        {
            ddl_bu.DataSource = GetBusinessUnit();
            ddl_bu.DataBind();
            ddl_bu.DataTextField = "bu_desc";
            ddl_bu.DataValueField = "bu_code";
            ddl_bu.DataBind();

            string xclaim_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            claim_no.Value = xclaim_no;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int res = SaveClaim();

            if (res > 0)
            {
                Response.Write("<script>alert('Successfully added');</script>");
                Response.Redirect("/frmInsurance/InsuranceCkaimList");
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
        }

        private int SaveClaim() 
        {
            int ret = 0;

            var xprocess_id = string.Format("{0:000000}", (GetMaxProcessID() + 1));
            var xclaim_no = claim_no.Value;
            var xclaim_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xdoc_no = doc_no.Text.Trim();
            var xbu_code = ddl_bu.SelectedValue.ToString();
            var xincident = incident.Text.Trim();
            var xoccurred_date = occurred_date.Text.Trim();
            var xsubmissio_date = submissio_date.Text.Trim();
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
            var xstatus = "verify";

            string sql = @"INSERT INTO [dbo].[li_insurance_claim]
                                           ([process_id],[claim_no],[claim_date],[document_no],[bu_code],[incident],[occurred_date],[submissio_date],[incident_summary],[surveyor_name],[surveyor_company],[settlement_date],[settlement_day],[iar_atc],[iar_ded],[iar_pfc],[iar_uatc],[bi_atc],[bi_ded],[bi_pfc],[bi_uatc],[pl_cgl_atc],[pl_cgl_ded],[pl_cgl_pfc],[pl_cgl_uatc],[pv_atc],[pv_ded],[pv_pfc],[pv_uatc],[ttl_atc],[ttl_ded],[ttl_pfc],[ttl_uatc],[remark],[status])
                                     VALUES
                                           ('"+ xprocess_id + @"'
                                           ,'" + xclaim_no + @"'
                                           ,'" + xclaim_date + @"'
                                           ,'" + xdoc_no + @"'
                                           ,'" + xbu_code + @"'
                                           ,'" + xincident + @"'
                                           ,'" + xoccurred_date + @"'
                                           ,'" + xsubmissio_date + @"'
                                           ,'" + xincident_summary + @"'
                                           ,'" + xsurveyor_name + @"'
                                           ,'" + xsurveyor_company + @"'
                                           ,'" + xsettlement_date + @"'
                                           ,'" + xsettlement_day + @"'
                                           ,'" + xiar_atc + @"'
                                           ,'" + xiar_ded + @"'
                                           ,'" + xiar_pfc + @"'
                                           ,'" + xiar_uatc + @"'
                                           ,'" + xbi_atc + @"'
                                           ,'" + xbi_ded + @"'
                                           ,'" + xbi_pfc + @"'
                                           ,'" + xbi_uatc + @"'
                                           ,'" + xpl_cgl_atc + @"'
                                           ,'" + xpl_cgl_ded + @"'
                                           ,'" + xpl_cgl_pfc + @"'
                                           ,'" + xpl_cgl_uatc + @"'
                                           ,'" + xpv_atc + @"'
                                           ,'" + xpv_ded + @"'
                                           ,'" + xpv_pfc + @"'
                                           ,'" + xpv_uatc + @"'
                                           ,'" + xttl_atc + @"'
                                           ,'" + xttl_ded + @"'
                                           ,'" + xttl_pfc + @"'
                                           ,'" + xttl_uatc + @"'
                                           ,'" + xremark + @"'
                                           ,'" + xstatus + @"')";

            ret = zdb.ExecNonQueryReturnID(sql, zconnstr);

            return ret;
        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {

        }
    }
}