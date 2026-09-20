using Application.Services;
using DTOs;

namespace WebApi
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            // 1. OBTENER TODOS LOS USUARIOS (GET)
            app.MapGet("/usuarios", async (UsuarioService usuarioService) =>
            {
                var usuariosDto = await usuarioService.GetAllAsync();
                return Results.Ok(usuariosDto);
            })
            .WithName("GetAllUsuarios")
            .Produces<List<UsuarioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            // 2. CREAR UN NUEVO USUARIO (POST)
            app.MapPost("/usuarios", async (UsuarioCreateDTO dto, UsuarioService usuarioService) =>
            {
                try
                {
                    UsuarioDTO usuarioDto = await usuarioService.AddAsync(dto);
                    return Results.Created($"/usuarios/{usuarioDto.Id}", usuarioDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddUsuario")
            .Produces<UsuarioCreateDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            // 3. EDITAR UN USUARIO (PUT)
            app.MapPut("/usuarios/{id}", async (int id, UsuarioUpdateDTO dto, UsuarioService usuarioService) =>
            {
                //if (dto == null || dto.Id != id)
                //{
                //    return Results.BadRequest(new { error = "Datos incoherentes o inválidos." });
                //}
                System.Console.Write(dto);
                await usuarioService.UpdateAsync(id,dto);

                return Results.NoContent();
            })
            .WithName("UpdateUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            // 4. ELIMINAR UN USUARIO (DELETE)
            app.MapDelete("/usuarios/{id}", async (int id, UsuarioService usuarioService) =>
            {
                await usuarioService.DeleteAsync(id);
                return Results.NoContent();
            })
            .WithName("DeleteUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .WithOpenApi();

            // 5. LOGIN DE USUARIOS
            app.MapPost("/usuarios/login", (UsuarioLoginRequestDTO usuarioLoginRequestDto, UsuarioService usuarioService) =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(usuarioLoginRequestDto.Email) || string.IsNullOrWhiteSpace(usuarioLoginRequestDto.Contrasenia))
                    {
                        return Results.BadRequest(new UsuarioLoginResultDTO { Exitoso = false, Mensaje = "Debe ingresar email y contraseña." });
                    }

                    UsuarioLoginResultDTO resultado = usuarioService.ValidarLogin(usuarioLoginRequestDto);

                    if (!resultado.Exitoso)
                    {
                        return Results.Json(resultado, statusCode: StatusCodes.Status401Unauthorized);
                    }

                    return Results.Ok(resultado);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }

            })
            .WithName("LoginUsuario")
            .Produces<UsuarioLoginResultDTO>(StatusCodes.Status200OK)
            .Produces<UsuarioLoginResultDTO>(StatusCodes.Status401Unauthorized)
            .WithOpenApi();
        
        }
    }
}
