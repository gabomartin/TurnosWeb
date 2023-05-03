using TurnosWeb.Data.Models;

namespace TurnosWeb.Services.Interfaces
{
    public interface IServiceDataSvc
    {
        Task<Service?> GetServiceByIdAsync(int id, CancellationToken cancellationToken);
        IEnumerable<Service> GetServices();
    }
}