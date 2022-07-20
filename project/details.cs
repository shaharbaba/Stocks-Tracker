using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Newtonsoft.Json.Linq;  //Install-Package Newtonsoft.Json -Version 13.0.1
using System.Linq;

namespace project
{
    internal class details
    {
        public static string from = "Coinssummary@gmail.com";
        public static string to = "shaharbaba12@gmail.com";
        public static string subject = "Coins summary";

        public static string username = "Coinssummary@gmail.com"; // get from Mailtrap
        public static string appPass = "vrjttszsndwpdeew"; // app password

        public static string host = "smtp.gmail.com";
        public static int port = 587;
    }
}
