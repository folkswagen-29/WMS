using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineLegalWF.test
{
    public partial class testuploadgridview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //get file in folder Temp
                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Temp/"));
                //List<ListItem> files = new List<ListItem>();
                List<AttachFileData> files = new List<AttachFileData>();
                int count = 0;
                foreach (string filePath in filePaths)
                {
                    count++;
                    AttachFileData data = new AttachFileData();
                    data.No = count;
                    data.Files = filePath;
                    data.FileName = Path.GetFileName(filePath);
                    //files.Add(new ListItem(Path.GetFileName(filePath), filePath));
                    files.Add(data);
                }


                fileGridview.DataSource = files;
                fileGridview.DataBind();

            }
        }

        protected void uploadData(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(myFile.PostedFile.FileName);
            myFile.PostedFile.SaveAs(Server.MapPath("~/Temp/") + fileName);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void DownloadData(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            //Response.ContentType = ContentType;
            var mimeType = MimeMapping.GetMimeMapping(Path.GetFileName(filePath));

            Response.ContentType = mimeType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();

        }
        //protected void PreviewData(object sender, EventArgs e)
        //{
        //    string filePath = (sender as LinkButton).CommandArgument;
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('"+ filePath+"','_newtab');", true);
        //}
        protected void DeleteData(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            File.Delete(filePath);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        public class AttachFileData 
        {
            public int No { get; set; }
            public string FileName { get; set; }
            public string Files { get; set; }
        }
    }
}