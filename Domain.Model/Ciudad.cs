using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Ciudad
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string CodigoPostal { get; set; }

        public string CodigoAeropuerto { get; set; }
        private Pais _pais;
        public Pais Pais { get; private set; }
        private int _paisId;
        public int PaisId { get; set; }
        
        
        // Constructores de la clase Ciudad

        public Ciudad()
        {
        }

        public Ciudad(string nombre, string codPostal, string codAeropuerto, int paisId)
        {
            SetNombre(nombre);
            SetCodigoPostal(codPostal);
            SetCodigoAeropuerto(codAeropuerto);
            SetPaisId(paisId);
        }

        // Métodos de la calse Ciudad

        public void SetNombre(string nombre)
        {
            Nombre = nombre;
        }

        public void SetCodigoPostal(string codPostal)
        {
            CodigoPostal = codPostal;
        }

        public void SetCodigoAeropuerto(string codAeropuerto)
        {
            CodigoAeropuerto = codAeropuerto;
        }
        public void SetPaisId(int paisId)
        {
            PaisId = paisId;
        }
    }
}
