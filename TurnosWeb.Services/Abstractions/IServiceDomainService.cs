using TurnosWeb.Data.Models;

namespace TurnosWeb.Services.Abstractions
{
    public interface IServiceDomainService
    {
        Task<Service?> GetServiceByIdAsync(int id, CancellationToken cancellationToken);
        IEnumerable<Service> GetServices();
    }
}