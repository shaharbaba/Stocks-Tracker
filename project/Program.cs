using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

public class Program
{
    public static void Main()
    {
        string urlAddress = "https://crypto.com/price";
        WriteMessage("Getting the data", ConsoleColor.Green);
        string html = GetHtmlString(urlAddress);

        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);

        HtmlNode Bitcoin_price = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div[2]/div[4]/table/tbody/tr[1]/td[4]/div");
        HtmlNode Bitcoin_change = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div[2]/div[4]/table/tbody/tr[1]/td[5]/p");

        HtmlNode Ethereum_price = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div[2]/div[4]/table/tbody/tr[2]/td[4]/div");
        HtmlNode Ethereum_change = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div[2]/div[4]/table/tbody/tr[2]/td[5]/p");

        HtmlNode Binance_price = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div[2]/div[4]/table/tbody/tr[3]/td[4]/div");
        HtmlNode Binance_change = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div[2]/div[4]/table/tbody/tr[3]/td[5]/p");

        HtmlNode Tether_price = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div[2]/div[4]/table/tbody/tr[5]/td[4]/div");
        HtmlNode Tether_change = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div[2]/div[4]/table/tbody/tr[5]/td[5]/p");

        HtmlNode Axie_Infiniy_price = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div[2]/div[4]/table/tbody/tr[26]/td[4]/div");
        HtmlNode Axie_Infiniy_change = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div[2]/div[4]/table/tbody/tr[26]/td[5]/p");


        if (html != null)
        {
            //WriteMessage("Success!", ConsoleColor.Green);
            
            
            //var output = TelAviv35 != null ? TelAviv35.InnerText : "Error!!";
            //if (output == "Error!!")
            //    WriteMessage("Error!!");
            //else
            //Console.Write(TelAviv35.InnerText + ": ");
            Console.WriteLine("Hello,\nHere is your daily coins summary -");
            Console.WriteLine("Bitcoin: ");
            Console.WriteLine("Price: " + Bitcoin_price.InnerText );
            Console.WriteLine("24h %: " + Bitcoin_change.InnerText + "\n");

            Console.WriteLine("Ethereum: ");
            Console.WriteLine("Price: " + Ethereum_price.InnerText);
            Console.WriteLine("24h %: " + Ethereum_change.InnerText + "\n");

            Console.WriteLine("Binance Coin: ");
            Console.WriteLine("Price: " + Binance_price.InnerText);
            Console.WriteLine("24h %: " + Binance_change.InnerText + "\n");

            Console.WriteLine("Tether: ");
            Console.WriteLine("Price: " + Tether_price.InnerText );
            Console.WriteLine("24h %: " + Tether_change.InnerText + "\n");

            Console.WriteLine("Axie Infiniy: ");
            Console.WriteLine("Price: " + Axie_Infiniy_price.InnerText );
            Console.WriteLine("24h %: " + Axie_Infiniy_change.InnerText + "\n") ;
            string summary =
            
                "Hello,\nHere is your daily coins summary -\n" +
                    "Bitcoin: \n" + "Price: " + Bitcoin_price.InnerText + "\n24h %: " + Bitcoin_change.InnerText + "\n\n" +
                    "Ethereum: \n" + "Price: " + Ethereum_price.InnerText + "\n24h %: " + Ethereum_change.InnerText + "\n\n" +
                    "Binance Coin: \n" + "Price: " + Binance_price.InnerText + "\n24h %: " + Binance_change.InnerText + "\n\n" +
                    "Tether: \n" + "Price: " + Tether_price.InnerText + "\n24h %: " + Tether_change.InnerText + "\n\n" +
                    "Axie Infiniy: \n" + "Price: " + Axie_Infiniy_price.InnerText + "\n24h %: " + Axie_Infiniy_change.InnerText + "\n\n";
            
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("Coinssummary@gmail.com", "Coins123456"),
                EnableSsl = true,
            };
            //smtpClient.Send("Coinssummary@gmail.com", "shaharbaba12@gmail.com", "Coins Summary", summary);
        }
        else
        {
            WriteMessage("Fail", ConsoleColor.Red);
        }
    }
    //public string FindSpecificWords(string html)
    //{

    //}

    public static string GetHtmlString(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string data = null;

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;

            if (String.IsNullOrWhiteSpace(response.CharacterSet))
                readStream = new StreamReader(receiveStream);
            else
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

            data = readStream.ReadToEnd();

            response.Close();
            readStream.Close();
        }

        return data;
    }
    public static void WriteMessage(string st, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(st);
        Console.ForegroundColor = ConsoleColor.White;
    }
}

