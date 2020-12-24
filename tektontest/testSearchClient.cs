using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tektontest
{
    [TestClass]
    public class testSearchClient
    {
        [DataRow(".net", 12470000000)]
        [DataRow("java", 605000000)]
        [DataRow("php", 8510000000)]        
        [TestMethod]
        public void googleSearchClient_searchword_ShouldGetSameResult(string word,long expected)
        {
            searchService.googleSearchClient Search = new searchService.googleSearchClient();
            Search.word=word;

            long resultado = Search.searchWord();

            Assert.AreEqual(resultado,expected);

        }
        [DataRow(".net", 86900000)]
        [DataRow("java", 107000000)]
        [DataRow("php", 6290000000)]
        [TestMethod]
        public void BingSearchClient_searchword_ShouldGetSameResult(string word, long expected)
        {
            searchService.bingSearchClient Search = new searchService.bingSearchClient();
            Search.word = word;

            long resultado = Search.searchWord();

            Assert.AreEqual(resultado, expected);

        }
    }
}
