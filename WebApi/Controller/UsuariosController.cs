using Application.Services;
using Domain.Model;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        /*
         Maneja el login y el CRUD de Usuarios
         */

        private readonly UsuarioService _usuarioService;

        public UsuariosController()
        {
            _usuarioService = new UsuarioService();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Contrasenia))
            {
                return BadRequest(new LoginResultDTO { Exitoso = false, Mensaje = "Debe ingresar email y contraseña." });
            }

            var resultado = _usuarioService.ValidarLoginAdmin(request);

            if (!resultado.Exitoso)
            {
                // Retorna HTTP 401 Unauthorized si falla el login o el rol
                return Unauthorized(resultado);
            }

            return Ok(resultado);
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            var usuarios = _usuarioService.ObtenerTodosLosUsuarios();
            return Ok(usuarios); // Retorna HTTP 200 con la lista formateada en JSON
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Los datos del usuario son inválidos.");
            }

            _usuarioService.CrearUsuario(usuario);

            // Retorna HTTP 200 OK
            return Ok(new { mensaje = "Usuario creado exitosamente" });
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.Id != id)
            {
                return BadRequest("Datos incoherentes o inválidos.");
            }

            _usuarioService.ActualizarUsuario(usuario);
            return Ok(new { mensaje = "Usuario actualizado correctamente" });
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioService.EliminarUsuario(id);
            return Ok(new { mensaje = "Usuario eliminado correctamente" });
        }

    }
}

/*
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Data;

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
*/