using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Text;

public class Program
{
    public static void Main()
    {
        string urlAddress = "https://finance.themarker.com/";
        WriteMessage("Getting the data", ConsoleColor.Green);
        string html = GetHtmlString(urlAddress);

        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        HtmlNode TelAviv35 = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[4]/main/div/div[2]/div[3]/div/div[1]/table/tbody/tr[1]/td[1]");
        HtmlNode TelAviv35_rate = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[4]/main/div/div[2]/div[3]/div/div[1]/table/tbody/tr[1]/td[2]");
        HtmlNode TelAviv35_change = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[4]/main/div/div[2]/div[3]/div/div[1]/table/tbody/tr[1]/td[3]");

        if (html != null)
        {
            WriteMessage("Success!", ConsoleColor.Green);
            //var output = TelAviv35 != null ? TelAviv35.InnerText : "Error!!";
            //if (output == "Error!!")
            //    WriteMessage("Error!!");
            //else
            //Console.Write(TelAviv35.InnerText + ": ");
            Console.Write("Tel Aviv 35: ");
            Console.Write(TelAviv35_rate.InnerText + " , ");
            Console.WriteLine(TelAviv35_change.InnerText + "%");
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

