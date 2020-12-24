using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using tektonExam;

namespace searchService
{
    public class bingSearchClient : ISearchClient
    {
        private static string key = ConfigurationManager.AppSettings["BingKey"].ToString();
        public string searchNameClient { get; set; }
        public string word { get; set; }
        public servicio ResultadoBusqueda()
        {
            servicio result = new servicio();
            result.ServicioBusqueda = searchNameClient;
            result.Resultado = searchWord();

            return result;
        }
        public long searchWord()
        {
            if (word == "") return 0;
            long Result = 0;
            try
            {
                string uri = "https://api.bing.microsoft.com/v7.0/search?q="+ word;
                
                // Create web client.
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                WebClient client = new WebClient();


                // Set user agent and also accept-encoding headers. 
                client.Headers["Cache-Control"] = "no-cache";
                client.Headers["Ocp-Apim-Subscription-Key"] = key;

                var responseString = client.DownloadString(uri);

                JObject obj = JObject.Parse(responseString);
                Result = long.Parse(obj["webPages"]["totalEstimatedMatches"].ToString());                
            }
            catch (WebException ex)
            {

            }
            finally
            {

            }
            return Result;
        }
    }
}
