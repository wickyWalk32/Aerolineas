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
            //.AllowAnonymous();
            //.RequireAuthorization();

            // 3. EDITAR UN USUARIO (PUT)
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

            // 4. ELIMINAR UN USUARIO (DELETE)
            app.MapDelete("/usuarios/{id}", async (int id, UsuarioService usuarioService) =>
            {
                await usuarioService.DeleteAsync(id);
                return Results.NoContent();
            })
            .WithName("DeleteUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .WithOpenApi()
            .RequireAuthorization();

            // 5. LOGIN DE USUARIOS
            app.MapPost("/usuarios/login", (UsuarioLoginRequestDTO usuarioLoginRequestDto, UsuarioService usuarioService, JwtTokenService tokenService) =>
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

                    // Como el login fue exitoso, ya tenemos el Rol, Nombre y Apellido en 'resultado'.
                    // Creamos una entidad temporal (o adaptada) para que el JwtTokenService pueda generar los claims.
                    // Creamos la instancia asignando explícitamente el Id obtenido para que el JwtTokenService genere los Claims correctos.
                    // Nota: Si el JwtTokenService usa Email y Rol, pasarle el email que vino en el request y el rol del resultado.
                    var usuarioParaToken = new Usuario
                    (
                        resultado.Nombre,
                        resultado.Apellido,
                        usuarioLoginRequestDto.Email,
                        resultado.Rol
                    );
                    usuarioParaToken.SetId(resultado.Id);

                    // Generamos el Token JWT
                    string token = tokenService.GenerarToken(usuarioParaToken);

                    // Asignamos el token al resultado que se enviará al cliente de WindowsForms o Blazor.Server
                    resultado.Token = token;

                    return Results.Ok(resultado);
                }
                catch (Exception ex) when(ex is ArgumentException || ex is InvalidOperationException)
                {
                    // Unificamos las validaciones de negocio que devuelven un 400 Bad Request
                    return Results.BadRequest(ex.Message);
                }
                catch (Exception)
                {
                    // Para cualquier otro error grave o inesperado del sistema (fallo de base de datos, etc.)
                    return Results.Problem("Ocurrió un error interno en el servidor.", statusCode: 500);
                }

        })
            .WithName("LoginUsuario")
            .Produces<UsuarioLoginResultDTO>(StatusCodes.Status200OK)
            .Produces<UsuarioLoginResultDTO>(StatusCodes.Status401Unauthorized)
            .WithOpenApi();
        }

    }
}
