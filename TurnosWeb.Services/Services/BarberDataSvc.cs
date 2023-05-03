using TurnosWeb.Data;
using TurnosWeb.Data.Models;
using TurnosWeb.Services.Interfaces;

namespace TurnosWeb.Services.Services
{
    public sealed class BarberDataSvc : IBarberDataSvc
    {
        private readonly TurnosWebContext _dbContext;
        public BarberDataSvc(TurnosWebContext context)
        {
            _dbContext = context;
        }
        public IEnumerable<Barber> GetBarbers()
        {
            return _dbContext.Barber;
        }
    }
}
