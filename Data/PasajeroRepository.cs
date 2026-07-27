using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PasajeroRepository:IPasajeroRepository
    {
        private readonly AppDbContext _context;
        public PasajeroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task <List<Pasajero>> GetAllAsync()
        {
            return await _context.Pasajeros.ToListAsync();
        }

        public async Task<Pasajero?> GetByIdAsync(int id)
        {
            var pasajero = await _context.Pasajeros.FindAsync(id);
            if (pasajero == null) return null;
            return pasajero;
        }
        public async Task AddAsync(Pasajero pasajero)
        {
            _context.Pasajeros.Add(pasajero);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Pasajero pasajero)
        {
            _context.Entry(pasajero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Pasajero pasajero)
        {
            _context.Pasajeros.Remove(pasajero);
            await _context.SaveChangesAsync();
        }
    }
}
