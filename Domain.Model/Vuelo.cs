using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Vuelo
    {
        public int Id { get; private set; }
        public DateTimeOffset TiempoSalida { get; private set; }
        public DateTimeOffset TiempoLlegada { get; private set; }
        public string Estado { get; private set; }
        public decimal Precio { get; private set; }
        public Ciudad Origen {  get; private set; }
        public Ciudad Destino { get; private set; }
        private Ciudad _origen;
        private Ciudad _destino;
        public int OrigenId;
        public int DestinoId;
        private List<Pasaje> _pasajes = new();

        public IReadOnlyCollection<Pasaje> Pasajes => _pasajes.AsReadOnly();
        public Avion Avion { get; private set; }

        public Vuelo()
        {
        }

    }
}
