using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AsientoDTO
    {
        public int IdAvion {  get;private set; }
        public string Codigo {  get; set; }
        public char Fila { get; set; }
        public int Columna { get; set; }
        public string Estado { get; set; }

    }
    public class AsientoCreateDTO
    {
        public string Codigo { get; set; }
        public char Fila { get; set; }
        public int Columna { get; set; }
        public string Estado { get; set; }

    }
}
