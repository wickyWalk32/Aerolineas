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

        // LOGIN
        public LoginResultDTO? ObtenerPorEmail(string email)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            LoginResultDTO usuarioLoginDto = new LoginResultDTO();
            
            usuarioLoginDto.Nombre = usuario.Nombre;
            usuarioLoginDto.Apellido = usuario.Apellido;
            usuarioLoginDto.Email = usuario.Email;
            usuarioLoginDto.ContraseniaHash = usuario.ContraseniaHash;
            usuarioLoginDto.Rol = usuario.Rol;

            return usuarioLoginDto;
        }

        // LEER
        public List<Usuario> ObtenerTodos() // Menu de Administrador - CRUD de Usuarios
        {
            return _context.Usuarios.ToList();
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        { 
            return await _context.Usuarios.FindAsync(id);
        }

        // AGREGAR


        public async Task AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        // ACTUALIZAR
        public void Actualizar(UsuarioDTO usuarioDto) // Menu de Administrador - CRUD de Usuarios
        {
            var usuarioDb = _context.Usuarios.Find(usuarioDto.Id);
            
            if (usuarioDb != null)
            {
                usuarioDb.SetNombre(usuarioDto.Nombre);
                usuarioDb.SetApellido(usuarioDto.Apellido);
                usuarioDb.SetEmail(usuarioDto.Email);
                usuarioDb.SetRol(usuarioDto.Rol);

                _context.SaveChanges();
            }
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // ELIMINAR
        public void Eliminar(int id) // Menu de Administrador - CRUD de Usuarios
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }

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