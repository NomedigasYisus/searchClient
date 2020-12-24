using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tektonExam
{    public class ResultadoBusquedaModel
    {
        public string TextoBuscar { get; set; }
        
        public List<servicio> servicios { get; set; }
    }
    public class servicio
    {
        public string ServicioBusqueda { get; set; }
        public long Resultado { get; set; }
    }
}
