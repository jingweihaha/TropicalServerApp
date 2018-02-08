using EASendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TropicalServer.DAL;
using TropicalServer.DAL.model;

namespace TropicalServer.BLL
{
    public class GetPasswordBack
    {
        public void GetPasswordByEmail(string email)
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            // Your gmail email address
            oMail.From = "jingweizhangcscs@gmail.com";

            GetPasswordByEmail g = new DAL.GetPasswordByEmail();
            User user = g.GetPasswordByEmailID(email);

            // Set recipient email address
            oMail.To = user.EmailID;

            // Set email subject
            oMail.Subject = "Return the password";

            // Set email body
            oMail.TextBody = "your UserID is "+ user.UserID+" your Password is "+ user.Password;
            // Gmail SMTP server address
            SmtpServer oServer = new SmtpServer("smtp.gmail.com");

            // Set 465 port
            oServer.Port = 465;

            // detect SSL/TLS automatically
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            // Gmail user authentication
            // For example: your email is "gmailid@gmail.com", then the user should be the same
            oServer.User = "jingweizhangcscs@gmail.com";
            oServer.Password = "13119195266Zjw";
            try
            {
                Console.WriteLine("start to send email over SSL ...");
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }
    }
}
