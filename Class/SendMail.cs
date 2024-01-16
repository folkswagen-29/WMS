using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace onlineLegalWF.Class
{
    public class SendMail
    {
        public async Task<bool> sendEmail(string subject,string mailto, string body, string attachfile)
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

                var attachment = new System.Net.Mail.Attachment(attachfile);
                var mailMessage = new MailMessage { From = new MailAddress("no_reply@assetworldcorp-th.com") };
                mailMessage.To.Add(mailto);
                mailMessage.Body = body;
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                if (attachment != null) 
                {
                    mailMessage.Attachments.Add(attachment);
                }
                

                await client.SendMailAsync(mailMessage).ConfigureAwait(false);
                status = true;
                return status;
            }
            catch (Exception ex)
            {
                LogHelper.Write(ex);
                throw ex;
            }
        }
    }
}