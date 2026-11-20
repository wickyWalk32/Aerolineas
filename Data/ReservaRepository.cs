using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reserva>> GetAllAsync()
        {
            return await _context.Reservas
                .Include(r => r.Pasajes)
                    .ThenInclude(p => p.Pasajero)
                .Include(r => r.Pasajes)
                    .ThenInclude(p => p.Servicios)
                .ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(int id)
        {
            return await _context.Reservas
                .Include(r => r.Pasajes)
                    .ThenInclude(p => p.Pasajero)
                .Include(r => r.Pasajes)
                    .ThenInclude(p => p.Servicios)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<string>> GetAsientosOcupadosPorVueloAsync(int vueloId)
        {
            var vuelo = await _context.Vuelos
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == vueloId);

            if (vuelo == null)
                throw new ArgumentException($"No existe un vuelo con Id {vueloId}.");

            return await _context.Pasajes
                .AsNoTracking()
                .Where(p => p.Reserva.VueloId == vueloId
                         && p.IdAvion == vuelo.IdAvion
                         && p.Estado != "Cancelado"
                         && p.CodigoAsiento != null && p.CodigoAsiento != "")
                .Select(p => p.CodigoAsiento)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> ExisteAsientoOcupadoEnVueloAsync(int vueloId, int idAvion, string codigoAsiento)
        {
            return await _context.Pasajes
                .AnyAsync(p => p.IdAvion == idAvion
                            && p.CodigoAsiento == codigoAsiento
                            && p.Estado != "Cancelado"
                            && p.Reserva.VueloId == vueloId);
        }

        public async Task<Reserva> AddAsync(Reserva reserva)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                if (reserva.TarjetaCliente != null)
                {
                    _context.Tarjetas.Add(reserva.TarjetaCliente);
                    await _context.SaveChangesAsync();
                    reserva.SetIdTarjetaCliente(reserva.TarjetaCliente.Id);
                }

                foreach (var pasaje in reserva.Pasajes)
                {
                    if (pasaje.Pasajero != null)
                    {
                        _context.Pasajeros.Add(pasaje.Pasajero);
                    }
                }

                await _context.SaveChangesAsync();

                foreach (var pasaje in reserva.Pasajes)
                {
                    if (pasaje.Pasajero != null)
                    {
                        pasaje.SetIdPasajero(pasaje.Pasajero.Id);
                    }
                }

                _context.Reservas.Add(reserva);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return reserva;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateAsync(Reserva reserva)
        {
            _context.Entry(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reserva reserva)
        {
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
        }
    }
}