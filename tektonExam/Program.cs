using searchService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tektonExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = ".net java php";

            List<ResultadoBusquedaModel> resul = buscarPalabras(value);
            obtenerResultado(resul);
            obtenerMayorPorLista(resul);
            obtenerTotalWinner(resul);
            string a = "";
        }
        public static List<ResultadoBusquedaModel> buscarPalabras(string value)
        {
            var textos = value.Split(' ');

            List<ResultadoBusquedaModel> Result = new List<ResultadoBusquedaModel>();

            foreach (string row in textos)
            {
                ResultadoBusquedaModel busquedaLine = new ResultadoBusquedaModel();
                busquedaLine.TextoBuscar = row;
                busquedaLine.servicios = new List<servicio>();

                foreach(string searchServiceRow in searchServiceList)
                {
                    ISearchClient search = searchService(searchServiceRow);
                    if (search != null)
                    {
                        search.searchNameClient = searchServiceRow;
                        search.word = row;
                        busquedaLine.servicios.Add(search.ResultadoBusqueda());
                    }
                }

                Result.Add(busquedaLine);
            }

            return Result;
        }
        public static void obtenerResultado(List<ResultadoBusquedaModel> data)
        {

            string resul = "";
            foreach (var row1 in data)
            {
                resul=row1.TextoBuscar+":";
                foreach(var row2 in row1.servicios)
                {
                    resul = resul + " " + row2.ServicioBusqueda + ":" + row2.Resultado.ToString();
                }
                Console.WriteLine(resul);
            }            
        }
        public static void obtenerMayorPorLista(List<ResultadoBusquedaModel> data)
        {
            string resul = "";
            foreach (string searchServiceRow in searchServiceList)
            {
                
                long mayor = 0;
                string winner = "";

                foreach (var row in data)
                {
                    foreach(var row1 in row.servicios)
                    {
                        if(row1.Resultado>=mayor && row1.ServicioBusqueda== searchServiceRow)
                        {
                            mayor = row1.Resultado;
                            winner = row.TextoBuscar;
                        }
                    }
                    
                }
                resul = searchServiceRow + " winner:"+winner;
                Console.WriteLine(resul);
            }

        }
        public static void obtenerTotalWinner(List<ResultadoBusquedaModel> data)
        {
            string resul = "";
            long mayor = 0;
            string winner = "";

            foreach (var row in data)
            {
                foreach (var row1 in row.servicios)
                {
                    if (row1.Resultado >= mayor)
                    {
                        mayor = row1.Resultado;
                        winner = row.TextoBuscar;
                    }
                }

            }
            resul = "Total winner:" + winner;
            Console.WriteLine(resul);           

        }
        public static  ISearchClient searchService(string client)
        {
            switch (client)
            {
                case "google":
                    return new googleSearchClient();
                case "bing":
                    return new bingSearchClient();
                default:
                    return null;
            }
        }
        public static List<string> searchServiceList = new List<string> { "google","bing","test"};
    }
}
