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

        public async Task<UsuarioDTO?> GetByIdAsync(int id)
        {
            var usuario = await _repo.GetByIdAsync(id);
            if (usuario == null) return null;
            return  new UsuarioDTO
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    ContraseniaHash = usuario.ContraseniaHash,
                };
        }

        public async Task<UsuarioDTO> AddAsync(UsuarioCreateDTO usuarioCreateDTO)
        {
            Usuario usuario = new Usuario(usuarioCreateDTO.Email, usuarioCreateDTO.ContraseniaHash);
           await _repo.AddAsync(usuario);
            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                ContraseniaHash = usuario.ContraseniaHash
            };
            return usuarioDTO;
        }
        /*
           // var resultado = await _repo.AddAsync(usuarioDTO);
          */
        public async Task<bool> UpdateAsync(int id, UsuarioUpdateDTO usuarioUpdateDTO)
        {
            Usuario usuario = new Usuario
            {
                Id = usuarioUpdateDTO.Id,
                Email = usuarioUpdateDTO.Email,
                ContraseniaHash = usuarioUpdateDTO.ContraseniaHash,
            };
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
