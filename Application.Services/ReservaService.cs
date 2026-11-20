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
            var reservas = await _context.Reservas
                .Include(r => r.Pasajes)
                    .ThenInclude(p => p.Pasajero)
                .Include(r => r.Pasajes)
                    .ThenInclude(p => p.Servicios)
                .ToListAsync();

            return reservas.Select(MapToDTO).ToList();
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

            var vuelo = await _context.Vuelos.FirstOrDefaultAsync(v => v.Id == dto.VueloId);
            if (vuelo == null)
                throw new ArgumentException($"No existe un vuelo con Id {dto.VueloId}.");

            await using var transaction = await _context.Database.BeginTransactionAsync();

            // 1. Crear y guardar TarjetaCliente
            var tarjeta = new TarjetaCliente();
            tarjeta.SetUltimosCuatroDigitos(ultimos4);
            tarjeta.SetFechaVencimiento(dto.FechaVencimientoTarjeta == default ? DateTime.UtcNow.AddYears(1) : dto.FechaVencimientoTarjeta);

            _context.Tarjetas.Add(tarjeta);
            await _context.SaveChangesAsync();

            // 2. Crear Reserva vinculada a Usuario, TarjetaCliente y Vuelo
            var reserva = new Reserva(dto.FechaHoraReserva == default ? DateTime.UtcNow : dto.FechaHoraReserva, dto.UsuarioId);
            reserva.SetIdTarjetaCliente(tarjeta.Id);
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

            // 3. Procesar cada pasaje: Pasajero + Asiento ("ocupado") + Servicios
            foreach (var pasajeDto in dto.Pasajes)
            {
                if (pasajeDto.Pasajero == null)
                    throw new ArgumentException("Cada pasaje debe tener los datos del pasajero.");

                var asiento = await _context.Asientos
                    .FirstOrDefaultAsync(a => a.AvionId == pasajeDto.IdAvion && a.Codigo == pasajeDto.CodigoAsiento);

                if (asiento == null)
                    throw new ArgumentException($"No existe el asiento {pasajeDto.CodigoAsiento} en el avión {pasajeDto.IdAvion}.");

                if (string.Equals(asiento.Estado, "ocupado", StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException($"El asiento {pasajeDto.CodigoAsiento} ya se encuentra ocupado.");

                asiento.SetEstado("ocupado");

                var pasajero = new Pasajero(
                    pasajeDto.Pasajero.Nombre.Trim(),
                    pasajeDto.Pasajero.Apellido.Trim(),
                    pasajeDto.Pasajero.TipoDocumento.Trim(),
                    pasajeDto.Pasajero.NroDocumento.Trim(),
                    pasajeDto.Pasajero.Tipo.Trim()
                );

                _context.Pasajeros.Add(pasajero);
                await _context.SaveChangesAsync();

                var estadoPasaje = string.IsNullOrWhiteSpace(pasajeDto.Estado) ? "Confirmado" : pasajeDto.Estado.Trim();

                // Constructor de 8 argumentos de Pasaje:
                // (estado, idReserva, reserva, idPasajero, pasajero, idAvion, codigoAsiento, asiento)
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

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return MapToDTO(reserva);
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

/*------------------------------------------------------------
 * using Data;
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
            var reservas = await _context.Reservas
                .Include(r => r.Pasajes)
                    .ThenInclude(p => p.Pasajero)
                .Include(r => r.Pasajes)
                    .ThenInclude(p => p.Servicios)
                .ToListAsync();

            return reservas.Select(MapToDTO).ToList();
        }

        public async Task<ReservaDTO> AddAsync(ReservaCreateDTO dto)
        {
            if (dto.Pasajes == null || dto.Pasajes.Count == 0)
                throw new ArgumentException("La reserva debe incluir al menos un pasaje.");

            var ultimos4 = new string((dto.UltimosCuatroDigitos ?? string.Empty).Where(char.IsDigit).ToArray());
            if (ultimos4.Length != 4)
                throw new ArgumentException("Los últimos 4 dígitos de la tarjeta son inválidos.");

            await using var transaction = await _context.Database.BeginTransactionAsync();

            // 1. Crear y guardar TarjetaCliente
            var tarjeta = new TarjetaCliente();
            tarjeta.SetUltimosCuatroDigitos(ultimos4);
            tarjeta.SetFechaVencimiento(dto.FechaVencimientoTarjeta == default ? DateTime.UtcNow.AddYears(1) : dto.FechaVencimientoTarjeta);

            _context.Tarjetas.Add(tarjeta);
            await _context.SaveChangesAsync();

            // 2. Crear Reserva vinculada a Usuario y TarjetaCliente
            var reserva = new Reserva(dto.FechaHoraReserva == default ? DateTime.UtcNow : dto.FechaHoraReserva, dto.UsuarioId);
            reserva.SetIdTarjetaCliente(tarjeta.Id);
            reserva.SetTarjetaCliente(tarjeta);

            // Cargar servicios solicitados una sola vez
            var todosLosServicioIds = dto.Pasajes
                .SelectMany(p => p.ServicioIds ?? Enumerable.Empty<int>())
                .Distinct()
                .ToList();

            var serviciosDb = await _context.Servicios
                .Where(s => todosLosServicioIds.Contains(s.Id))
                .ToDictionaryAsync(s => s.Id);

            // 3. Procesar cada pasaje: Pasajero + Asiento ("ocupado") + Servicios
            foreach (var pasajeDto in dto.Pasajes)
            {
                if (pasajeDto.Pasajero == null)
                    throw new ArgumentException("Cada pasaje debe tener los datos del pasajero.");

                var asiento = await _context.Asientos
                    .FirstOrDefaultAsync(a => a.AvionId == pasajeDto.IdAvion && a.Codigo == pasajeDto.CodigoAsiento);

                if (asiento == null)
                    throw new ArgumentException($"No existe el asiento {pasajeDto.CodigoAsiento} en el avión {pasajeDto.IdAvion}.");

                if (string.Equals(asiento.Estado, "ocupado", StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException($"El asiento {pasajeDto.CodigoAsiento} ya se encuentra ocupado.");

                asiento.SetEstado("ocupado");

                var pasajero = new Pasajero(
                    pasajeDto.Pasajero.Nombre.Trim(),
                    pasajeDto.Pasajero.Apellido.Trim(),
                    pasajeDto.Pasajero.TipoDocumento.Trim(),
                    pasajeDto.Pasajero.NroDocumento.Trim(),
                    pasajeDto.Pasajero.Tipo.Trim()
                );

                _context.Pasajeros.Add(pasajero);
                await _context.SaveChangesAsync();

                var estadoPasaje = string.IsNullOrWhiteSpace(pasajeDto.Estado) ? "Confirmado" : pasajeDto.Estado.Trim();
                var pasaje = new Pasaje(estadoPasaje, pasajero.Id, pasajero, asiento.AvionId, asiento.Codigo, asiento);

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

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return MapToDTO(reserva);
        }

        private static ReservaDTO MapToDTO(Reserva reserva)
        {
            return new ReservaDTO
            {
                Id = reserva.Id,
                UsuarioId = reserva.UsuarioId,
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
}*/

/*----------------------------------------------------------
 * using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReservaService
    {
        private readonly IReservaRepository _repo;

        public ReservaService(IReservaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ReservaDTO>> GetAllAsync()
        {
            var reservas = await _repo.GetAllAsync();
            return reservas.Select(reserva => new ReservaDTO
            {
                Id = reserva.Id,
                FechaHoraReserva = reserva.FechaHoraReserva,
                UsuarioId = reserva.UsuarioId,
            }).ToList();
        }
        public async Task<ReservaDTO> AddAsync(ReservaCreateDTO dto)
        {
            Reserva reserva = new Reserva(dto.FechaHoraReserva, dto.UsuarioId);
            await _repo.AddAsync(reserva);
            ReservaDTO reservaDTO = new ReservaDTO
            {
                Id = reserva.Id,
                FechaHoraReserva = reserva.FechaHoraReserva,
                UsuarioId = reserva.UsuarioId,
            };
            return reservaDTO;
        }

    }
}
*/