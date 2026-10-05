using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain.Model;
using DTOs;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class LoginService
    {

        private readonly IUsuarioRepository _repository;

        public LoginService(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        // AUTOREGISTRO DE USUARIOS COMUNES
        public async Task<UsuarioDTO> AddAsync(UsuarioRegistroDTO usuarioCreateDTO)
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

            // 3. Si llega aquí, el login fue exitoso! Se genera el Token JWT / o la sesión

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
