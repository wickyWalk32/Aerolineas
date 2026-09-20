using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Humanizer;
using System;

namespace Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        { 
            return await _context.Usuarios.FindAsync(id);
        }

        // LOGIN
        public Usuario? GetByEmail(string email)
        {
            Usuario? usuario = _context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            return usuario;
        }

        public async Task AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        { 
            return await _context.Usuarios.AnyAsync(e => e.Id == id);
        }

    }

}