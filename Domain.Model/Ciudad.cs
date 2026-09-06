using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Ciudad
    {

        // Atributos de la clase Ciudad

        public int Id { get; private set; }

        public string Nombre { get; private set; } = string.Empty;

        public string CodigoPostal { get; private set; }

        public string CodigoAeropuerto { get; private set; } = string.Empty;

        // Relacion / Clave foranea ?
        
        private Pais _pais;
        
        public Pais Pais { get; private set; }
        
        private int _paisId;
        
        public int PaisId { get; private set; }
        
        
        // Constructores de la clase Ciudad

        public Ciudad()
        {
        }

        public Ciudad(string nombre, string codPostal, string codAeropuerto)
        {
            SetNombre(nombre);
            SetCodigoPostal(codPostal);
            SetCodigoAeropuerto(codAeropuerto);
        }

        // Métodos de la calse Ciudad

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
