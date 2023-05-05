using TurnosWeb.Data.Models;

namespace TurnosWeb.Services.Abstractions
{
    public interface IBarberDomainService
    {
        IEnumerable<Barber> GetBarbers();
    }
}