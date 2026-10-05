using Application.Services;
using DTOs;

namespace WebApi
{
    public static class AvionEndpoints
    {
        public static void MapAvionEndpoints(this WebApplication app)
        {
            // GET: /aviones (Obtener todos)
            app.MapGet("/aviones", async (AvionService avionService) =>
            {
                var dtos = await avionService.GetAllAsync();
                return Results.Ok(dtos);
            })
            .WithName("GetAllAviones")
            .Produces<List<AvionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization();

            // GET: /aviones/{id} (Obtener por ID)
            app.MapGet("/aviones/{id:int}", async (int id, AvionService avionService) =>
            {
                var dto = await avionService.GetByIdAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetAvionById")
            .Produces<AvionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization();

            // POST: /aviones (Crear)
            app.MapPost("/aviones", async (AvionCreateDTO dto, AvionService avionService) =>
            {
                try
                {
                    AvionDTO avionDTO = await avionService.AddAsync(dto);
                    // Usa avionDTO.Id coincidiendo con tu propiedad de dominio
                    return Results.Created($"/aviones/{avionDTO.Id}", avionDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddAvion")
            .Produces<AvionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization();

            // PUT: /aviones/{id} (Actualizar)
            app.MapPut("/aviones/{id:int}", async (int id, AvionUpdateDTO dto, AvionService avionService) =>
            {
                try
                {
                    var updated = await avionService.UpdateAsync(id, dto);

                    if (!updated)
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
            .WithName("UpdateAvion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization();

            // DELETE: /aviones/{id} (Eliminar)
            app.MapDelete("/aviones/{id:int}", async (int id, AvionService avionService) =>
            {
                var deleted = await avionService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteAvion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization();
        }
    }
}