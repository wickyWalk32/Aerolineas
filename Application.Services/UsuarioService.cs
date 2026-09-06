using Application.Services;
using Domain.Model;
using DTOs;
using Data;

namespace Application.Services
{
    public class UsuarioService
    {

        /*
        Observación 1: quedaron ambos "IUsuarioRepository? _repo" y "UsuarioRepository? _repository" 
        para ahorrar tiempo. Implementar solo uno.
        Observación 2: UsuarioRepository? _repository tiene "?" para evitar errores y poder ejecutar
        el código.
        */

        private readonly IUsuarioRepository? _repo;

        // Menu de Administrador - CRUD de Usuarios
        private readonly UsuarioRepository? _repository;

        // Constructor agregado para Menu de Administrador - CRUD de Usuarios
        public UsuarioService()
        {
            _repository = new UsuarioRepository();
        }

        // LOGIN
        public LoginResultDTO ValidarLoginAdmin(LoginRequestDTO loginDto)
        {
            var usuario = _repository.ObtenerPorEmail(loginDto.Email);

            // 1. Validar si el usuario existe
            if (usuario == null)
            {
                return new LoginResultDTO { Exitoso = false, Mensaje = "Credenciales inválidas." };
            }

            // 2. Validar contraseña
            if (usuario.ContraseniaHash != loginDto.Contrasenia)
            {
                return new LoginResultDTO { Exitoso = false, Mensaje = "Credenciales inválidas." };
            }

            // 3. Validar que tenga Rol "admin" (insensible a mayúsculas/minúsculas)
            if (string.IsNullOrEmpty(usuario.Rol) || !usuario.Rol.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                return new LoginResultDTO { Exitoso = false, Mensaje = "Acceso denegado: Se requieren permisos de Administrador." };
            }

            return new LoginResultDTO
            {
                Exitoso = true,
                Mensaje = "Acceso concedido.",
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Rol = usuario.Rol
            };

        }


        // Menu de Administrador - CRUD de Usuarios
        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            // Aquí irían reglas de negocio antes o después de consultar la BD
            return _repository.ObtenerTodos();
        }

        // Menu de Administrador - CRUD de Usuarios
        public void CrearUsuario(Usuario usuario)
        {
            // Podrías agregar validaciones de negocio aquí (ej: validar email duplicado)
            _repository.Agregar(usuario);
        }

        // Menu de Administrador - CRUD de Usuarios
        public void ActualizarUsuario(Usuario usuario)
        {
            _repository.Actualizar(usuario);
        }

        // Menu de Administrador - CRUD de Usuarios
        public void EliminarUsuario(int id)
        {
            _repository.Eliminar(id);
        }


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
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Rol = usuario.Rol
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

        public async Task<UsuarioDTO> AddAsync(UsuarioDTO usuarioCreateDTO)
        {
            Usuario usuario = new Usuario(  usuarioCreateDTO.Nombre,
                                            usuarioCreateDTO.Apellido,
                                            usuarioCreateDTO.Email,
                                            usuarioCreateDTO.ContraseniaHash,
                                            usuarioCreateDTO.Rol);
           await _repo.AddAsync(usuario);
            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                ContraseniaHash = usuario.ContraseniaHash
            };
            return usuarioDTO;
        }
        
        // Ver que es esto
        // var resultado = await _repo.AddAsync(usuarioDTO);
        
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
