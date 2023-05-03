using Microsoft.EntityFrameworkCore;
using TurnosWeb.Data;
using TurnosWeb.Data.Dtos;
using TurnosWeb.Data.Models;
using TurnosWeb.Services.Interfaces;

namespace TurnosWeb.Services.Services
{
    public sealed class AppointmentDataSvc : IAppointmentDataSvc
    {
        private readonly TurnosWebContext _dbContext;
        public AppointmentDataSvc(TurnosWebContext context)
        {
            _dbContext = context;
        }
        public IEnumerable<Appointment> GetAppointments()
        {
            return _dbContext.Appointment;
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
