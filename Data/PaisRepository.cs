using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PaisRepository:IPaisRepository
    {
        private readonly AppDbContext _context;
        public PaisRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pais>> GetAllAsync()
        {
            return await _context.Paises.ToListAsync();
        }
        public async Task<Pais> GetByIdAsync(int paisId)
        {
            var pais = await _context.Paises.FindAsync(paisId);
            if(pais==null) return null;
            return pais;
        }

        public async Task AddAsync(Pais pais)
        {
            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pais pais)
        {
            _context.Paises.Remove(pais);
            await _context.SaveChangesAsync();
        }
    }
}
