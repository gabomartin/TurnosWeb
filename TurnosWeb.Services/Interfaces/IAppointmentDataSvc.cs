using TurnosWeb.Data.Dtos;
using TurnosWeb.Data.Models;

namespace TurnosWeb.Services.Interfaces
{
    public interface IAppointmentDataSvc
    {
        Task<int> CreateAppointmentAsync(AppointmentDto appointment, CancellationToken cancellationToken);
        Task<Appointment?> GetAppointmentByIdAsync(int id, CancellationToken cancellationToken);
        IEnumerable<Appointment> GetAppointments();
        Task<int> UpdateAppointmentAsync(AppointmentDto appointment, int id, CancellationToken cancellationToken);
    }
}