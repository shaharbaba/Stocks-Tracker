using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;  //Install-Package Newtonsoft.Json -Version 13.0.1
using System.Linq;

namespace project
{
    internal class getPricesTemplate
    {
        public static string GetPricesTemplate(string[] coins)
        {
            string url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false"; // json of all coins
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);    // create http request
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = null;

            if (response.StatusCode == HttpStatusCode.OK)   // checking if the response status is ok
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
            else return null;


            if (data != null)
            {
                string results = "";
                var jArray = JArray.Parse(data);    // convert all data to json array
                for (int i = 0; i < coins.Length; i++)
                {
                    var result = new JArray(jArray.Where(r => r.Value<string>("id").Equals(coins[i])));    // looking for the desired value
                    results += coins[i] + " - " + result[0]["current_price"].Value<int>() + "$\n";          // build string will all coins prices
                }
                // Console.WriteLine(results);
                return "These are the prices for the coins you chosen:\n\n" + results + "\nSee you next time!";
            }
            return null;
        }
    }
}
