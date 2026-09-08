using Application.Services;
using DTOs;

namespace WebApi
{
    public static class CiudadEndpoints
    {
        public static void MapCiudadEndpoints(this WebApplication app)
        {
            app.MapGet("/ciudades/{id}", async (int id, CiudadService ciudadService) =>
            {
                CiudadDTO? dto = await ciudadService.GetByIdAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetCiudad")
            .Produces<CiudadDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
            //.RequireAuthorization("CiudadsLeer");

            app.MapGet("/ciudades", async (CiudadService ciudadService) =>
            {

                var dtos = await ciudadService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllCiudads")
            .Produces<List<CiudadDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
            //.RequireAuthorization("CiudadsLeer");

            app.MapPost("/ciudades", async (CiudadCreateDTO dto, CiudadService ciudadService) =>
            {
                try
                {

                    CiudadDTO ciudadDTO = await ciudadService.AddAsync(dto);

                    return Results.Created($"/ciudades/{ciudadDTO.Id}", ciudadDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddCiudad")
            .Produces<CiudadDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();
            //.RequireAuthorization("CiudadsAgregar");

            app.MapPut("/ciudades", async (CiudadUpdateDTO dto, CiudadService ciudadService) =>
            {
                try
                {

                    var found = await ciudadService.UpdateAsync(dto.Id, dto);

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
            .WithName("UpdateCiudad")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();
            //.RequireAuthorization("CiudadsActualizar");

            app.MapDelete("/ciudades/{id}", async (int id, CiudadService ciudadService) =>
            {

                var deleted = await ciudadService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteCiudad")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
            //.RequireAuthorization("CiudadsEliminar");
        }
    }
}
