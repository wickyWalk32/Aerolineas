using Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace WebApi
{
    public static class ReporteEndpoints
    {
        public static void MapReporteEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("reportes")/*.RequireAuthorization();*/
            .RequireAuthorization(new AuthorizeAttribute { Roles = "admin" });

            group.MapGet("/estadisticas", async (ReporteService reporteService) =>
            {
                var datos = await reporteService.ObtenerEstadisticasAsync();
                return Results.Ok(datos);
            });
        }
    }
}