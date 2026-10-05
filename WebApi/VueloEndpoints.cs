using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WebApi
{
    public static class VueloEndpoints
    {
        public static void MapVueloEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("vuelos").RequireAuthorization(); // Protegidos con JWT

            // GET: Listar todos
            group.MapGet("/", async (VueloService vueloService) =>
            {
                var vuelos = await vueloService.GetAllAsync();
                return Results.Ok(vuelos);
            });

            // GET: Obtener por ID
            group.MapGet("/{id}", async (int id, VueloService vueloService) =>
            {
                var vuelo = await vueloService.GetByIdAsync(id);
                return vuelo is not null ? Results.Ok(vuelo) : Results.NotFound();
            });

            // POST: Crear
            group.MapPost("/", async (VueloCreateDTO dto, VueloService vueloService) =>
            {   
                try
                {
                    await vueloService.AddAsync(dto);
                    return Results.Ok();
                }
                catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    // Unificamos las validaciones de negocio que devuelven un 400 Bad Request
                    return Results.BadRequest(ex.Message);
                }
                catch (Exception)
                {
                    // Para cualquier otro error grave o inesperado del sistema (fallo de base de datos, etc.)
                    return Results.Problem("Ocurrió un error interno en el servidor.", statusCode: 500);
                }
            });

            // PUT: Actualizar
            group.MapPut("/{id}", async (int id, VueloUpdateDTO dto, VueloService vueloService) =>
            {
                try
                {
                    dto.Id = id; // Aseguramos que coincida
                    var resultado = await vueloService.UpdateAsync(id, dto);
                    return Results.Ok(resultado);
                }
                catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    // Unificamos las validaciones de negocio que devuelven un 400 Bad Request
                    return Results.BadRequest(ex.Message);
                }
                catch (Exception)
                {
                    // Para cualquier otro error grave o inesperado del sistema (fallo de base de datos, etc.)
                    return Results.Problem("Ocurrió un error interno en el servidor.", statusCode: 500);
                }
            });

            // DELETE: Eliminar
            group.MapDelete("/{id}", async (int id, VueloService vueloService) =>
            {
                await vueloService.DeleteAsync(id);
                return Results.NoContent();
            });

        }
    }
}

