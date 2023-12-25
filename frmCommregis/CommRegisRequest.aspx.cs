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

            string pid = zwf.iniPID("LEGALWF");
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
            ucAttachmentSec1.ini_object(pid,"comregissec1","1");
            ucAttachmentSec2.ini_object(pid,"comregissec2","1");
            ucCommentlog1.ini_object(pid);

        }

        public DataTable GetTypeOfRequest()
        {
            string sql = "select * from li_type_of_comm_regis order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
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

            if (xtype_comm_regis == "01") 
            {
                var xcompany_name_th = sec1_company_name_th.Text.Trim();
                var xcompany_name_en = sec1_company_name_en.Text.Trim();
                var xhq_no = sec1_hq_no.Text.Trim();
                var xhq_building = sec1_hq_building.Text.Trim();
                var xhq_road = sec1_hq_road.Text.Trim();
                var xhq_subdistrict = sec1_hq_subdistrict.Text.Trim();
                var xhq_district = sec1_hq_district.Text.Trim();
                var xhq_province = sec1_hq_province.Text.Trim();
                var xhq_postcode = sec1_hq_postcode.Text.Trim();
                var xhq_phonenumber = sec1_hq_phonenumber.Text.Trim();
                var xtype_bu = sec1_type_bu.Text.Trim();
                var xtype_activity = sec1_type_activity.Text.Trim();
                var xobject = sec1_object.Text.Trim();
                var xreg_capital = sec1_reg_capital.Text.Trim();
                var xsharevalue = sec1_sharevalue.Text.Trim();
                var xpaidcapital = sec1_paidcapital.Text.Trim();
                var xshareholder_name = sec1_shareholder_name.Text.Trim();
                var xshareholder_amount = sec1_shareholder_amount.Text.Trim();
                var xshareholder_value = sec1_shareholder_value.Text.Trim();
                var xshareholder_paid = sec1_shareholder_paid.Text.Trim();
                var xrule_desc = sec1_rule_desc.Text.Trim();
                var xdirector_name = sec1_director_name.Text.Trim();
                var xdirector_posittion = sec1_director_posittion.Text.Trim();
                var xlayman_name = sec1_layman_name.Text.Trim();
                var xaudit_name = sec1_audit_name.Text.Trim();
                var xaudit_license = sec1_audit_license.Text.Trim();
                var xcostperyear = sec1_costperyear.Text.Trim();
                

                sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[company_name_th],[company_name_en],[hq_no],[hq_building],[hq_road]
                               ,[hq_subdistrict],[hq_district],[hq_province],[hq_postcode],[hq_phonenumber],[type_bu],[type_activity],[object],[reg_capital],[sharevalue],[paidcapital]
                               ,[shareholder_name],[shareholder_amount],[shareholder_value],[shareholder_paid],[rule_desc],[director_name],[director_posittion],[layman_name],[audit_name],[audit_license],[costperyear],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'"+ xtype_comm_regis + @"'
                               ,'"+ xdoc_no + @"'
                               ,'"+ xmt_res_desc + @"'
                               ,'"+ xmt_res_no + @"'
                               ,'"+ xmt_res_date + @"'
                               ,'"+ xcompany_name_th + @"'
                               ,'"+ xcompany_name_en + @"'
                               ,'"+ xhq_no + @"'
                               ,'"+ xhq_building + @"'
                               ,'"+ xhq_road + @"'
                               ,'"+ xhq_subdistrict + @"'
                               ,'"+ xhq_district + @"'
                               ,'"+ xhq_province + @"'
                               ,'"+ xhq_postcode + @"'
                               ,'"+ xhq_phonenumber + @"'
                               ,'"+ xtype_bu + @"'
                               ,'"+ xtype_activity + @"'
                               ,'"+ xobject + @"'
                               ,'"+ xreg_capital + @"'
                               ,'"+ xsharevalue + @"'
                               ,'"+ xpaidcapital + @"'
                               ,'"+ xshareholder_name + @"'
                               ,'"+ xshareholder_amount + @"'
                               ,'"+ xshareholder_value + @"'
                               ,'"+ xshareholder_paid + @"'
                               ,'"+ xrule_desc + @"'
                               ,'"+ xdirector_name + @"'
                               ,'"+ xdirector_posittion + @"'
                               ,'"+ xlayman_name + @"'
                               ,'"+ xaudit_name + @"'
                               ,'"+ xaudit_license + @"'
                               ,'"+ xcostperyear + @"'
                               ,'"+ xstatus + @"')";

                zdb.ExecNonQuery(sql, zconnstr);
            }
            else if (xtype_comm_regis == "02") 
            {
                var xcompany_name_th = sec2_companynameth.Text.Trim();
                var xcompany_name_en = sec2_companynameen.Text.Trim();

                sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[company_name_th],[company_name_en],[status])
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
                               ,'" + xstatus + @"')";

                zdb.ExecNonQuery(sql, zconnstr);
            }
            else if (xtype_comm_regis == "03")
            {
                var xreg_capital_add = sec3_reg_capital_add.Text.Trim();
                var xsharevalue_add = sec3_sharevalue_add.Text.Trim();
                var xreg_capital_subsidize = sec3_reg_capital_subsidize.Text.Trim();
                var xsharevalue_subsidize_amount = sec3_sharevalue_subsidize_amount.Text.Trim();
                var xsharevalue_subsidize = sec3_sharevalue_subsidize.Text.Trim();

                sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date]
                                ,[reg_capital_add],[sharevalue_add],[reg_capital_subsidize],[sharevalue_subsidize_amount],[sharevalue_subsidize],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'" + xtype_comm_regis + @"'
                               ,'" + xdoc_no + @"'
                               ,'" + xmt_res_desc + @"'
                               ,'" + xmt_res_no + @"'
                               ,'" + xmt_res_date + @"'
                               ,'" + xreg_capital_add + @"'
                               ,'" + xsharevalue_add + @"'
                               ,'" + xreg_capital_subsidize + @"'
                               ,'" + xsharevalue_subsidize_amount + @"'
                               ,'" + xsharevalue_subsidize + @"'
                               ,'" + xstatus + @"')";

                zdb.ExecNonQuery(sql, zconnstr);
            }
            else if (xtype_comm_regis == "04")
            {
                var xobject = sec4_object_add.Text.Trim();

                sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[object],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'" + xtype_comm_regis + @"'
                               ,'" + xdoc_no + @"'
                               ,'" + xmt_res_desc + @"'
                               ,'" + xmt_res_no + @"'
                               ,'" + xmt_res_date + @"'
                               ,'" + xobject + @"'
                               ,'" + xstatus + @"')";

                zdb.ExecNonQuery(sql, zconnstr);
            }
            else if (xtype_comm_regis == "05")
            {
                var xrule_desc = sec5_ruledesc.Text.Trim();
                var xrule_companydesc = sec5_rule_companydesc.Text.Trim();

                sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[rule_desc],[rule_companydesc],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'" + xtype_comm_regis + @"'
                               ,'" + xdoc_no + @"'
                               ,'" + xmt_res_desc + @"'
                               ,'" + xmt_res_no + @"'
                               ,'" + xmt_res_date + @"'
                               ,'" + xrule_desc + @"'
                               ,'" + xrule_companydesc + @"'
                               ,'" + xstatus + @"')";

                zdb.ExecNonQuery(sql, zconnstr);
            }
            else if (xtype_comm_regis == "06")
            {
                var xdirectorname_in = sec6_directorname_in.Text.Trim();
                var xdirectorposition_in = sec6_directorposition_in.Text.Trim();
                var xsec6_directorname_out = sec6_directorname_out.Text.Trim();
                var xdirectorposition_out = sec6_directorposition_out.Text.Trim();
                var xdirector_old = sec6_director_old.Text.Trim();
                var xdirector_nationality = sec6_director_nationality.Text.Trim();
                var xdirector_identityno = sec6_director_identityno.Text.Trim();
                var xdirector_no = sec6_director_no.Text.Trim();
                var xdirector_building = sec6_director_building.Text.Trim();
                var xdirector_road = sec6_director_road.Text.Trim();
                var xdirector_subdistrict = sec6_director_subdistrict.Text.Trim();
                var xdirector_district = sec6_director_district.Text.Trim();
                var xdirector_province = sec6_director_province.Text.Trim();
                var xdirector_postcode = sec6_director_postcode.Text.Trim();
                var xdirector_phonenumber = sec6_director_phonenumber.Text.Trim();

                sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[director_name_in],[director_position_in],[director_name_out],[director_position_out]
                                ,[director_old],[director_nationality],[director_identityno],[director_no],[director_building],[director_road],[director_subdistrict],[director_district],[director_province],[director_postcode],[director_phonenumber],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'" + xtype_comm_regis + @"'
                               ,'" + xdoc_no + @"'
                               ,'" + xmt_res_desc + @"'
                               ,'" + xmt_res_no + @"'
                               ,'" + xmt_res_date + @"'
                               ,'" + xdirectorname_in + @"'
                               ,'" + xdirectorposition_in + @"'
                               ,'" + xsec6_directorname_out + @"'
                               ,'" + xdirectorposition_out + @"'
                               ,'" + xdirector_old + @"'
                               ,'" + xdirector_nationality + @"'
                               ,'" + xdirector_identityno + @"'
                               ,'" + xdirector_no + @"'
                               ,'" + xdirector_building + @"'
                               ,'" + xdirector_road + @"'
                               ,'" + xdirector_subdistrict + @"'
                               ,'" + xdirector_district + @"'
                               ,'" + xdirector_province + @"'
                               ,'" + xdirector_postcode + @"'
                               ,'" + xdirector_phonenumber + @"'
                               ,'" + xstatus + @"')";

                zdb.ExecNonQuery(sql, zconnstr);
            }
            else if (xtype_comm_regis == "07")
            {
                var xhq_no = sec7_no.Text.Trim();
                var xhq_building = sec7_building.Text.Trim();
                var xhq_road = sec7_road.Text.Trim();
                var xhq_subdistrict = sec7_subdistrict.Text.Trim();
                var xhq_district = sec7_district.Text.Trim();
                var xhq_province = sec7_province.Text.Trim();
                var xhq_postcode = sec7_postcode.Text.Trim();
                var xhq_phonenumber = sec7_phonenumber.Text.Trim();
                var xhq_housecode = sec7_housecode.Text.Trim();


                sql = @"INSERT INTO [dbo].[li_comm_regis_request]
                               ([process_id],[req_no],[req_date],[toc_regis_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],[hq_no],[hq_building],[hq_road]
                               ,[hq_subdistrict],[hq_district],[hq_province],[hq_postcode],[hq_phonenumber],[hq_housecode],[status])
                         VALUES
                               ('" + xprocess_id + @"'
                               ,'" + xreq_no + @"'
                               ,'" + xreq_date + @"'
                               ,'" + xtype_comm_regis + @"'
                               ,'" + xdoc_no + @"'
                               ,'" + xmt_res_desc + @"'
                               ,'" + xmt_res_no + @"'
                               ,'" + xmt_res_date + @"'
                               ,'" + xhq_no + @"'
                               ,'" + xhq_building + @"'
                               ,'" + xhq_road + @"'
                               ,'" + xhq_subdistrict + @"'
                               ,'" + xhq_district + @"'
                               ,'" + xhq_province + @"'
                               ,'" + xhq_postcode + @"'
                               ,'" + xhq_phonenumber + @"'
                               ,'" + xhq_housecode + @"'
                               ,'" + xstatus + @"')";

                zdb.ExecNonQuery(sql, zconnstr);
            }
        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {

        }

    }
}