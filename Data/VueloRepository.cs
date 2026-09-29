
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class VueloRepository : IVueloRepository
    {
        private readonly AppDbContext _context;

        public VueloRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vuelo>> GetAllAsync()
        {
            return await _context.Vuelos
                .Include(v => v.CiudadOrigen)
                .Include(v => v.CiudadDestino)
                .Include(v => v.Avion)
                .ToListAsync();
        }

        public async Task<Vuelo?> GetByIdAsync(int id)
        {
            return await _context.Vuelos
                .Include(v => v.CiudadOrigen)
                .Include(v => v.CiudadDestino)
                .Include(v => v.Avion)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Vuelo vuelo)
        {
            await _context.Vuelos.AddAsync(vuelo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vuelo vuelo)
        {
            _context.Vuelos.Update(vuelo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Vuelo vuelo)
        {
            _context.Vuelos.Remove(vuelo);
            await _context.SaveChangesAsync();
        }
    }
}
