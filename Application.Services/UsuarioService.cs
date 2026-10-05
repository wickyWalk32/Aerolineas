using Application.Services;
using Data;
using Domain.Model;
using DTOs;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class UsuarioService
    {

        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        public async Task<List<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await _repository.GetAllAsync();

            return usuarios.Select(usuario => new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Contrasenia = usuario.ContraseniaHash,
                Rol = usuario.Rol
            }).ToList();
        }

        public async Task<UsuarioDTO?> GetByIdAsync(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);

            if (usuario == null) return null;
            
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Contrasenia = usuario.ContraseniaHash,
                Rol = usuario.Rol
            };
        }
        
        public async Task<UsuarioDTO> AddAsync(UsuarioCreateDTO usuarioCreateDTO)
        {
            // Aquí es donde se disparan todas las validaciones de los setters de Usuario.
            Usuario usuario = new Usuario(  usuarioCreateDTO.Nombre,
                                            usuarioCreateDTO.Apellido,
                                            usuarioCreateDTO.Email,
                                            usuarioCreateDTO.Contrasenia,
                                            usuarioCreateDTO.Rol);

            Usuario usuarioGuardado = await _repository.AddAsync(usuario);
            
            // EF carga id autogenerado por la bd en 'usuario' xq es inteligente y lo tiene en memoria xq se paso al repositorio para
            // hacer la operación en la bd.
            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Rol = usuario.Rol
            };

            return usuarioDTO;
        }
        
        public async Task<bool> UpdateAsync(int id, UsuarioUpdateDTO usuarioUpdateDTO)
        {
            var usuario = await _repository.GetByIdAsync(id);

            if (usuario == null)
            {
                return false;
            }

            usuario.SetNombre(usuarioUpdateDTO.Nombre);
            usuario.SetApellido(usuarioUpdateDTO.Apellido);
            usuario.SetEmail(usuarioUpdateDTO.Email);
            usuario.SetRol(usuarioUpdateDTO.Rol);

            //Solo actualizar contraseña si se proporciona y es distinta a la actual
            if (!string.IsNullOrWhiteSpace(usuarioUpdateDTO.Contrasenia) &&
                usuarioUpdateDTO.Contrasenia!= usuario.ContraseniaHash)
            {
                usuario.SetContraseniaHash(usuarioUpdateDTO.Contrasenia);
            }

            await _repository.UpdateAsync(usuario);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);

            if (usuario == null) return false;

            await _repository.DeleteAsync(usuario);

            return true;
        }

        public Task<bool> ExistsAsync(int id)
            => _repository.ExistsAsync(id);

    }
}
