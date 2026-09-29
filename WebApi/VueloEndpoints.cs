using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WebApi
{
    public static class VueloEndpoints
    {
        public static void MapVueloEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("vuelos");//.RequireAuthorization(); // Protegidos con JWT

            // GET: Listar todos
            group.MapGet("/", async (VueloService vueloService) =>
            {
                var vuelos = await vueloService.GetAllAsync();
                return Results.Ok(vuelos);
            });

            // GET: Obtener por ID
            group.MapGet("/{id}", async (int id, VueloService vueloService) =>
            {
                var vuelo = await vueloService.GetByIdAsync(id);
                return vuelo is not null ? Results.Ok(vuelo) : Results.NotFound();
            });

            // POST: Crear
            group.MapPost("/", async (VueloCreateDTO dto, VueloService vueloService) =>
            {
                /*var resultado =*/ await vueloService.AddAsync(dto);
                return Results.Ok(/*resultado*/);
            });

            // PUT: Actualizar
            group.MapPut("/{id}", async (int id, VueloUpdateDTO dto, VueloService vueloService) =>
            {
                dto.Id = id; // Aseguramos que coincida
                var resultado = await vueloService.UpdateAsync(id, dto);
                return Results.Ok(resultado);
            });

            // DELETE: Eliminar
            group.MapDelete("/{id}", async (int id, VueloService vueloService) =>
            {
                await vueloService.DeleteAsync(id);
                return Results.NoContent();
            });

        }
    }
}

