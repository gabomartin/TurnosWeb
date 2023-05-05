using TurnosWeb.Data;
using TurnosWeb.Data.Models;
using TurnosWeb.Services.Abstractions;

namespace TurnosWeb.Services.Services
{
    public sealed class BarberDomainService : IBarberDomainService
    {
        private readonly TurnosWebContext _dbContext;
        public BarberDomainService(TurnosWebContext context)
        {
            _dbContext = context;
        }
        public IEnumerable<Barber> GetBarbers()
        {
            return _dbContext.Barber;
        }
    }
}
