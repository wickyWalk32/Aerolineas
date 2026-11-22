using Application.Services;
using Domain.Model;
using DTOs;

namespace WebApi
{
    public static class ReservaEndpoints
    {
        public static void MapReservaEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/reservas").RequireAuthorization();

            // GET: Consultar todas
            group.MapGet("/", async (ReservaService reservaService) =>
            {
                var dtos = await reservaService.GetAllAsync();
                return Results.Ok(dtos);
            })
            .WithName("GetAllReservas")
            .Produces<List<ReservaDTO>>(StatusCodes.Status200OK)
<<<<<<< Updated upstream
            .WithOpenApi();
=======
            .WithOpenApi()
            .RequireAuthorization();
           
>>>>>>> Stashed changes

            // GET: Consultar por clave primaria (id)
            group.MapGet("/{id:int}", async (int id, ReservaService reservaService) =>
            {
                var dto = await reservaService.GetByIdAsync(id);
                return dto is not null ? Results.Ok(dto) : Results.NotFound();
            })
            .WithName("GetReservaById")
            .Produces<ReservaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // POST: Crear reserva
            group.MapPost("/", async (ReservaCreateDTO dto, ReservaService reservaService) =>
            {
                try
                {
                    ReservaDTO reservaDTO = await reservaService.AddAsync(dto);
                    return Results.Created($"/reservas/{reservaDTO.Id}", reservaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddReserva")
            .Produces<ReservaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            // PUT: Actualizar reserva por id
            group.MapPut("/{id:int}", async (int id, ReservaUpdateDTO dto, ReservaService reservaService) =>
            {
                try
                {
                    dto.Id = id;
                    var actualizada = await reservaService.UpdateAsync(id, dto);
                    return actualizada ? Results.NoContent() : Results.NotFound();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateReserva")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // DELETE: Eliminar reserva por id
            group.MapDelete("/{id:int}", async (int id, ReservaService reservaService) =>
            {
                var eliminada = await reservaService.DeleteAsync(id);
                return eliminada ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteReserva")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}