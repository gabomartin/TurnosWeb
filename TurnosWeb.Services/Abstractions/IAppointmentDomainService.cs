using TurnosWeb.Core.Dtos;
using TurnosWeb.Data.Models;

namespace TurnosWeb.Services.Abstractions
{
    public interface IAppointmentDomainService
    {
        Task<int> CreateAppointmentAsync(AppointmentDto appointment, CancellationToken cancellationToken);
        Task<Appointment?> GetAppointmentByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Appointment>> GetAppointments(CancellationToken cancellationToken);
        Task<List<AppointmentViewDto>> GetAppointmentsViewModel(CancellationToken cancellationToken);
        Task<int> UpdateAppointmentAsync(AppointmentDto appointment, int id, CancellationToken cancellationToken);
    }
}