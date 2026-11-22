using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PasajeDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int IdPasajero { get; set; }
        public PasajeroDTO? Pasajero { get; set; }
        public int IdAvion { get; set; }
        public string CodigoAsiento { get; set; } = string.Empty;
        public List<ServicioCargaDTO>? Servicios { get; set; } = new();
    }

    public class PasajeCreateDTO
    {
        public string Estado { get; set; } = "Emitido";
        public int IdAvion { get; set; }
        public string CodigoAsiento { get; set; } = string.Empty;
        public PasajeroCreateDTO Pasajero { get; set; } = new();
        public List<int>? ServicioIds { get; set; } = new();
    }
}
