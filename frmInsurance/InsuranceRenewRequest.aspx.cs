using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iTextSharp.text.pdf.AcroFields;

namespace onlineLegalWF.frmInsurance
{
    public partial class InsuranceRenewRequest : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BMPDB"].ToString();
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
            string xreq_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            req_no.Text = xreq_no;

            iniData();
        }

        #region gv1
        public void iniData()
        {
            var dt = iniDataTable();
            gv1.DataSource = dt;
            gv1.DataBind();

            ddl_bu.DataSource = GetBusinessUnit();
            ddl_bu.DataBind();
            ddl_bu.DataTextField = "bu_desc";
            ddl_bu.DataValueField = "bu_code";
            ddl_bu.DataBind();
        }
        public DataTable iniDataTable()
        {
            //getData
            var dt = iniDTStructure();
            var dr = dt.NewRow();

            var dt_top_ins = GetTypeOfPropertyInsured();

            if (dt_top_ins.Rows.Count > 0) 
            {
                int no = 0;
                
                foreach (DataRow dr_ins in dt_top_ins.Rows)
                {
                    dr = dt.NewRow();
                    dr["No"] = (no+1);
                    dr["PropertyInsured"] = dr_ins["top_ins_desc"].ToString();
                    dr["IndemnityPeriod"] = "";
                    dr["SumInsured"] = "";
                    dr["StartDate"] = "";
                    dr["EndDate"] = "";
                    dr["Top_Ins_Code"] = dr_ins["top_ins_code"].ToString();
                    dt.Rows.Add(dr);

                    no++;
                }
            }

            //var dr = dt.NewRow();
            //dr["No"] = "1";
            //dr["PropertyInsured"] = "IAR";
            //dr["IndemnityPeriod"] = "";
            //dr["SumInsured"] = "";
            //dr["StartDate"] = "";
            //dr["EndDate"] = "";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr["No"] = "2";
            //dr["PropertyInsured"] = "BI";
            //dr["IndemnityPeriod"] = "";
            //dr["SumInsured"] = "";
            //dr["StartDate"] = "";
            //dr["EndDate"] = "";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr["No"] = "3";
            //dr["PropertyInsured"] = "CGL/PL";
            //dr["IndemnityPeriod"] = "";
            //dr["SumInsured"] = "";
            //dr["StartDate"] = "";
            //dr["EndDate"] = "";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr["No"] = "4";
            //dr["PropertyInsured"] = "PV";
            //dr["IndemnityPeriod"] = "";
            //dr["SumInsured"] = "";
            //dr["StartDate"] = "";
            //dr["EndDate"] = "";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr["No"] = "5";
            //dr["PropertyInsured"] = "LPG";
            //dr["IndemnityPeriod"] = "";
            //dr["SumInsured"] = "";
            //dr["StartDate"] = "";
            //dr["EndDate"] = "";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr["No"] = "6";
            //dr["PropertyInsured"] = "D&O";
            //dr["IndemnityPeriod"] = "";
            //dr["SumInsured"] = "";
            //dr["StartDate"] = "";
            //dr["EndDate"] = "";
            //dt.Rows.Add(dr);

            return dt;
        }
        public DataTable iniDTStructure()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(string));
            dt.Columns.Add("PropertyInsured", typeof(string));
            dt.Columns.Add("IndemnityPeriod", typeof(string));
            dt.Columns.Add("SumInsured", typeof(string));
            dt.Columns.Add("StartDate", typeof(string));
            dt.Columns.Add("EndDate", typeof(string));
            dt.Columns.Add("Top_Ins_Code", typeof(string));
            return dt;
        }
        public void gv1LoadData(DataTable dt, string mode)
        {
            gv1.DataSource = dt;
            gv1.DataBind();
            hidMode.Value = mode;
        }
        public DataTable GetTypeOfPropertyInsured()
        {
            string sql = "select * from li_type_of_property_insured order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }
        #endregion

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            int res = SaveRenewRequest();

            if (res > 0)
            {
                Response.Write("<script>alert('Successfully added');</script>");
                Response.Redirect("/frmInsurance/InsuranceRenewRequestList");
            }
            else
            {
                Response.Write("<script>alert('Error !!!');</script>");
            }

        }

        public int GetMaxProcessID()
        {
            string sql = "select isnull(max(process_id),0) as id from li_insurance_request";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public DataTable GetBusinessUnit()
        {
            string sql = "select * from li_business_unit order by row_sort asc";
            DataTable dt = zdb.ExecSql_DataTable(sql, zconnstr);
            return dt;
        }

        private int SaveRenewRequest() 
        {
            int ret = 0;

            var xreq_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var xprocess_id = string.Format("{0:000000}", (GetMaxProcessID() + 1));
            var xreq_no = req_no.Text.Trim();
            var xtype_req = type_req.SelectedValue.ToString();
            var xbu_code = ddl_bu.SelectedValue.ToString();
            var xcompany_name = ddl_bu.SelectedItem.Text.ToString();
            var xdoc_no = doc_no.Text.Trim();
            var xsubject = subject.Text.Trim();
            var xto = to.Text.Trim();
            var xpurpose = purpose.Text.Trim();
            var xbackground = background.Text.Trim();
            var xstatus = "verify";


            //Get Data from gv1 Insurance Detail
            List<InsurancePropData> listInsurancePropData = new List<InsurancePropData>();
            foreach (GridViewRow row in gv1.Rows)
            {
                InsurancePropData data = new InsurancePropData();
                data.TypeOfPropertyInsured = (row.FindControl("gv1txttop_ins_code") as HiddenField).Value;
                data.IndemnityPeriod = (row.FindControl("gv1txtIndemnityPeriod") as TextBox).Text;
                data.SumInsured = (row.FindControl("gv1txtSumInsured") as TextBox).Text;
                data.StartDate = (row.FindControl("gv1txtSdate") as TextBox).Text;
                data.EndDate = (row.FindControl("gv1txtEdate") as TextBox).Text;

                if (!string.IsNullOrEmpty(data.IndemnityPeriod) && !string.IsNullOrEmpty(data.SumInsured) && !string.IsNullOrEmpty(data.StartDate) && !string.IsNullOrEmpty(data.EndDate)) 
                {
                    listInsurancePropData.Add(data);
                }
                
            }

            string sql = @"INSERT INTO [dbo].[li_insurance_request]
                                   ([process_id],[req_no],[req_date],[toreq_code],[company_name],[document_no],[subject],[dear],[objective],[reason],[status],[bu_code])
                             VALUES
                                   ('" + xprocess_id + @"'
                                   ,'" + xreq_no + @"'
                                   ,'" + xreq_date + @"'
                                   ,'" + xtype_req + @"'
                                   ,'" + xcompany_name + @"'
                                   ,'" + xdoc_no + @"'
                                   ,'" + xsubject + @"'
                                   ,'" + xto + @"'
                                   ,'" + xpurpose + @"'
                                   ,'" + xbackground + @"'
                                   ,'" + xstatus + @"'
                                   ,'" + xbu_code + @"')";

            ret = zdb.ExecNonQueryReturnID(sql, zconnstr);

            if (ret > 0)
            {
                if (listInsurancePropData.Count > 0) 
                {
                    foreach (var item in listInsurancePropData)
                    {
                        string sqlInsertPropIns = @"INSERT INTO [dbo].[li_insurance_req_property_insured]
                                                   ([req_no],[top_ins_code],[indemnityperiod],[suminsured],[startdate],[enddate],[created_datetime])
                                             VALUES
                                                   ('" + xreq_no + @"'
                                                   ,'" + item.TypeOfPropertyInsured + @"'
                                                   ,'" + item.IndemnityPeriod + @"'
                                                   ,'" + item.SumInsured + @"'
                                                   ,'" + item.StartDate + @"'
                                                   ,'" + item.EndDate + @"'
                                                   ,'" + xreq_date + @"')";

                        ret = zdb.ExecNonQueryReturnID(sqlInsertPropIns, zconnstr);
                    }
                }
                
            }

            return ret;
        }

        public class InsurancePropData
        {
            public string TypeOfPropertyInsured { get; set; } 
            public string IndemnityPeriod { get; set; }  
            public string SumInsured { get; set; }  
            public string StartDate { get; set; }  
            public string EndDate { get; set; }  
        }
    }
}