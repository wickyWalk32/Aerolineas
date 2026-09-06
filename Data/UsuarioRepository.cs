using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        // Para LOGIN
        public Usuario? ObtenerPorEmail(string email)
        {
            using (var db = new AppDbContext())
            {
                return db.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            }
        }

        // Menu de Administrador - CRUD de Usuarios
        public UsuarioRepository()
        {
            _context = new AppDbContext();
        }

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // Menu de Administrador - CRUD de Usuarios
        public List<Usuario> ObtenerTodos()
        {
            using (var db = new AppDbContext())
            {
                return db.Usuarios.ToList();
            }
        }

        // Menu de Administrador - CRUD de Usuarios
        public void Agregar(Usuario usuario)
        {
            using (var db = new AppDbContext())
            {
                // Aseguramos un Hash genérico si viene vacío para cumplir con IsRequired()
                if (string.IsNullOrEmpty(usuario.ContraseniaHash))
                {
                    usuario.ContraseniaHash = "123456";
                }

                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
        }

        // Menu de Administrador - CRUD de Usuarios
        public void Actualizar(Usuario usuario)
        {
            using (var db = new AppDbContext())
            {
                db.Usuarios.Update(usuario);
                db.SaveChanges(); // SQL UPDATE
            }
        }

        // Menu de Administrador - CRUD de Usuarios
        public void Eliminar(int id)
        {
            using (var db = new AppDbContext())
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges(); // SQL DELETE
                }
            }
        }

        public async Task<Usuario?> GetByIdAsync(int id)
            => await _context.Usuarios.FindAsync(id);

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
            => await _context.Usuarios.AnyAsync(e => e.Id == id);
    }

}