using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using TurnosWeb.Data;
using TurnosWeb.Data.Dtos;
using TurnosWeb.Data.Models;
using TurnosWeb.Services.Interfaces;

namespace TurnosWeb.Services.Services
{
    public sealed class TurnosWebContextService : IContextService
    {
        private readonly TurnosWebContext _dbContext;
        public TurnosWebContextService(TurnosWebContext context)
        {
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

        public Task<Service?> GetServiceByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _dbContext.Service.FirstOrDefaultAsync(x => x.ServiceId == id, cancellationToken);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _dbContext.Appointment;
        }

        public Task<Appointment?> GetAppointmentByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _dbContext.Appointment.FirstOrDefaultAsync(x => x.AppointmentId == id, cancellationToken);
        }

        public IEnumerable<AppointmentService> GetAppointmentServicesByAppointmentId(int id)
        {
            return _dbContext.AppointmentService.Where(x => x.AppointmentId == id).AsEnumerable();
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

        public async Task<IEnumerable<int>> CreateAppointmentServiceAsync(AppointmentServiceDto appointmentService, int appointmentId, CancellationToken cancellationToken)
        {

            var appointmentServiceIds = new List<int>();

            foreach (var serviceId in appointmentService.ServiceId)
            {
                var entity = new AppointmentService();
                var service = await GetServiceByIdAsync(serviceId, cancellationToken);
                entity.AppointmentId = appointmentId;
                entity.ServiceId = service.ServiceId;
                entity.AmountCharged = service.Cost;
                await _dbContext.AppointmentService.AddAsync(entity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                appointmentServiceIds.Add(entity.AppointmentServiceId);
            }

            return appointmentServiceIds;
        }

        public async Task<IEnumerable<int>> DeleteAppointmentServicesByAppointmentIdAsync(int appointmentId, CancellationToken cancellationToken)
        {
            var entities = _dbContext.AppointmentService.Where(x => x.AppointmentId == appointmentId);
            var idList = entities.Select(x => x.AppointmentServiceId).ToList();
            _dbContext.AppointmentService.RemoveRange(entities);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return idList;

        }
        public async Task<int> DeleteAppointmentServiceByIdAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.AppointmentService.FirstAsync(x => x.AppointmentServiceId == id, cancellationToken);
            _dbContext.AppointmentService.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.AppointmentServiceId;
        }
    }
}
