using Microsoft.EntityFrameworkCore;
using TurnosWeb.Data;
using TurnosWeb.Core.Dtos;
using TurnosWeb.Data.Models;
using TurnosWeb.Services.Abstractions;

namespace TurnosWeb.Services.Services
{
    public sealed class AppointmentServiceDomainService : IAppointmentServiceDomainService
    {
        private readonly TurnosWebContext _dbContext;
        public AppointmentServiceDomainService(TurnosWebContext context)
        {
            _dbContext = context;
        }
        public IEnumerable<AppointmentService> GetAppointmentServicesByAppointmentId(int id)
        {
            return _dbContext.AppointmentService.Where(x => x.AppointmentId == id).AsEnumerable();
        }



        public async Task<IEnumerable<int>> CreateAppointmentServiceAsync(AppointmentServiceDto appointmentService, int appointmentId, CancellationToken cancellationToken)
        {

            var appointmentServiceIds = new List<int>();

            foreach (var serviceId in appointmentService.ServiceId)
            {
                var entity = new AppointmentService();
                var service = _dbContext.Service.First(x => x.ServiceId == serviceId);
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
