using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tektonExam;

namespace searchService
{
    interface ISearchClient
    {
        string searchNameClient { get; set; }
        string word { get; set; }
        servicio ResultadoBusqueda();
        public long searchWord();
    }
}
