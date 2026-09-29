using Domain.Model;
using DTOs;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
            List < Usuario > listaUsuarios = await _context.Usuarios.ToListAsync();
            return listaUsuarios;
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        { 
            Usuario usu = await _context.Usuarios.FindAsync(id);
            return usu;
        }

        // LOGIN
        public Usuario? GetByEmail(string email)
        {
            Usuario? usuario = _context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            return usuario;
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Como salio bien, lo devuelve y es oficialmente el usuario guardado en la bd. Y EF tiene este
            // objeto en memoria y con su inteligencia ya le cargo ID autogenerado.
            return usuario;
        }

        public async Task/*<Usuario>*/ UpdateAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            /*return usuario;*/
        }

        public async Task/*<Usuario>*/ DeleteAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            /*return usuario;*/
        }

        public async Task<bool> ExistsAsync(int id)
        { 
            return await _context.Usuarios.AnyAsync(e => e.Id == id);
        }

    }

}