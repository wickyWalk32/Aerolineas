using Application.Services;
using DTOs;
using Microsoft.Data.SqlClient;

namespace WebApi
{
    public static class PaisEndpoints
    {
        public static void MapPaisEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("paises").RequireAuthorization();

            group.MapGet("/", async (PaisService paisService) =>
            {
                var paises = await paisService.GetAllAsync();
                return Results.Ok(paises);
            });

            group.MapGet("/{id}", async (int id, PaisService paisService) =>
            {
                var paisDto = await paisService.GetByIdAsync(id);
                return paisDto is not null ? Results.Ok(paisDto) : Results.NotFound();
            });

            group.MapPost("/", async (PaisCreateDTO dto, PaisService paisService) =>
            {
                try
                {
                    await paisService.AddAsync(dto);
                    return Results.Ok();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            group.MapPut("/{id}", async (int id, PaisUpdateDTO dto, PaisService paisService) =>
            {
                try
                {
                    dto.Id = id;
                    var actualizado = await paisService.UpdateAsync(id, dto);
                    return actualizado ? Results.Ok(true) : Results.NotFound();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });

            group.MapDelete("/{id}", async (int id, PaisService paisService) =>
            {
                try
                {
                    var eliminado = await paisService.DeleteAsync(id);
                    return eliminado ? Results.NoContent() : Results.NotFound();
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    // Error 547 en SQL Server: violación de clave foránea (el país tiene ciudades asociadas)
                    return Results.BadRequest(new { error = "No se puede eliminar el país porque tiene ciudades asociadas." });
                }
            });
        }
    }
}
