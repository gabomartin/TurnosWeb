using Microsoft.EntityFrameworkCore;
using TurnosWeb.Data;
using TurnosWeb.Core.Dtos;
using TurnosWeb.Data.Models;
using TurnosWeb.Services.Abstractions;
using System.Threading;

namespace TurnosWeb.Services.Services
{
    public sealed class AppointmentDomainService : IAppointmentDomainService
    {
        private readonly TurnosWebContext _dbContext;
        public AppointmentDomainService(TurnosWebContext context)
        {
            _dbContext = context;
        }
        public Task<List<Appointment>> GetAppointments(CancellationToken cancellationToken)
        {
            return _dbContext.Appointment
                .Include(s => s.State)
                .Include(b => b.Barber)
                .Include(s => s.AppointmentServices)
                .ThenInclude(s => s.Service)
                .ToListAsync(cancellationToken);
        }

        public Task<List<AppointmentViewDto>> GetAppointmentsViewModel(CancellationToken cancellationToken)
        {
            return _dbContext.Appointment
                .Include(s => s.State)
                .Include(b => b.Barber)
                .Include(s => s.AppointmentServices)
                .ThenInclude(s => s.Service)
                .Select(e => new AppointmentViewDto
                {
                    AppointmentId = e.AppointmentId,
                    ClientName = e.ClientName,
                    State = e.State.Description,
                    BarberName = e.Barber.BarberName,
                    AppointmentDate = e.AppointmentDate,
                    TotalCharged = e.TotalCharged,
                    Services = e.AppointmentServices.Select(s => new ServiceViewModel
                    {
                        Id = s.ServiceId,
                        Description = s.Service.Description
                    })

                }).ToListAsync(cancellationToken);
        }

        public async Task<int> CreateAppointmentAsync(AppointmentDto appointment, CancellationToken cancellationToken)
        {
            var entity = new Appointment();
            entity.CreationDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.StateId = appointment.StateId ?? entity.StateId;
            entity.BarberId = appointment.BarberId ?? entity.BarberId;
            entity.AppointmentDate = appointment.AppointmentDate ?? entity.AppointmentDate;
            entity.ClientName = appointment.ClientName ?? entity.ClientName;
            await _dbContext.Appointment.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.AppointmentId;
        }

        public Task<Appointment?> GetAppointmentByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _dbContext.Appointment.FirstOrDefaultAsync(x => x.AppointmentId == id, cancellationToken);
        }

        public async Task<int> UpdateAppointmentAsync(AppointmentDto appointment, int id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Appointment.FirstOrDefaultAsync(x => x.AppointmentId == id, cancellationToken);

            entity.StateId = appointment.StateId ?? entity.StateId;
            entity.BarberId = appointment.BarberId ?? entity.BarberId;
            entity.AppointmentDate = appointment.AppointmentDate ?? entity.AppointmentDate;
            entity.ClientName = appointment.ClientName ?? entity.ClientName;

            _dbContext.Appointment.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.AppointmentId;
        }
    }
}
