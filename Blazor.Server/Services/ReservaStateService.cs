using DTOs;

namespace Blazor.Server.Services
{
    public class ReservaStateService
    {
        public VueloDTO? VueloSeleccionado { get; set; }
        public int CantidadPasajeros { get; set; } = 1;
        public List<AsientoDTO> AsientosSeleccionados { get; set; } = new();

        public void IniciarReserva(VueloDTO vuelo, int cantidadPasajeros)
        {
            VueloSeleccionado = vuelo;
            CantidadPasajeros = cantidadPasajeros;
            AsientosSeleccionados.Clear();
        }
    }
}