using TurnosWeb.Data.Dtos;
using TurnosWeb.Data.Models;

namespace TurnosWeb.Services.Interfaces;

public interface IContextService
{
    IEnumerable<Service> GetServices();
    IEnumerable<Barber> GetBarbers();
    IEnumerable<Appointment> GetAppointments();
    IEnumerable<AppointmentService> GetAppointmentServicesByAppointmentId(int id);
    Task<int> CreateAppointmentAsync(AppointmentDto appointment, CancellationToken cancellationToken);
    Task<IEnumerable<int>> DeleteAppointmentServicesByAppointmentIdAsync(int appointmentId, CancellationToken cancellationToken);
    Task<int> DeleteAppointmentServiceByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<int>> CreateAppointmentServiceAsync(AppointmentServiceDto appointmentService, int appointmentId, CancellationToken cancellationToken);
    Task<int> UpdateAppointmentAsync(AppointmentDto appointment, int id, CancellationToken cancellationToken);
    Task<Service?> GetServiceByIdAsync(int id, CancellationToken cancellationToken);
    Task<Appointment?> GetAppointmentByIdAsync(int id, CancellationToken cancellationToken);
}
