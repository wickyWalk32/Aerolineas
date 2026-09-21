using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Asiento
    {
        // <<< ATRIBUTOS >>>

        public string Codigo { get; private set; } = string.Empty;
        public Char Fila { get; private set; }
        public int Columna { get; private set; }
        public string Estado { get; private set; } = string.Empty;


        // <<< ATRIBUTOS DE NAVEGACIÓN DEL MODELO>>>

        // 1 Asiento > 1 Avión
        public int IdAvion { get; private set; }
        public Avion Avion { get; private set; }

        // 1 Asiento > Muchos Pasajes

        private readonly List<Pasaje> _pasajes = new();
        public IReadOnlyCollection<Pasaje> Pasajes => _pasajes.AsReadOnly();


        // <<< CONSTRUCTORES >>>

        public Asiento()
        {
        }
        public Asiento(char fila, int columna, string estado, int idAvion, Avion avion)
        {
            this.SetFila(fila);
            this.SetColumna(columna);
            this.SetEstado(estado);
            this.SetIdAvion(idAvion);
            this.SetAvion(avion);
        }

        public Asiento(string codigo, char fila, int columna, string estado, int idAvion, Avion avion)
        {
            this.SetCodigo(codigo);
            this.SetFila(fila);
            this.SetColumna(columna);
            this.SetEstado(estado);
            this.SetIdAvion(idAvion);
            this.SetAvion(avion);
        }

        // <<< MÉTODOS: SETTERS >>>

        public void SetCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("Codigo de asiento para vuelo es inválido.");
            this.Codigo = codigo;
        }

        public void SetFila(char fila)
        {
            this.Fila = fila;
        }

        public void SetColumna(int columna)
        {
            if (columna < 0)
                throw new ArgumentException("Columna de asiento es inválida.");
            this.Columna = columna;
        }

        public void SetEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("Estado de asiento es inválido.");
            this.Estado = estado;
        }

        public void SetIdAvion(int idAvion)
        {
            if (idAvion < 0)
                throw new ArgumentException("Id de avión del asiento es inválida.");
            this.Columna = idAvion;
        }

        public void SetAvion(Avion avion)
        {
            if (avion == null)
                throw new ArgumentException("Avión del asiento es inválido.");
            this.Avion = avion;
        }

        public void AddPasaje(Pasaje pasaje)
        {
            ArgumentNullException.ThrowIfNull(pasaje);
            _pasajes.Add(pasaje);
        }

        public void RemovePasaje(Pasaje pasaje)
        {
            ArgumentNullException.ThrowIfNull(pasaje);
            _pasajes.Remove(pasaje);
        }

        // <<< DEMÁS MÉTODOS >>>

    }
}
