using Data;
using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ReservaService
    {
        private readonly IReservaRepository _repo;
        private readonly AppDbContext _context;

        public ReservaService(IReservaRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<List<ReservaDTO>> GetAllAsync()
        {
            var reservas = await _repo.GetAllAsync();
            return reservas.Select(MapToDTO).ToList();
        }

        public async Task<ReservaDTO?> GetByIdAsync(int id)
        {
            var reserva = await _repo.GetByIdAsync(id);
            return reserva == null ? null : MapToDTO(reserva);
        }

        public async Task<List<string>> GetAsientosOcupadosPorVueloAsync(int vueloId)
        {
            return await _repo.GetAsientosOcupadosPorVueloAsync(vueloId);
        }

        public async Task<ReservaDTO> AddAsync(ReservaCreateDTO dto)
        {
            if (dto.Pasajes == null || dto.Pasajes.Count == 0)
                throw new ArgumentException("La reserva debe incluir al menos un pasaje.");

            if (dto.VueloId <= 0)
                throw new ArgumentException("Debe indicar un vuelo válido para la reserva.");

            var ultimos4 = new string((dto.UltimosCuatroDigitos ?? string.Empty).Where(char.IsDigit).ToArray());
            if (ultimos4.Length != 4)
                throw new ArgumentException("Los últimos 4 dígitos de la tarjeta son inválidos.");

            var vuelo = await _context.Vuelos
                .Include(v => v.Avion)
                .FirstOrDefaultAsync(v => v.Id == dto.VueloId);

            if (vuelo == null)
                throw new ArgumentException($"No existe un vuelo con Id {dto.VueloId}.");

            // 1. Crear TarjetaCliente
            var tarjeta = new TarjetaCliente();
            tarjeta.SetUltimosCuatroDigitos(ultimos4);
            tarjeta.SetFechaVencimiento(dto.FechaVencimientoTarjeta == default ? DateTime.UtcNow.AddYears(1) : dto.FechaVencimientoTarjeta);

            // 2. Crear Reserva vinculada a Usuario, TarjetaCliente y Vuelo
            var reserva = new Reserva(dto.FechaHoraReserva == default ? DateTime.UtcNow : dto.FechaHoraReserva, dto.UsuarioId);
            reserva.SetTarjetaCliente(tarjeta);
            reserva.SetIdVuelo(vuelo.Id);
            reserva.SetVuelo(vuelo);

            // Cargar servicios solicitados una sola vez
            var todosLosServicioIds = dto.Pasajes
                .SelectMany(p => p.ServicioIds ?? Enumerable.Empty<int>())
                .Distinct()
                .ToList();

            var serviciosDb = await _context.Servicios
                .Where(s => todosLosServicioIds.Contains(s.Id))
                .ToDictionaryAsync(s => s.Id);

            // 3. Procesar y validar cada pasaje
            foreach (var pasajeDto in dto.Pasajes)
            {
                if (pasajeDto.Pasajero == null)
                    throw new ArgumentException("Cada pasaje debe tener los datos del pasajero.");

                var asiento = await _context.Asientos
                    .FirstOrDefaultAsync(a => a.AvionId == pasajeDto.IdAvion && a.Codigo == pasajeDto.CodigoAsiento);

                if (asiento == null)
                    throw new ArgumentException($"No existe el asiento {pasajeDto.CodigoAsiento} en el avión {pasajeDto.IdAvion}.");

                // Ocupación específica para ESTE vuelo (no global del avión)
                bool asientoOcupadoEnEsteVuelo = await _repo.ExisteAsientoOcupadoEnVueloAsync(
                    vuelo.Id,
                    pasajeDto.IdAvion,
                    pasajeDto.CodigoAsiento);

                if (asientoOcupadoEnEsteVuelo)
                    throw new ArgumentException($"El asiento {pasajeDto.CodigoAsiento} ya se encuentra ocupado en este vuelo.");

                var pasajero = new Pasajero(
                    pasajeDto.Pasajero.Nombre.Trim(),
                    pasajeDto.Pasajero.Apellido.Trim(),
                    pasajeDto.Pasajero.TipoDocumento.Trim(),
                    pasajeDto.Pasajero.NroDocumento.Trim(),
                    pasajeDto.Pasajero.Tipo.Trim()
                );

                var estadoPasaje = string.IsNullOrWhiteSpace(pasajeDto.Estado) ? "Confirmado" : pasajeDto.Estado.Trim();

                var pasaje = new Pasaje(
                    estadoPasaje,
                    reserva.Id,
                    reserva,
                    pasajero.Id,
                    pasajero,
                    asiento.AvionId,
                    asiento.Codigo,
                    asiento
                );

                if (pasajeDto.ServicioIds != null)
                {
                    foreach (var srvId in pasajeDto.ServicioIds.Distinct())
                    {
                        if (serviciosDb.TryGetValue(srvId, out var servicioEntidad))
                        {
                            pasaje.AddServicio(servicioEntidad);
                        }
                    }
                }

                reserva.AddPasaje(pasaje);
            }

            var reservaGuardada = await _repo.AddAsync(reserva);
            return MapToDTO(reservaGuardada);
        }

        public async Task<bool> UpdateAsync(int id, ReservaUpdateDTO dto)
        {
            var reserva = await _repo.GetByIdAsync(id);
            if (reserva == null)
                return false;

            if (dto.UsuarioId > 0)
                reserva.SetIdUsuario(dto.UsuarioId);

            if (dto.FechaHoraReserva != default)
                reserva.SetFechaHoraReserva(dto.FechaHoraReserva);

            await _repo.UpdateAsync(reserva);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reserva = await _repo.GetByIdAsync(id);
            if (reserva == null)
                return false;

            await _repo.DeleteAsync(reserva);
            return true;
        }

        private static ReservaDTO MapToDTO(Reserva reserva)
        {
            return new ReservaDTO
            {
                Id = reserva.Id,
                UsuarioId = reserva.UsuarioId,
                VueloId = reserva.VueloId,
                IdTarjetaCliente = reserva.IdTarjetaCliente,
                FechaHoraReserva = reserva.FechaHoraReserva,
                Pasajes = reserva.Pasajes.Select(p => new PasajeDTO
                {
                    Id = p.Id,
                    Estado = p.Estado,
                    IdPasajero = p.IdPasajero,
                    IdAvion = p.IdAvion,
                    CodigoAsiento = p.CodigoAsiento,
                    Pasajero = p.Pasajero == null ? null : new PasajeroDTO
                    {
                        Id = p.Pasajero.Id,
                        Nombre = p.Pasajero.Nombre,
                        Apellido = p.Pasajero.Apellido,
                        TipoDocumento = p.Pasajero.TipoDocumento,
                        NroDocumento = p.Pasajero.NroDocumento,
                        Tipo = p.Pasajero.Tipo
                    },
                    Servicios = p.Servicios.Select(s => new ServicioCargaDTO
                    {
                        Id = s.Id,
                        Nombre = s.Nombre,
                        Descripcion = s.Descripcion,
                        Precio = s.Precio
                    }).ToList()
                }).ToList()
            };
        }
    }
}