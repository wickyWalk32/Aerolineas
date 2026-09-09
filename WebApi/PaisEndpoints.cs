using Application.Services;
using DTOs;

namespace WebApi
{
    public static class PaisEndpoints
    {
        public static void MapPaisEndpoints(this WebApplication app)
        {
            app.MapGet("/paises", async (PaisService paisService) =>
            {

                var dtos = await paisService.GetAllAsync();
                Console.WriteLine($"TYPE: {dtos.GetType()}");
                return Results.Ok(dtos);
            })
            .WithName("GetAllPaises")
            .Produces<List<PaisDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/paises", async (PaisCreateDTO dto, PaisService paisService) =>
            {
                try
                {

                    PaisDTO paisDTO = await paisService.AddAsync(dto);

                    return Results.Created($"/paises/{paisDTO.Id}", paisDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPais")
            .Produces<PaisDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            app.MapDelete("/paises/{id}", async (int id, PaisService paisService) =>
            {

                var deleted = await paisService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeletePais")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
