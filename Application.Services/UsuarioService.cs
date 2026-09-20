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
                Email = usuario.Email,
                Contrasenia = usuario.ContraseniaHash,
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

            await _repository.AddAsync(usuario);
            
            // Pregunta: es necesario que devuelva estainfo del usuario? se usa para algo en el front? o sacar?
            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Contrasenia = usuario.ContraseniaHash
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


        // LOGIN
        public UsuarioLoginResultDTO ValidarLogin(UsuarioLoginRequestDTO usuarioLoginRequestDto)
        {
            var usuario = _repository.GetByEmail(usuarioLoginRequestDto.Email);

            // 1. Validar si el usuario existe
            if (usuario == null)
            {
                return new UsuarioLoginResultDTO { Exitoso = false, Mensaje = "Credenciales inválidas." };
            }

            // 2. Validar contrasenia
            PasswordHasher<Usuario> passwordHasher = new();

            // Compara la contraseña que escribió el usuario con el hash de la base de datos
            PasswordVerificationResult resultado = passwordHasher.VerifyHashedPassword(
                usuario,
                usuario.ContraseniaHash,
                usuarioLoginRequestDto.Contrasenia // Contrasenia en texto plano
            );

            // Si falla por que la contrasenia es incorrecta, devolvemos el DTO con Exitoso = false
            if (resultado == PasswordVerificationResult.Failed)
            {
                return new UsuarioLoginResultDTO { Exitoso = false, Mensaje = "Credenciales inválidas." };
            }

            // 3. Si llega aquí, el login fue exitoso! Generas el Token JWT o la sesión

            return new UsuarioLoginResultDTO
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Rol = usuario.Rol,
                Exitoso = true,
                Mensaje = "Acceso concedido."
            };
        }

    }
}
