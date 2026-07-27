using Application.Services;
using DTOs;
namespace WebApi
{
    public static class PasajeroEndpoints
    {
        public static void MapPasajeroEndpoints(this WebApplication app)
        {

            app.MapGet("pasajeros/", async ( PasajeroService pasajeroService) =>
            {
                var dtos = await pasajeroService.GetAllAsync();
                if (dtos == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dtos);
            }).WithName("GetAllPasajeros")
            .Produces<List<PasajeroDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/pasajeros/{id}", async (int id, PasajeroService pasajeroService) =>
            {
                PasajeroDTO? dto = await pasajeroService.GetByIdAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetPasajero")
            .Produces<UsuarioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();


            app.MapPost("/pasajeros", async (PasajeroCreateDTO dto, PasajeroService pasajeroService) =>
            {
                try
                {

                    PasajeroDTO pasajeroDTO = await pasajeroService.AddAsync(dto);

                    return Results.Created($"/pasajeros/{pasajeroDTO.Id}", pasajeroDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPasajero")
            .Produces<UsuarioDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/pasajeros", async (PasajeroUpdateDTO dto, PasajeroService pasajeroService) =>
            {
                try
                {

                    var found = await pasajeroService.UpdateAsync(dto.Id, dto);

                    if (!found)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdatePasajero")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            app.MapDelete("/pasajeros/{id}", async (int id, PasajeroService pasajeroService) =>
            {

                var deleted = await pasajeroService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeletePasajero")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        }
    
    }
}
