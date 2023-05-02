using TurnosWeb.Data.Dtos;
using TurnosWeb.Data.Models;

namespace TurnosWeb.Services.Interfaces;

public interface IContextService
{
    IEnumerable<Service> GetServices();
    IEnumerable<Barber> GetBarbers();
    IEnumerable<Appointment> GetAppointments();
    Task<int> CreateAppointment(AppointmentDto appointment);
    Task<int> UpdateAppointment(AppointmentDto appointment, int id, CancellationToken cancellationToken);
    Task<Service?> GetServiceById(int id, CancellationToken cancellationToken);
    Task<Appointment?> GetAppointmentById(int id, CancellationToken cancellationToken);
}
