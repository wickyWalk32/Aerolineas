using Application.Services;
using Domain.Model;
using DTOs;
using Data;

namespace Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await _repo.GetAllAsync();
            return usuarios.Select(usuario => new UsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                ContraseniaHash = usuario.ContraseniaHash,
            }).ToList();
        }

        public Task<Usuario?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task AddAsync(Usuario usuario)
            => _repo.AddAsync(usuario);

        public async Task<bool> UpdateAsync(int id, Usuario usuario)
        {
            if (id != usuario.Id)
                return false;

            await _repo.UpdateAsync(usuario);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return false;

            await _repo.DeleteAsync(user);
            return true;
        }

        public Task<bool> ExistsAsync(int id)
            => _repo.ExistsAsync(id);
    }
}
