using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ItemConteoDTO
    {
        public string Etiqueta { get; set; } = string.Empty;
        public int Cantidad { get; set; }
    }

    public class ItemMontoDTO
    {
        public string Etiqueta { get; set; } = string.Empty;
        public decimal Monto { get; set; }
    }

    public class ReporteEstadisticasDTO
    {
        public DateTime FechaGeneracion { get; set; }
        public decimal RecaudacionTotal { get; set; }
        public decimal IngresosPasajesBase { get; set; }
        public decimal IngresosServiciosAdicionales { get; set; }
        public int TotalReservas { get; set; }
        public int TotalPasajes { get; set; }

        // Gráficos de barras
        public List<ItemConteoDTO> OrigenesMasElegidos { get; set; } = new();
        public List<ItemConteoDTO> DestinosMasElegidos { get; set; } = new();

        // Gráficos de torta
        public List<ItemMontoDTO> IngresosBaseVsServicios { get; set; } = new();
        public List<ItemConteoDTO> PasajesPorReserva { get; set; } = new();
        public List<ItemMontoDTO> IngresosPorDestino { get; set; } = new();
    }
}
