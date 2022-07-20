using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Newtonsoft.Json.Linq;  //Install-Package Newtonsoft.Json -Version 13.0.1
using System.Linq;
using static project.details;



namespace project
{
    internal class sendMessage
    {

        public static void sendMessageTemplate(string summary)
        {
            var body = summary;
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
                    msg.Body = body;
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
