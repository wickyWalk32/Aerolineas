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

        // 1. Primera clave foránea y propiedad de navegación a Ciudad (Origen)
        public int OrigenId { get; set; }
        public Ciudad Origen { get; private set; }

        // 2. Segunda clave foránea y propiedad de navegación a Ciudad (Destino)
        public int DestinoId { get; set; }
        public Ciudad Destino { get; private set; }

        private List<Pasaje> _pasajes = new();

        public IReadOnlyCollection<Pasaje> Pasajes => _pasajes.AsReadOnly();
        public Avion Avion { get; private set; }

        public Vuelo()
        {
        }

    }
}
