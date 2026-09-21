using Application.Services;
using Domain.Model; // O el using donde tengas tu entidad Servicio
using DTOs;            // O donde tengas tus DTOs de servicio
using Microsoft.AspNetCore.Authorization;

namespace WebApi // O el namespace que uses para tus endpoints
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