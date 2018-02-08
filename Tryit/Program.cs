using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;



namespace Tryit
{
    class Program
    {
        static void Main(string[] args)
        {
            MailMessage mail = new MailMessage("jingweizhangcscs@gmail.com", "wocaonimagebi550@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            client.Send(mail);
        }
    }
}
