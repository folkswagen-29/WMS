﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using onlineLegalWF.Class;
using onlineLegalWF.userControls;
using static onlineLegalWF.Class.ReplaceInsClaim;

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceClaim : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public WFFunctions zwf = new WFFunctions();
        public ReplaceInsClaim zreplaceinsclaim = new ReplaceInsClaim();
        public MargePDF zmergepdf = new MargePDF();
        public SendMail zsendmail = new SendMail();
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
            ucHeader1.setHeader("Claim Request");

            ddl_bu.DataSource = GetBusinessUnit();
            ddl_bu.DataBind();
            ddl_bu.DataTextField = "bu_desc";
            ddl_bu.DataValueField = "bu_code";
            ddl_bu.DataBind();

            string xclaim_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            claim_no.Value = xclaim_no;

            string pid = zwf.iniPID("LEGALWF");
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucCommentlog1.ini_object(pid);
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int res = SaveClaim();

            if (res > 0)
            {
                // wf save draft
                string process_code = "INR_CLAIM";
                int version_no = 1;
                string xbu_code = ddl_bu.SelectedValue;

                // getCurrentStep
                var wfAttr = zwf.getCurrentStep(lblPID.Text, process_code, version_no);

                // check session_user
                if (Session["user_login"] != null)
                {
                    var xlogin_name = Session["user_login"].ToString();
                    var empFunc = new EmpInfo();

                    //get data user
                    var emp = empFunc.getEmpInfo(xlogin_name);

                    // set WF Attributes
                    wfAttr.subject = incident.Text.Trim();
                    wfAttr.wf_status = "SAVE";
                    wfAttr.submit_answer = "SAVE";
                    wfAttr.submit_by = emp.user_login;
                    wfAttr.next_assto_login = zwf.findNextStep_Assignee(wfAttr.process_code, wfAttr.step_name, emp.user_login, wfAttr.submit_by, lblPID.Text, xbu_code);


                    // wf.updateProcess
                    var wfA_NextStep = zwf.updateProcess(wfAttr);

                }
                Response.Write("<script>alert('Successfully added');</script>");
                //Response.Redirect("/frmInsurance/InsuranceClaimList");
                Response.Redirect("/frmInsurance/InsuranceClaimEdit.aspx?id=" + claim_no.Value.Trim());
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }
        }

        private int SaveClaim() 
        {
            int ret = 0;
            if (doc_no.Text.Trim() == "")
            {
                doc_no.Text = zwf.genDocNo("INS-" + System.DateTime.Now.ToString("yyyy", new CultureInfo("en-US")) + "-", 4);
            }
            //var xprocess_id = string.Format("{0:000000}", (GetMaxProcessID() + 1));
            var xprocess_id = hid_PID.Value.ToString();
            var xcompany_name = company_name.Text.Trim();
            var xclaim_no = claim_no.Value;
            var xclaim_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
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
            var xstatus = "verify";

            string sql = @"INSERT INTO [dbo].[li_insurance_claim]
                                           ([process_id],[company_name],[claim_no],[claim_date],[document_no],[bu_code],[incident],[occurred_date],[submission_date],[incident_summary],[surveyor_name],[surveyor_company],[settlement_date],[settlement_day],[iar_atc],[iar_ded],[iar_pfc],[iar_uatc],[bi_atc],[bi_ded],[bi_pfc],[bi_uatc],[pl_cgl_atc],[pl_cgl_ded],[pl_cgl_pfc],[pl_cgl_uatc],[pv_atc],[pv_ded],[pv_pfc],[pv_uatc],[ttl_atc],[ttl_ded],[ttl_pfc],[ttl_uatc],[remark],[status])
                                     VALUES
                                           ('" + xprocess_id + @"'
                                           ,'" + xcompany_name + @"'
                                           ,'" + xclaim_no + @"'
                                           ,'" + xclaim_date + @"'
                                           ,'" + xdoc_no + @"'
                                           ,'" + xbu_code + @"'
                                           ,'" + xincident + @"'
                                           ,'" + xoccurred_date + @"'
                                           ,'" + xsubmission_date + @"'
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
            var xoccurred_date = Utillity.ConvertDateToLongDateTime(Utillity.ConvertStringToDate(occurred_date.Text.Trim()),"en");
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
            var xdocref = GetListDoc(lblPID.Text);

            string templatefile = @"C:\WordTemplate\Insurance\InsuranceTemplateClaim.docx";
            string outputfolder = @"C:\WordTemplate\Insurance\Output";
            string outputfn = outputfolder + @"\inreq_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

            var rdoc = new ReplaceDocx.Class.ReplaceDocx();

            ReplaceInsClaim_TagData data = new ReplaceInsClaim_TagData();

            #region prepare data
            //Replace TAG STRING
            data.company = xcompany_name.Replace(",", "!comma");
            data.propertyname = xbu_name.Replace(",", "!comma");
            data.incident = xincident.Replace(",", "!comma");
            data.occurreddate = xoccurred_date;
            data.submidate = xsubmission_date;
            data.submiday = xsubmission_day + " days";
            data.incidentsummary = xincident_summary.Replace(",", "!comma");
            data.docref = xdocref.Replace(",", "!comma");
            data.surveyor = xsurveyor_name.Replace(",", "!comma");
            data.companysurveyor = xsurveyor_company.Replace(",", "!comma");
            data.stmdate = xsettlement_date;
            data.stmday = xsettlement_day + " days";
            data.remark = xremark.Replace(",", "!comma");

            ////get moa claim get gm or am check external domain
            string xbu_code = ddl_bu.SelectedValue.ToString();
            string sqlbu = @"select * from li_business_unit where bu_code = '" + xbu_code + "'";
            var res = zdb.ExecSql_DataTable(sqlbu, zconnstr);

            var requestor = "";
            var requestorpos = "";
            var gmname = "";
            var gmpos = "";
            var amname = "";
            var ampos = "";
            if (res.Rows.Count > 0)
            {
                var empFunc = new EmpInfo();
                if (Session["user_login"] != null) 
                {
                    var xlogin_name = Session["user_login"].ToString();
                    var emp = empFunc.getEmpInfo(xlogin_name);
                    requestor = emp.full_name_en;
                    requestorpos = emp.position_en;
                }
                string xexternal_domain = res.Rows[0]["external_domain"].ToString();
                string xgm = res.Rows[0]["gm"].ToString();
                string xam = res.Rows[0]["head_am"].ToString();
                //get data am user
                if (!string.IsNullOrEmpty(xam)) 
                {
                    var empam = empFunc.getEmpInfo(xam);
                    if (empam.user_login != null)
                    {
                        amname = empam.full_name_en;
                        ampos = empam.position_en;
                    }
                }
                //get data gm user
                if(!string.IsNullOrEmpty(xgm)) 
                {
                    var empgm = empFunc.getEmpInfo(xgm);
                    if (empgm.user_login != null)
                    {
                        gmname = empgm.full_name_en;
                        gmpos = empgm.position_en;
                    }
                }
            }
            data.sign_propname1 = "";
            data.propname1 = requestor;
            data.propposition1 = requestorpos;
            data.propdate1 = "";

            data.sign_propname2 = "";
            data.propname2 = gmname;
            data.propposition2 = gmpos;
            data.propdate2 = "";

            data.sign_propname3 = "";
            data.propname3 = amname;
            data.propposition3 = ampos;
            data.propdate3 = "";

            //check corditon deviation claim
            float deviation = 0;
            float cal_iar_uatc = float.Parse(int.Parse(xiar_uatc, NumberStyles.AllowThousands).ToString());
            float cal_iar_pfc = float.Parse(int.Parse(xiar_pfc, NumberStyles.AllowThousands).ToString());
            int int_iar_uatc = int.Parse(xiar_uatc, NumberStyles.AllowThousands);
            deviation = cal_iar_uatc / cal_iar_pfc;
            if (int_iar_uatc <= 100000) 
            {
                data.sign_awcname1 = "";
                data.awcname1 = "คุณจรูณศักดิ์ นามะฮง";
                data.awcposition1 = "Insurance Specialist";
                data.awcdate1 = "";

                //data.sign_awcname1_2 = "";
                //data.awcname1_2 = "";
                //data.awcposition1_2 = "";
                //data.awcdate1_2 = "";

                //data.sign_awcname1_3 = "";
                //data.awcname1_3 = "";
                //data.awcposition1_3 = "";
                //data.awcdate1_3 = "";

                data.sign_awcname2 = "";
                data.awcname2 = "คุณวารินทร์ เกลียวไพศาล";
                data.awcposition2 = "Head of Compliance";
                data.awcdate2 = "";

                data.sign_awcname3 = "";
                data.awcname3 = "คุณชโลทร ศรีสมวงษ์";
                data.awcposition3 = "Head of Legal";
                data.awcdate3 = "";
            }
            else if (int_iar_uatc > 100000 && int_iar_uatc <= 1000000 && deviation <= 0.1)
            {
                data.sign_awcname1 = "";
                data.awcname1 = "คุณจรูณศักดิ์ นามะฮง";
                data.awcposition1 = "Insurance Specialist";
                data.awcdate1 = "";

                //data.sign_awcname1_2 = "";
                //data.awcname1_2 = "";
                //data.awcposition1_2 = "";
                //data.awcdate1_2 = "";

                //data.sign_awcname1_3 = "";
                //data.awcname1_3 = "";
                //data.awcposition1_3 = "";
                //data.awcdate1_3 = "";

                data.sign_awcname2 = "";
                data.awcname2 = "คุณวารินทร์ เกลียวไพศาล";
                data.awcposition2 = "Head of Compliance";
                data.awcdate2 = "";

                data.sign_awcname3 = "";
                data.awcname3 = "คุณชโลทร ศรีสมวงษ์";
                data.awcposition3 = "Head of Legal";
                data.awcdate3 = "";
            }
            else if (int_iar_uatc > 100000 && int_iar_uatc <= 1000000 && deviation > 0.1)
            {
                data.sign_awcname1 = "";
                data.awcname1 = "คุณจรูณศักดิ์ นามะฮง";
                data.awcposition1 = "Insurance Specialist";
                data.awcdate1 = "";

                //data.sign_awcname1_2 = "";
                //data.awcname1_2 = "คุณวารินทร์ เกลียวไพศาล";
                //data.awcposition1_2 = "Head of Compliance";
                //data.awcdate1_2 = "";

                //data.sign_awcname1_3 = "";
                //data.awcname1_3 = "";
                //data.awcposition1_3 = "";
                //data.awcdate1_3 = "";

                data.sign_awcname2 = "";
                data.awcname2 = "คุณชโลทร ศรีสมวงษ์";
                data.awcposition2 = "Head of Legal";
                data.awcdate2 = "";

                data.sign_awcname3 = "";
                data.awcname3 = "ดร.สิเวศ โรจนสุนทร";
                data.awcposition3 = "CCO";
                data.awcdate3 = "";
            }
            else if (int_iar_uatc > 1000000 && deviation <= 0.2)
            {
                data.sign_awcname1 = "";
                data.awcname1 = "คุณจรูณศักดิ์ นามะฮง";
                data.awcposition1 = "Insurance Specialist";
                data.awcdate1 = "";

                //data.sign_awcname1_2 = "";
                //data.awcname1_2 = "คุณวารินทร์ เกลียวไพศาล";
                //data.awcposition1_2 = "Head of Compliance";
                //data.awcdate1_2 = "";

                //data.sign_awcname1_3 = "";
                //data.awcname1_3 = "";
                //data.awcposition1_3 = "";
                //data.awcdate1_3 = "";

                data.sign_awcname2 = "";
                data.awcname2 = "คุณชโลทร ศรีสมวงษ์";
                data.awcposition2 = "Head of Legal";
                data.awcdate2 = "";

                data.sign_awcname3 = "";
                data.awcname3 = "ดร.สิเวศ โรจนสุนทร";
                data.awcposition3 = "CCO";
                data.awcdate3 = "";
            }
            else if (int_iar_uatc > 1000000 && deviation > 0.2)
            {
                data.sign_awcname1 = "";
                data.awcname1 = "คุณชโลทร ศรีสมวงษ์";
                data.awcposition1 = "Head of Legal";
                data.awcdate1 = "";

                //data.sign_awcname1 = "";
                //data.awcname1 = "คุณจรูณศักดิ์ นามะฮง";
                //data.awcposition1 = "Insurance Specialist";
                //data.awcdate1 = "";

                //data.sign_awcname1_2 = "";
                //data.awcname1_2 = "คุณวารินทร์ เกลียวไพศาล";
                //data.awcposition1_2 = "Head of Compliance";
                //data.awcdate1_2 = "";

                //data.sign_awcname1_3 = "";
                //data.awcname1_3 = "คุณชโลทร ศรีสมวงษ์";
                //data.awcposition1_3 = "Head of Legal";
                //data.awcdate1_3 = "";

                data.sign_awcname2 = "";
                data.awcname2 = "ดร.สิเวศ โรจนสุนทร";
                data.awcposition2 = "CCO";
                data.awcdate2 = "";

                data.sign_awcname3 = "";
                data.awcname3 = "วัลลภา ไตรโสรัส";
                data.awcposition3 = "CEO";
                data.awcdate3 = "";
            }

            DataTable dtStr = zreplaceinsclaim.genTagData(data);

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

            DataTable dt = zreplaceinsclaim.genTagTableData(lblPID.Text);

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
            var jsonDTdata = repl.DataTableToJSONWithStringBuilder(dt);
            //end prepare data

            // Save to Database z_replacedocx_log
            string sql = @"insert into z_replacedocx_log (replacedocx_reqno,jsonTagString, jsonTableProp, jsonTableData,template_filepath , output_directory,output_filepath, delete_output ) 
                        values('" + xclaim_no + @"',
                               '" + jsonDTStr + @"', 
                                '" + jsonDTProperties1 + @"', 
                                '" + jsonDTdata + @"', 
                                '" + templatefile + @"', 
                                '" + outputfolder + @"', 
                                '" + outputfn + @"',  
                                '" + "0" + @"'
                            ) ";

            zdb.ExecNonQuery(sql, zconnstr);

            var outputbyte = rdoc.ReplaceData2(jsonDTStr, jsonDTProperties1, jsonDTdata, templatefile, outputfolder, outputfn, false);

            repl.convertDOCtoPDF(outputfn, outputfn.Replace(".docx", ".pdf"), false);
            //// Dowload Word 
            //Response.Clear();
            //Response.ContentType = "text/xml";
            //Response.AddHeader("content-disposition", $"attachment; filename={outputfn}");
            //Response.BinaryWrite(outputbyte);
            //Response.ContentEncoding = System.Text.Encoding.UTF8;
            //Response.End();
            string filePath = outputfn.Replace(".docx", ".pdf");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalDoc();", true);
            pdf_render.Attributes["src"] = "/render/pdf?id=" + filePath;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string sqlreq = "select * from li_insurance_claim where claim_no='" + claim_no.Value + "'";

            var res = zdb.ExecSql_DataTable(sqlreq, zconnstr);

            if (res.Rows.Count == 0)
            {
                SaveClaim();
            }

            string process_code = "INR_CLAIM";
            int version_no = 1;

            // getCurrentStep
            var wfAttr = zwf.getCurrentStep(lblPID.Text, process_code, version_no);

            // check session_user
            if (Session["user_login"] != null)
            {
                var xlogin_name = Session["user_login"].ToString();
                var empFunc = new EmpInfo();

                //get data user
                var emp = empFunc.getEmpInfo(xlogin_name);

                // set WF Attributes
                wfAttr.subject = incident.Text.Trim();
                //wfAttr.assto_login = emp.next_line_mgr_login;
                wfAttr.wf_status = "SUBMITTED";
                wfAttr.submit_answer = "SUBMITTED";
                //wfAttr.next_assto_login = emp.next_line_mgr_login;
                wfAttr.submit_by = emp.user_login;
                wfAttr.next_assto_login = zwf.findNextStep_Assignee(wfAttr.process_code, wfAttr.step_name, emp.user_login, wfAttr.submit_by,wfAttr.process_id);
                wfAttr.updated_by = emp.user_login;

                // wf.updateProcess
                var wfA_NextStep = zwf.updateProcess(wfAttr);
                //wfA_NextStep.next_assto_login = emp.next_line_mgr_login;
                wfA_NextStep.next_assto_login = zwf.findNextStep_Assignee(wfA_NextStep.process_code, wfA_NextStep.step_name, emp.user_login, wfAttr.submit_by, wfAttr.process_id);
                string status = zwf.Insert_NextStep(wfA_NextStep);

                if (status == "Success")
                {
                    GenDocumnetInsClaim(lblPID.Text);

                    //send mail
                    string subject = "";
                    string body = "";
                    string sqlemail = @"select * from li_insurance_claim where process_id = '" + wfAttr.process_id + "'";
                    var dt = zdb.ExecSql_DataTable(sqlemail, zconnstr);
                    if (dt.Rows.Count > 0)
                    {
                        var dr = dt.Rows[0];
                        string id = dr["claim_no"].ToString();
                        subject = dr["incident"].ToString();
                        body = "คุณได้รับมอบหมายให้ตรวจสอบเอกสารเลขที่ " + dr["document_no"].ToString() + " กรุณาตรวจสอบและดำเนินการผ่านระบบ";

                        string pathfileins = "";
                        string outputdirectory = "";

                        string sqlfile = "select top 1 * from z_replacedocx_log where replacedocx_reqno='" + id + "' order by row_id desc";

                        var resfile = zdb.ExecSql_DataTable(sqlfile, zconnstr);

                        if (resfile.Rows.Count > 0)
                        {
                            pathfileins = resfile.Rows[0]["output_filepath"].ToString().Replace(".docx", ".pdf");
                            outputdirectory = resfile.Rows[0]["output_directory"].ToString();

                            List<string> listpdf = new List<string>();
                            listpdf.Add(pathfileins);

                            string sqlattachfile = "select * from wf_attachment where pid = '" + wfAttr.process_id + "' and e_form IS NULL";

                            var resattachfile = zdb.ExecSql_DataTable(sqlattachfile, zconnstr);

                            if (resattachfile.Rows.Count > 0)
                            {
                                foreach (DataRow item in resattachfile.Rows)
                                {
                                    listpdf.Add(item["attached_filepath"].ToString());
                                }
                            }
                            //get list pdf file from tb z_replacedocx_log where replacedocx_reqno
                            string[] pdfFiles = listpdf.ToArray();

                            ////get mail from db
                            //string email = "";
                            //string sqlbpm = "select * from li_user where user_login = '" + wfA_NextStep.next_assto_login + "' ";
                            //System.Data.DataTable dtbpm = zdb.ExecSql_DataTable(sqlbpm, zconnstr);

                            //if (dtbpm.Rows.Count > 0)
                            //{
                            //    email = dtbpm.Rows[0]["email"].ToString();

                            //}
                            //else
                            //{
                            //    string sqlpra = "select * from Rpa_Mst_HrNameList where Login = 'ASSETWORLDCORP-\\" + wfA_NextStep.next_assto_login + "' ";
                            //    System.Data.DataTable dtrpa = zdb.ExecSql_DataTable(sqlpra, zconnstrrpa);

                            //    if (dtrpa.Rows.Count > 0)
                            //    {
                            //        email = dtrpa.Rows[0]["Email"].ToString();
                            //    }

                            //}

                            string filepath = zmergepdf.mergefilePDF(pdfFiles, outputdirectory);

                            //send mail to next_approve
                            ////fix mail test
                            string email = "worawut.m@assetworldcorp-th.com";
                            _ = zsendmail.sendEmail(subject + " Mail To Next Appove", email, body, filepath);

                        }

                    }
                    Response.Redirect("/legalportal/legalportal.aspx?m=myworklist");
                }

            }
        }

        private void GenDocumnetInsClaim(string pid)
        {
            string xclaim_no = "";
            var xdocref = GetListDoc(hid_PID.Value);
            var xiar_pfc = "";
            var xiar_uatc = "";

            string templatefile = @"C:\WordTemplate\Insurance\InsuranceTemplateClaim.docx";
            string outputfolder = @"C:\WordTemplate\Insurance\Output";
            string outputfn = outputfolder + @"\inreq_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

            var rdoc = new ReplaceDocx.Class.ReplaceDocx();

            ReplaceInsClaim_TagData data = new ReplaceInsClaim_TagData();

            #region prepare data

            data.docref = xdocref;

            string sqlinsclaim = "select * from li_insurance_claim where process_id='" + pid + "'";
            var resinsclaim = zdb.ExecSql_DataTable(sqlinsclaim, zconnstr);

            //get data ins req
            if (resinsclaim.Rows.Count > 0)
            {
                xclaim_no = resinsclaim.Rows[0]["claim_no"].ToString();
                xiar_pfc = (!string.IsNullOrEmpty(resinsclaim.Rows[0]["iar_pfc"].ToString()) ? resinsclaim.Rows[0]["iar_pfc"].ToString() : null);
                xiar_uatc = (!string.IsNullOrEmpty(resinsclaim.Rows[0]["iar_uatc"].ToString()) ? resinsclaim.Rows[0]["iar_uatc"].ToString() : null);

                ////get moa claim get gm or am check external domain
                string xbu_code = resinsclaim.Rows[0]["bu_code"].ToString();
                string sqlbu = @"select * from li_business_unit where bu_code = '" + xbu_code + "'";
                var res = zdb.ExecSql_DataTable(sqlbu, zconnstr);

                var requestor = "";
                var requestorpos = "";
                var gmname = "";
                var gmpos = "";
                var amname = "";
                var ampos = "";
                if (res.Rows.Count > 0)
                {
                    var empFunc = new EmpInfo();
                    if (Session["user_login"] != null)
                    {
                        var xlogin_name = Session["user_login"].ToString();
                        var emp = empFunc.getEmpInfo(xlogin_name);
                        requestor = emp.full_name_en;
                        requestorpos = emp.position_en;
                    }
                    string xexternal_domain = res.Rows[0]["external_domain"].ToString();
                    string xgm = res.Rows[0]["gm"].ToString();
                    string xam = res.Rows[0]["head_am"].ToString();
                    //get data am user
                    if (!string.IsNullOrEmpty(xam))
                    {
                        var empam = empFunc.getEmpInfo(xam);
                        if (empam.user_login != null)
                        {
                            amname = empam.full_name_en;
                            ampos = empam.position_en;
                        }
                    }
                    //get data gm user
                    if (!string.IsNullOrEmpty(xgm))
                    {
                        var empgm = empFunc.getEmpInfo(xgm);
                        if (empgm.user_login != null)
                        {
                            gmname = empgm.full_name_en;
                            gmpos = empgm.position_en;
                        }
                    }
                }
                data.sign_propname1 = "";
                data.propname1 = requestor;
                data.propposition1 = requestorpos;
                data.propdate1 = "";

                data.sign_propname2 = "";
                data.propname2 = gmname;
                data.propposition2 = gmpos;
                data.propdate2 = "";

                data.sign_propname3 = "";
                data.propname3 = amname;
                data.propposition3 = ampos;
                data.propdate3 = "";

                //check corditon deviation claim
                float deviation = 0;
                float cal_iar_uatc = float.Parse(int.Parse(xiar_uatc, NumberStyles.AllowThousands).ToString());
                float cal_iar_pfc = float.Parse(int.Parse(xiar_pfc, NumberStyles.AllowThousands).ToString());
                int int_iar_uatc = int.Parse(xiar_uatc, NumberStyles.AllowThousands);
                deviation = cal_iar_uatc / cal_iar_pfc;
                if (int_iar_uatc <= 100000)
                {
                    data.sign_awcname1 = "";
                    data.awcname1 = "คุณจรูณศักดิ์ นามะฮง";
                    data.awcposition1 = "Insurance Specialist";
                    data.awcdate1 = "";

                    data.sign_awcname2 = "";
                    data.awcname2 = "คุณวารินทร์ เกลียวไพศาล";
                    data.awcposition2 = "Head of Compliance";
                    data.awcdate2 = "";

                    data.sign_awcname3 = "";
                    data.awcname3 = "คุณชโลทร ศรีสมวงษ์";
                    data.awcposition3 = "Head of Legal";
                    data.awcdate3 = "";
                }
                else if (int_iar_uatc > 100000 && int_iar_uatc <= 1000000 && deviation <= 0.1)
                {
                    data.sign_awcname1 = "";
                    data.awcname1 = "คุณจรูณศักดิ์ นามะฮง";
                    data.awcposition1 = "Insurance Specialist";
                    data.awcdate1 = "";

                    data.sign_awcname2 = "";
                    data.awcname2 = "คุณวารินทร์ เกลียวไพศาล";
                    data.awcposition2 = "Head of Compliance";
                    data.awcdate2 = "";

                    data.sign_awcname3 = "";
                    data.awcname3 = "คุณชโลทร ศรีสมวงษ์";
                    data.awcposition3 = "Head of Legal";
                    data.awcdate3 = "";
                }
                else if (int_iar_uatc > 100000 && int_iar_uatc <= 1000000 && deviation > 0.1)
                {
                    data.sign_awcname1 = "";
                    data.awcname1 = "คุณจรูณศักดิ์ นามะฮง";
                    data.awcposition1 = "Insurance Specialist";
                    data.awcdate1 = "";

                    data.sign_awcname2 = "";
                    data.awcname2 = "คุณชโลทร ศรีสมวงษ์";
                    data.awcposition2 = "Head of Legal";
                    data.awcdate2 = "";

                    data.sign_awcname3 = "";
                    data.awcname3 = "ดร.สิเวศ โรจนสุนทร";
                    data.awcposition3 = "CCO";
                    data.awcdate3 = "";
                }
                else if (int_iar_uatc > 1000000 && deviation <= 0.2)
                {
                    data.sign_awcname1 = "";
                    data.awcname1 = "คุณจรูณศักดิ์ นามะฮง";
                    data.awcposition1 = "Insurance Specialist";
                    data.awcdate1 = "";

                    data.sign_awcname2 = "";
                    data.awcname2 = "คุณชโลทร ศรีสมวงษ์";
                    data.awcposition2 = "Head of Legal";
                    data.awcdate2 = "";

                    data.sign_awcname3 = "";
                    data.awcname3 = "ดร.สิเวศ โรจนสุนทร";
                    data.awcposition3 = "CCO";
                    data.awcdate3 = "";
                }
                else if (int_iar_uatc > 1000000 && deviation > 0.2)
                {
                    data.sign_awcname1 = "";
                    data.awcname1 = "คุณชโลทร ศรีสมวงษ์";
                    data.awcposition1 = "Head of Legal";
                    data.awcdate1 = "";

                    data.sign_awcname2 = "";
                    data.awcname2 = "ดร.สิเวศ โรจนสุนทร";
                    data.awcposition2 = "CCO";
                    data.awcdate2 = "";

                    data.sign_awcname3 = "";
                    data.awcname3 = "วัลลภา ไตรโสรัส";
                    data.awcposition3 = "CEO";
                    data.awcdate3 = "";
                }
            }
            DataTable dtStr = zreplaceinsclaim.bindTagData(lblPID.Text, data);

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

            DataTable dt = zreplaceinsclaim.genTagTableData(lblPID.Text);

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
            var jsonDTdata = repl.DataTableToJSONWithStringBuilder(dt);
            //end prepare data

            // Save to Database z_replacedocx_log
            string sql = @"insert into z_replacedocx_log (replacedocx_reqno,jsonTagString, jsonTableProp, jsonTableData,template_filepath , output_directory,output_filepath, delete_output ) 
                        values('" + xclaim_no + @"',
                               '" + jsonDTStr + @"', 
                                '" + jsonDTProperties1 + @"', 
                                '" + jsonDTdata + @"', 
                                '" + templatefile + @"', 
                                '" + outputfolder + @"', 
                                '" + outputfn + @"',  
                                '" + "0" + @"'
                            ) ";

            zdb.ExecNonQuery(sql, zconnstr);

            var outputbyte = rdoc.ReplaceData2(jsonDTStr, jsonDTProperties1, jsonDTdata, templatefile, outputfolder, outputfn, false);

            repl.convertDOCtoPDF(outputfn, outputfn.Replace(".docx", ".pdf"), false);
            // Dowload Word 
            //Response.Clear();
            //Response.ContentType = "text/xml";
            //Response.AddHeader("content-disposition", $"attachment; filename={outputfn}");
            //Response.BinaryWrite(outputbyte);
            //Response.ContentEncoding = System.Text.Encoding.UTF8;
            //Response.End();
        }
        private string GetListDoc(string pid)
        {
            string res = "";

            string sql = @"select * from wf_attachment where pid = '" + pid + "'";
            var dtattach = zdb.ExecSql_DataTable(sql, zconnstr);

            if (dtattach.Rows.Count > 0)
            {
                int no = 0;
                foreach (DataRow dr in dtattach.Rows)
                {
                    res += (no + 1) + "." + dr["attached_filename"] + "\r\n";
                    no++;
                }
            }

            return res;
        }
    }
}