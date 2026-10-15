using Application.Services;
using DTOs;
using WebApi.Services;

namespace WebApi
{
    public static class LoginEndpoints
    {
        public static void MapLoginEndpoints(this WebApplication app)
        {

            // Auto-registro de usuario común
            app.MapPost("/registro", async (UsuarioRegistroDTO dto, LoginService loginService) =>
            {
                try
                {
                    dto.Rol = "usuario";
                    UsuarioDTO usuarioDto = await loginService.AddAsync(dto);
                    return Results.Created($"/usuarios/{usuarioDto.Id}", usuarioDto);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddUsuarioRegister")
            .Produces<UsuarioCreateDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            // Login
            app.MapPost("/usuarios/login", (UsuarioLoginRequestDTO usuarioLoginRequestDto, LoginService loginService, JwtTokenService tokenService) =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(usuarioLoginRequestDto.Email) || string.IsNullOrWhiteSpace(usuarioLoginRequestDto.Contrasenia))
                    {
                        return Results.BadRequest(new UsuarioLoginResultDTO { Exitoso = false, Mensaje = "Debe ingresar email y contraseña." });
                    }

                    UsuarioLoginResultDTO resultado = loginService.ValidarLogin(usuarioLoginRequestDto);

                    if (!resultado.Exitoso)
                    {
                        return Results.Json(resultado, statusCode: StatusCodes.Status401Unauthorized);
                    }

                    // Como el login fue exitoso, ya tenemos el Rol, Nombre y Apellido en 'resultado'.
                    // Creamos una entidad temporal (o adaptada) para que el JwtTokenService pueda generar los claims.
                    // Creamos la instancia asignando explícitamente el Id obtenido para que el JwtTokenService genere los Claims correctos.
                    // Nota: el JwtTokenService usa Email y Rol y se les pasa el email que vino en el request y el rol del resultado.
                    var usuarioLoginDto = new UsuarioLoginDTO
                    {
                        Id = resultado.Id.ToString(),
                        Nombre = resultado.Nombre,
                        Apellido = resultado.Apellido,
                        Email = usuarioLoginRequestDto.Email,
                        Rol = resultado.Rol
                    };

                    // Generamos el Token JWT usando el DTO
                    string token = tokenService.GenerarToken(usuarioLoginDto);

                    // Asignamos el token al resultado que se enviará al cliente
                    resultado.Token = token;

                    return Results.Ok(resultado);
                }
                catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    return Results.BadRequest(ex.Message);
                }
                catch (Exception)
                {
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