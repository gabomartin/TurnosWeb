using Microsoft.EntityFrameworkCore;
using TurnosWeb.Data;
using TurnosWeb.Data.Models;
using TurnosWeb.Services.Abstractions;

namespace TurnosWeb.Services.Services
{
    public sealed class ServiceDomainService : IServiceDomainService
    {
        private readonly TurnosWebContext _dbContext;
        public ServiceDomainService(TurnosWebContext context)
        {
            _dbContext = context;
        }
        public IEnumerable<Service> GetServices()
        {
            return _dbContext.Service;
        }

        public Task<Service?> GetServiceByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _dbContext.Service.FirstOrDefaultAsync(x => x.ServiceId == id, cancellationToken);
        }
    }
}
