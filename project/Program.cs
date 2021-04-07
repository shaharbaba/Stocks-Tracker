using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


class Program
{
    static void Main()  
    {

       string url = "https://finance.themarker.com/";
       string csspath = "#__next > div.ep.eq > main > div > div.fn.gd > div.gr > table > tbody > tr:nth-child(1)";
       Console.WriteLine("Starting...");
       IWebDriver driver = new ChromeDriver();
        GreenMessage("Succeeded");
       driver.Navigate().GoToUrl(url);
       IWebElement element = driver.FindElement(By.CssSelector(csspath));
       Console.WriteLine(element.Text);
        //driver.Quit();
    }

    public static void GreenMessage(string st)
     {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(st);
        Console.ForegroundColor = ConsoleColor.White;
      }
    public static void RedMessage(string st)
    {
       Console.ForegroundColor = ConsoleColor.Red;
       Console.WriteLine(st);
       Console.ForegroundColor = ConsoleColor.White;
    }
}

