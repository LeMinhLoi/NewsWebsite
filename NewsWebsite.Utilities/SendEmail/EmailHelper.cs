using System;
using System.Net;
using System.Net.Mail;

namespace NewsWebsite.Utilities.SendEmail
{
    public class EmailHelper
    {
        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("leminhloi0410@gmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));
            mailMessage.Subject = "Password Reset";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            SmtpClient client = new SmtpClient();
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            client.Host = "News_website";
            client.Port = 80;

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return false;
        }
    }
}
