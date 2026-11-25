using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WebApi
{
    public static class AvionEndpoints
    {
        public static void MapAvionEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("aviones");

            // GET: /aviones (Obtener todos)
            group.MapGet("/", async (AvionService avionService) =>
            {
                var dtos = await avionService.GetAllAsync();
                return Results.Ok(dtos);
            })
            .WithName("GetAllAviones")
            .Produces<List<AvionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization(new AuthorizeAttribute { Roles = "admin" });
            

            // GET: /aviones/{id} (Obtener por ID)
            group.MapGet("/{id:int}", async (int id, AvionService avionService) =>
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
            group.MapPost("/", async (AvionCreateDTO dto, AvionService avionService) =>
            {
                try
                {
                    AvionDTO avionDTO = await avionService.AddAsync(dto);
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
            .RequireAuthorization(new AuthorizeAttribute { Roles = "admin" });

            // PUT: /aviones/{id} (Actualizar)
            group.MapPut("/{id:int}", async (int id, AvionUpdateDTO dto, AvionService avionService) =>
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
            .RequireAuthorization(new AuthorizeAttribute { Roles = "admin" });

            // DELETE: /aviones/{id} (Eliminar)
            group.MapDelete("/{id:int}", async (int id, AvionService avionService) =>
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
            .RequireAuthorization(new AuthorizeAttribute { Roles = "admin" });

        }
    }
}