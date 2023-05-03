using TurnosWeb.Data.Models;

namespace TurnosWeb.Services.Interfaces
{
    public interface IBarberDataSvc
    {
        IEnumerable<Barber> GetBarbers();
    }
}