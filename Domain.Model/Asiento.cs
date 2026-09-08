using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Asiento
    {
        public string Codigo { get; private set; }

        public string Fila { get; private set; }
        public string Columna { get; private set; }

        public string Estado { get; private set; }

        private Avion _avion;
        private int _avionId;
        public Avion Avion { get; private set; }


        public int AvionId;

        public Asiento()
        {

        }
        public Asiento(string codigo,string fila, string columna,int avionId)
        {

        }


    }
}
