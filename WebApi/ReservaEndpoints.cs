using Application.Services;
using DTOs;

namespace WebApi
{
    public static class ReservaEndpoints
    {
        public static void MapReservaEndpoints(this WebApplication app)
        {
            app.MapGet("/reservas", async (ReservaService reservaService) =>
            {

                var dtos = await reservaService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllReservas")
            .Produces<List<ReservaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/reservas", async (ReservaCreateDTO dto, ReservaService reservaService) =>
            {
                try
                {

                    ReservaDTO reservaDTO = await reservaService.AddAsync(dto);

                    return Results.Created($"/usuarios/{reservaDTO.Id}", reservaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddReserva")
            .Produces<UsuarioDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();
        }
    }
}
