﻿using System;
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
using onlineLegalWF.Class;

namespace onlineLegalWF.test
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
            string mailto = "Hello worawut";
            string subject = "worawut.m@assetworldcorp-th.com";
            string body = "Test attach file";

            _ = zsendmail.sendEmail(subject, mailto, body, filepath);
        }
    }
}