using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AvionRepository:IAvionRepository
    {
        private readonly AppDbContext _context;

        public AvionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Avion>> GetAllAsync()
        {
            List<Avion> aviones = await _context.Aviones.ToListAsync();
            return aviones;
        }
                                 
        public async Task<Avion?> GetByIdAsync(int id)
        {
            return await _context.Aviones.FirstOrDefaultAsync(a=>a.Id==id); 
        }

        public async Task AddAsync(Avion avion)
        {
            _context.Aviones.Add(avion);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Avion avion)
        {
            _context.Aviones.Entry(avion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Avion avion)
        {
            _context.Aviones.Remove(avion);
            await _context.SaveChangesAsync();
        }


    }
}
