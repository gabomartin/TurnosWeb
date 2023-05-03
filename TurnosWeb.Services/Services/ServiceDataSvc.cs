using Microsoft.EntityFrameworkCore;
using TurnosWeb.Data;
using TurnosWeb.Data.Models;
using TurnosWeb.Services.Interfaces;

namespace TurnosWeb.Services.Services
{
    public sealed class ServiceDataSvc : IServiceDataSvc
    {
        private readonly TurnosWebContext _dbContext;
        public ServiceDataSvc(TurnosWebContext context)
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
