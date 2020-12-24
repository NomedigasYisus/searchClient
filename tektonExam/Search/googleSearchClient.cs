using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
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
    public class googleSearchClient : ISearchClient
    {
        private static string key = ConfigurationManager.AppSettings["GoogleAPIKey"].ToString();
        private static string cx = ConfigurationManager.AppSettings["GoogleCEKey"].ToString();

        public string searchNameClient { get; set; }

        public string word { get; set; }

        long searchWordNugget()
        {
            var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = key });
            var listRequest = customSearchService.Cse.List();
            listRequest.Cx = cx;
            listRequest.Q = word;

            
            long Result = 0;
            try
            {
                var resultApi = listRequest.Execute().Queries.Request;

                Result = (long)resultApi[0].TotalResults;
            }
            catch
            {

            }
            finally
            {

            }

            return Result;
        }
        public servicio ResultadoBusqueda()
        {
            servicio result = new servicio();
            result.ServicioBusqueda = searchNameClient;
            result.Resultado = searchWord();
            return result;
        }
        public long searchWord()
        {
            if(word=="") return 0;
            long Result = 0;
            try
            {
                string uri = "https://customsearch.googleapis.com/customsearch/v1?key="+ key + "&cx="+ cx + "&q=" + word;

                // Create web client.
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                WebClient client = new WebClient();


                // Set user agent and also accept-encoding headers. 
                client.Headers["Cache-Control"] = "no-cache";

                var responseString = client.DownloadString(uri);

                JObject obj = JObject.Parse(responseString);
                Result = long.Parse(obj["queries"]["request"][0]["totalResults"].ToString());
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
