using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PasajeRepository:IPasajeRepository
    {
        private readonly AppDbContext _context;
        public PasajeRepository(AppDbContext context) {
            _context = context;
        }
        public async Task<List<Pasaje>> GetAllAsync()
        {
            return await _context.Pasajes.ToListAsync();
        }


        public async Task<Pasaje?> GetByIdAsync(int id)
            => await _context.Pasajes.FindAsync(id);

        public async Task AddAsync(Pasaje pasaje)
        {
            _context.Pasajes.Add(pasaje);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pasaje pasaje)
        {
            _context.Entry(pasaje).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pasaje pasaje)
        {
            _context.Pasajes.Remove(pasaje);
            await _context.SaveChangesAsync();
        }
    }
}
