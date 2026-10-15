using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WebApi
{
    public static class ServicioEndpoints
    {
        public static void MapServicioEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("servicios").RequireAuthorization(); // Protegidos con JWT

            // GET: Listar todos
            group.MapGet("/", async (ServicioService servicioService) =>
            {
                var servicios = await servicioService.GetAllAsync();
                return Results.Ok(servicios);
            });

            // GET by id: traer uno
            group.MapGet("/{id}", async (int id, ServicioService servicioService) =>
            {
                var servicioDto = await servicioService.GetByIdAsync(id);
                return servicioDto is not null ? Results.Ok(servicioDto) : Results.NotFound();
            });

            // POST: Crear
            group.MapPost("/", async (ServicioCreateDTO dto, ServicioService servicioService) =>
            {
                /*var resultado =*/ await servicioService.AddAsync(dto);
                return Results.Ok(/*resultado*/);
            });

            // PUT: Actualizar
            group.MapPut("/{id}", async (int id, ServicioUpdateDTO dto, ServicioService servicioService) =>
            {
                dto.Id = id; // Aseguramos que coincida
                var resultado = await servicioService.UpdateAsync(id, dto);
                return Results.Ok(resultado);
            });

            // DELETE: Eliminar
            group.MapDelete("/{id}", async (int id, ServicioService servicioService) =>
            {
                await servicioService.DeleteAsync(id);
                return Results.NoContent();
            });

        }
    }
}