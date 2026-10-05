using Application.Services;
using Domain.Model;
using DTOs;
using WebApi.Services;

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
            .WithOpenApi()
            .RequireAuthorization();

            // 2. OBTENER UN USUARIO POR ID (GET)
            app.MapGet("/usuarios/{id}", async (int id, UsuarioService usuarioService) =>
            {
                var usuarioDto = await usuarioService.GetByIdAsync(id);
                return usuarioDto is not null ? Results.Ok(usuarioDto) : Results.NotFound();
            })
            .WithName("GetUsuarioById")
            .Produces<UsuarioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization();

            // 3. CREAR UN NUEVO USUARIO (POST) - Para el Auto Registro está en LoginEndpoints.cs
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
            .WithOpenApi()
            //.AllowAnonymous();
            .RequireAuthorization();

            // 4. EDITAR UN USUARIO (PUT)
            app.MapPut("/usuarios/{id}", async (int id, UsuarioUpdateDTO dto, UsuarioService usuarioService) =>
            {
                //if (dto == null || dto.Id != id)
                //{
                //    return Results.BadRequest(new { error = "Datos incoherentes o inválidos." });
                //}
                System.Console.Write(dto);
                var usuario = await usuarioService.UpdateAsync(id, dto);

                return Results.NoContent();
            })
            .WithName("UpdateUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization();

            // 5. ELIMINAR UN USUARIO (DELETE)
            app.MapDelete("/usuarios/{id}", async (int id, UsuarioService usuarioService) =>
            {
                await usuarioService.DeleteAsync(id);
                return Results.NoContent();
            })
            .WithName("DeleteUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .WithOpenApi()
            .RequireAuthorization();
        
        }
    }
}
