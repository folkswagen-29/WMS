using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.userControls
{
    public partial class ucAttachment : System.Web.UI.UserControl
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        //public string zconnstr = ConfigurationSettings.AppSettings["BMPDB"].ToString();
        public string zconnstr = ConfigurationManager.AppSettings["BMPDB"].ToString();
        public string zpath_attachment = ConfigurationManager.AppSettings["path_attachment"].ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ini_object(string xPID) 
        {
            hidPID.Value = xPID;
            ini_data(); 
        }
        private void ini_data()
        {
            string sql = "select * from wf_attachment where pid = '" + hidPID.Value + "' "; 

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.FileContent.Length <= 0)
            {
                // file not found 
                Response.Write("<script> alert('Warning! Please input file.');</script>");

            }
            else
            {
                // check existing folder => path_attachment + \\pid\\
                string xpath = zpath_attachment + "\\" + hidPID.Value;
                if (!System.IO.Directory.Exists(xpath)) { System.IO.Directory.CreateDirectory(xpath); }

                // check existing file
                string fn = xpath + "\\" + FileUpload1.FileName;
                if (System.IO.File.Exists(fn))
                {
                    Response.Write("<script> alert('Warning! File name is dupplicated. Please rename the filename.');</script>");
                }
                else
                {

                    FileUpload1.SaveAs(xpath + FileUpload1.FileName);
                }
                // insert into db
            }

        }
    }
}