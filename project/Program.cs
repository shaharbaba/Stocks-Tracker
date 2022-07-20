using System;
using System.IO;
using System.Net;
using static project.details;
using static project.getPricesTemplate;
using static project.sendMessage;
using static project.writeMessageOnConsole;

public class Program
{
    public static void Main()
    {
        string[] coins = { "bitcoin","ethereum" };    // once you receiving names from the customer, you should receive array of string
        Console.WriteLine("The prices are: ");
        string pricesResult = GetPricesTemplate(coins);     // sends coins names array . receives template with all coins with their prices
        if (pricesResult != null)
        {
            sendMessageTemplate(pricesResult, from, to, subject, username, appPass, host, port);    // all details are in details calss

        }else
            WriteMessageOnConsole("Fail!", ConsoleColor.Red);
        // Console.WriteLine(pricesResult);     // for testing, printing in the console
    }


   
}