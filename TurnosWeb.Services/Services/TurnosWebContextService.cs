using Microsoft.EntityFrameworkCore;
using TurnosWeb.Data;
using TurnosWeb.Data.Dtos;
using TurnosWeb.Data.Models;
using TurnosWeb.Services.Interfaces;

namespace TurnosWeb.Services.Services
{
    public sealed class TurnosWebContextService : IContextService
    {
        private readonly TurnosWebContext _dbContext;
        public TurnosWebContextService(TurnosWebContext context) {
            _dbContext = context;
        }

        public IEnumerable<Service> GetServices()
        {
            return _dbContext.Service;
        }

        public IEnumerable<Barber> GetBarbers()
        {
            return _dbContext.Barber;
        }

        public async Task<int> CreateAppointment(AppointmentDto appointment)
        {
            var entity = new Appointment();
            entity.CreationDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.StateId = appointment.StateId ?? entity.StateId;
            entity.BarberId = appointment.BarberId ?? entity.BarberId;
            entity.AppointmentDate = appointment.AppointmentDate ?? entity.AppointmentDate;
            entity.ClientName = appointment.ClientName ?? entity.ClientName;
            await _dbContext.Appointment.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.AppointmentId;
        }

        public Task<Service?> GetServiceById(int id, CancellationToken cancellationToken)
        {
            return _dbContext.Service.FirstOrDefaultAsync(x => x.ServiceId == id, cancellationToken);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _dbContext.Appointment;
        }

        public Task<Appointment?> GetAppointmentById(int id, CancellationToken cancellationToken)
        {
            return _dbContext.Appointment.FirstOrDefaultAsync(x => x.AppointmentId == id, cancellationToken);
        }

        public async Task<int> UpdateAppointment(AppointmentDto appointment, int id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Appointment.FirstOrDefaultAsync(x => x.AppointmentId == id, cancellationToken);

            entity.StateId = appointment.StateId ?? entity.StateId;
            entity.BarberId = appointment.BarberId ?? entity.BarberId;
            entity.AppointmentDate = appointment.AppointmentDate ?? entity.AppointmentDate;
            entity.ClientName = appointment.ClientName ?? entity.ClientName;

            _dbContext.Appointment.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity.AppointmentId;
        }
    }
}
