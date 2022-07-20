using System;
using System.IO;
using System.Net;
using System.Net.Mail;



namespace project
{
    internal class sendMessage
    {

        public static void sendMessageTemplate(string pricesResult, string from, string to, string subject, string username, string appPass, string host, int port)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(host, port))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(username, appPass);
                    MailMessage msg = new MailMessage();
                    msg.To.Add(to);
                    msg.From = new MailAddress(from);
                    msg.Subject = subject;
                    msg.Body = pricesResult;
                    client.Send(msg);
                };
            }
            catch
            {
                Console.WriteLine("Fail");
            }
            Console.WriteLine("Email sent");
        }
    }
}
