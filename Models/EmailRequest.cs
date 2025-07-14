﻿namespace EMailSenderWithSendGrid.Models
{
    public class EmailRequest
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromMail { get; set; }
        public string FromName { get; set; }
    }
}
