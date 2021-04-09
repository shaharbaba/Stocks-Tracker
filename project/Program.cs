using System;
using System.IO;
using System.Net;
using System.Text;

public class Program
{
    public void Main()
    {
        string urlAddress = "https://finance.themarker.com/";
        WriteMessage("Getting the data", ConsoleColor.Green);
        string html = GetHtmlString(urlAddress);
        if (html != null)
        {
            WriteMessage("Success!", ConsoleColor.Green);
        }
        else
        {
            WriteMessage("Fail", ConsoleColor.Red);
        }
    }

    public string GetHtmlString(string url)
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

