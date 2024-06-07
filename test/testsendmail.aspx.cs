using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailMessage = System.Net.Mail.MailMessage;
using WMS.userControls;
using WMS.Class;

namespace WMS.test
{
    public partial class testsendmail : System.Web.UI.Page
    {
        #region Public
        public SendMail zsendmail = new SendMail();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sendEmail();
            }
        }

        public void sendEmail()
        {
            string filepath = @"D:\Users\worawut.m\Downloads\mergePdf_20240115_124616.pdf";
            string subject = "Test Send Mail to worawut";
            string mailto = "legalwfuat2024@gmail.com";
            string body = "Test attach file to worawut";

            _ = zsendmail.sendEmail(subject, mailto, body, filepath);
        }
    }
}