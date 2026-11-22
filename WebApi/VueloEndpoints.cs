using Application.Services;
using DTOs;

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
            group.MapGet("/{id:int}", async (int id, VueloService vueloService) =>
            {
                var vuelo = await vueloService.GetByIdAsync(id);
                return vuelo is not null ? Results.Ok(vuelo) : Results.NotFound();
            });

            // GET: Asientos ocupados de un vuelo puntual
            group.MapGet("/{id:int}/asientos-ocupados", async (int id, ReservaService reservaService) =>
            {
                try
                {
                    var ocupados = await reservaService.GetAsientosOcupadosPorVueloAsync(id);
                    return Results.Ok(ocupados);
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
            })
            .WithName("GetAsientosOcupadosPorVuelo")
            .Produces<List<string>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

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
                    return Results.BadRequest(ex.Message);
                }
                catch (Exception)
                {
                    return Results.Problem("Ocurrió un error interno en el servidor.", statusCode: 500);
                }
            });

            // PUT: Actualizar
            group.MapPut("/{id:int}", async (int id, VueloUpdateDTO dto, VueloService vueloService) =>
            {
                try
                {
                    dto.Id = id;
                    var resultado = await vueloService.UpdateAsync(id, dto);
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
            });

            // DELETE: Eliminar
            group.MapDelete("/{id:int}", async (int id, VueloService vueloService) =>
            {
                await vueloService.DeleteAsync(id);
                return Results.NoContent();
            });
<<<<<<< Updated upstream
=======


            group.MapGet("/{vueloId}/reservas/pasajes", async (int vueloId, VueloService vueloService) =>
            {

                var dtos = await vueloService.GetAllPasajesByVueloAsync(vueloId);

                return Results.Ok(dtos);
            })
            .WithName("GetPasajesXVuelo")
            .Produces<List<PasajeDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization();
>>>>>>> Stashed changes
        }
   
    }
}

