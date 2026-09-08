using Application.Services;
using DTOs;

namespace WebApi
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            // 1. OBTENER TODOS LOS USUARIOS
            app.MapGet("/usuarios", () =>
            {
                UsuarioService usuarioService = new UsuarioService();
                var usuarios = usuarioService.ObtenerTodosLosUsuarios();
                return Results.Ok(usuarios);
            })
            .WithName("GetAllUsuarios")
            .Produces<List<UsuarioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            // 2. CREAR UN NUEVO USUARIO (POST)
            app.MapPost("/usuarios", (UsuarioDTO dto) =>
            {
                if (dto == null)
                {
                    return Results.BadRequest(new { error = "Los datos del usuario son inválidos." });
                }

                UsuarioService usuarioService = new UsuarioService();
                usuarioService.CrearUsuario(dto);

                return Results.Created($"/usuarios/{dto.Id}", dto);
            })
            .WithName("AddUsuario")
            .Produces<UsuarioDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            // 3. EDITAR UN USUARIO (PUT)
            app.MapPut("/usuarios/{id}", (int id, UsuarioDTO dto) =>
            {
                if (dto == null || dto.Id != id)
                {
                    return Results.BadRequest(new { error = "Datos incoherentes o inválidos." });
                }

                UsuarioService usuarioService = new UsuarioService();
                usuarioService.ActualizarUsuario(dto);

                return Results.NoContent();
            })
            .WithName("UpdateUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            // 4. ELIMINAR UN USUARIO (DELETE)
            app.MapDelete("/usuarios/{id}", (int id) =>
            {
                UsuarioService usuarioService = new UsuarioService();
                usuarioService.EliminarUsuario(id);

                return Results.NoContent();
            })
            .WithName("DeleteUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .WithOpenApi();

            // 5. LOGIN DE ADMINISTRADOR
            app.MapPost("/usuarios/login", (LoginRequestDTO request) =>
            {
                if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Contrasenia))
                {
                    return Results.BadRequest(new LoginResultDTO { Exitoso = false, Mensaje = "Debe ingresar email y contraseña." });
                }

                UsuarioService usuarioService = new UsuarioService();
                var resultado = usuarioService.ValidarLoginAdmin(request);

                if (!resultado.Exitoso)
                {
                    return Results.Json(resultado, statusCode: StatusCodes.Status401Unauthorized);
                }

                return Results.Ok(resultado);
            })
            .WithName("LoginUsuario")
            .Produces<LoginResultDTO>(StatusCodes.Status200OK)
            .Produces<LoginResultDTO>(StatusCodes.Status401Unauthorized)
            .WithOpenApi();
        }
    }
}
