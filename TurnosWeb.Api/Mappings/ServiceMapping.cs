using TurnosWeb.Core.Dtos;
using TurnosWeb.Services.Abstractions;

namespace TurnosWeb.Api.Mappings
{
    public static class ServiceMapping
    {
        public static void MapServiceEndpoints(this WebApplication app)
        {
            app.MapGet("/Service", (IServiceDomainService contextService) =>
            {
                return contextService.GetServices();
            })
            .WithName("GetServices")
            .WithOpenApi();

            app.MapGet("/Service/{id}", async (IServiceDomainService contextService, int id, CancellationToken cancellationToken) =>
            {
                return await contextService.GetServiceByIdAsync(id, cancellationToken);
            })
            .WithName("GetServiceById")
            .WithOpenApi();
        }
    }
}
