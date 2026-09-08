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

        public UsuarioRepository()
        {
            _context = new AppDbContext();
        }

        // LOGIN
        public Usuario? ObtenerPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
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
        public void Agregar(UsuarioDTO usuarioDto) // Menu de Administrador - CRUD de Usuarios
        {

            // Validar duplicados antes de insertar
            if (_context.Usuarios.Any(u => u.Email.ToLower() == usuarioDto.Email.ToLower()))
            {
                throw new InvalidOperationException($"El email '{usuarioDto.Email}' ya está registrado.");
            }

            Usuario usuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                Email = usuarioDto.Email,
                Rol = usuarioDto.Rol,
                ContraseniaHash = string.IsNullOrEmpty(usuarioDto.ContraseniaHash) ? "123456" : usuarioDto.ContraseniaHash
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

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
                usuarioDb.Nombre = usuarioDto.Nombre;
                usuarioDb.Apellido = usuarioDto.Apellido;
                usuarioDb.Email = usuarioDto.Email;
                usuarioDb.Rol = usuarioDto.Rol;

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