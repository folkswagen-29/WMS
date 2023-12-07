using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using onlineLegalWF.Class;
using System.Configuration;

namespace onlineLegalWF.frmLitigation
{
    public partial class LitigationRequest : System.Web.UI.Page
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        //public string zconnstr = ConfigurationSettings.AppSettings["BMPDB"].ToString();
        public string zconnstr = ConfigurationManager.AppSettings["BMPDB"].ToString();
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
            ucHeader1.setHeader("Litigation Request");
            string xreq_no = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            req_no.Text = xreq_no;

            string pid = zwf.iniPID("LEGALWF");
            lblPID.Text = pid;
            hid_PID.Value = pid;
            ucAttachment1.ini_object(pid);
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {

        }

        protected void btn_gendocumnt_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Coneection String by default empty  
            string ConStr = "";

            if (FileUpload1.HasFile) 
            {
                //Extantion of the file upload control saving into ext because   
                //there are two types of extation .xls and .xlsx of Excel   
                string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
                //getting the path of the file   
                string path = Server.MapPath("~/Temp/" + FileUpload1.FileName);
                //saving the file inside the Temp of the server  
                FileUpload1.SaveAs(path);
                Label1.Text = FileUpload1.FileName + "\'s Data showing into the GridView";
                //checking that extantion is .xls or .xlsx  
                if (ext.Trim() == ".xls")
                {
                    //connection string for that file which extantion is .xls  
                    ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (ext.Trim() == ".xlsx")
                {
                    //connection string for that file which extantion is .xlsx  
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                //making query  
                //string query = "SELECT * FROM [Sheet1$]";
                string query = "";
                //Providing connection  
                OleDbConnection conn = new OleDbConnection(ConStr);
                //checking that connection state is closed or not if closed the   
                //open the connection  
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                //get sheetname
                DataTable dtExcelSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                query = "SELECT * FROM [" + getExcelSheetName + "]";

                //create command object  
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // create a data adapter and get the data into dataadapter  
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                //fill the Excel data to data set  
                da.Fill(ds);
                //set data source of the grid view  
                gvExcelFile.DataSource = ds.Tables[0];
                //binding the gridview  
                gvExcelFile.DataBind();
                //close the connection  
                conn.Close();

                //delete file inside the Temp of the server 
                File.Delete(path);
            }
                
        }
    }
}