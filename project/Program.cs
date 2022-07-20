using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Newtonsoft.Json.Linq;  //Install-Package Newtonsoft.Json -Version 13.0.1
using System.Linq;
using static project.getPricesTemplate;
using static project.sendMessage;
using static project.writeMessageOnConsole;

public class Program
{
    public static void Main()
    {
        string[] coins = { "bitcoin","ethereum" };    // once you receiving names from the customer, you should receive array of string
        Console.WriteLine("The prices are: ");
        string pricesResult = GetPricesTemplate(coins);
        if(pricesResult != null)
        {
            sendMessageTemplate(pricesResult);

        }else
            WriteMessageOnConsole("Fail!", ConsoleColor.Red);
        // Console.WriteLine(pricesResult);     // for testing, printing in the console
    }


   
}