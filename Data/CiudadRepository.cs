using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CiudadRepository : ICiudadRepository
    {
        private readonly AppDbContext _context;
        
        public CiudadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ciudad>> GetAllAsync()
        {
            return await _context.Ciudades.Include(c => c.Pais).ToListAsync();
        }


        public async Task<Ciudad?> GetByIdAsync(int id)
        { 
            return await _context.Ciudades.Include(c => c.Pais).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Ciudad ciudad)
        {
            _context.Ciudades.Add(ciudad);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ciudad ciudad)
        {
            _context.Entry(ciudad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ciudad ciudad)
        {
            _context.Ciudades.Remove(ciudad);
            await _context.SaveChangesAsync();
        }

    }
}
