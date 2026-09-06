using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Ciudad
    {
        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public string CodigoPostal { get; private set; }

        public string CodigoAeropuerto { get; private set; }
        private Pais _pais;
        public Pais Pais { get; private set; }
        private int _paisId;
        public int PaisId { get; private set; }
        public Ciudad()
        {
        }

        public Ciudad(string nombre, string codPostal, string codAeropuerto)
        {
            SetNombre(nombre);
            SetCodigoPostal(codPostal);
            SetCodigoAeropuerto(codAeropuerto);
        }

        public void SetNombre(string nombre)
        {
            Nombre = Nombre;
        }

        public void SetCodigoPostal(string codPostal)
        {
            CodigoPostal = codPostal;
        }
        public void SetCodigoAeropuerto(string codAeropuerto)
        {
            CodigoAeropuerto = codAeropuerto;
        }
    }
}
