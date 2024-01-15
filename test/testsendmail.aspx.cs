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
using onlineLegalWF.userControls;

namespace onlineLegalWF.test
{
    public partial class testsendmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
            {
                _ = sendEmail();
            }
        }

        public async Task<bool> sendEmail() 
        {
            bool status = false;
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                var client = new SmtpClient("smtp.office365.com")
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("no_reply@assetworldcorp-th.com", "Awc@2019")
                };

                var filepath = @"D:\Users\worawut.m\Downloads\mergePdf_20240115_124616.pdf";
                var attachment = new System.Net.Mail.Attachment(filepath);
                var mailMessage = new MailMessage { From = new MailAddress("no_reply@assetworldcorp-th.com") };
                mailMessage.To.Add("worawut.m@assetworldcorp-th.com");
                mailMessage.Body = "Test attach file";
                mailMessage.Subject = "Hello worawut";
                mailMessage.IsBodyHtml = true;
                mailMessage.Attachments.Add(attachment);

                await client.SendMailAsync(mailMessage);
                status = true;
                return status;
            }
            catch (Exception ex)
            {
                LogHelper.Write(ex);
                throw ex;
                //return status;
            }
        }
    }
}