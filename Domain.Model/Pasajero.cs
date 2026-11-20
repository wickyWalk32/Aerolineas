using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Pasajero
    {

        // <<< ATRIBUTOS >>>

        public int Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Apellido { get; private set; } = string.Empty;
        public string TipoDocumento { get; private set; } = string.Empty;
        public string NroDocumento { get; private set; } = string.Empty;
        public string Tipo { get; private set; }

        // <<< ATRIBUTOS DE NAVEGACIÓN DEL MODELO >>>

        // 1 Pasajero > Muchos Pasajes

        private readonly List<Pasaje> _pasajes = new();
        public IReadOnlyCollection<Pasaje> Pasajes => _pasajes.AsReadOnly();

        // <<< CONSTRUCTORES >>>

        public Pasajero() 
        { 
        }
        
        public Pasajero(string nombre, string apellido, string tipoDocumento, string nroDocumento)
        {
            this.SetNombre(nombre);
            this.SetApellido(apellido);
            this.SetTipoDocumento(tipoDocumento);
            this.SetNroDocumento(nroDocumento);
        }

        public Pasajero(string nombre, string apellido, string tipoDocumento, string nroDocumento, string tipo)
        {
            this.SetNombre(nombre);
            this.SetApellido(apellido);
            this.SetTipoDocumento(tipoDocumento);
            this.SetNroDocumento(nroDocumento);
            this.SetTipo(tipo);
        }

        // <<< MÉTODOS: SETTERS >>>

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id del pasajero inválido.");
            this.Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Nombre del pasajero inválido.");
            this.Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("Apellido del pasajero inválido.");
            this.Apellido = apellido;
        }

        public void SetTipoDocumento(string tipoDocumento)
        {
            if (string.IsNullOrWhiteSpace(tipoDocumento))
                throw new ArgumentException("Tipo de documento del pasajero inválido.");
            this.TipoDocumento = tipoDocumento;
        }

        public void SetNroDocumento(string nroDocumento)
        {
            if (string.IsNullOrWhiteSpace(nroDocumento))
                throw new ArgumentException("Número de documento del pasajero inválido.");
            this.NroDocumento = nroDocumento;
        }

        public void SetTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("Tipo de pasajero inválido.");
            this.Tipo = tipo;
        }

        // <<< DEMÁS MÉTODOS >>>

    }
}
