using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ServicioRepository : IServicioRepository
    {

        private readonly AppDbContext _context;

        public ServicioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> GetAllAsync()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<Servicio?> GetByIdAsync(int id)
        {
            return await _context.Servicios.FindAsync(id);
        }

        public async Task AddAsync(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Servicio servicio)
        {
            _context.Entry(servicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Servicio servicio)
        {
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
        }

    }
}
