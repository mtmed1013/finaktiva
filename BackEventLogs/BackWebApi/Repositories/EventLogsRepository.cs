using BackWebApi.Data;
using BackWebApi.Dtos;
using BackWebApi.Entities;
using BackWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BackWebApi.Repositories
{
    public class EventLogsRepository : IEventLogsGetRepository, IEventLogsAddRepository
    {
        private readonly AppDbContext _context;

        public EventLogsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EventLog> AddEventLogAsync(EventLog eventLog)
        {
            _context.EventLogs.Add(eventLog);
            await _context.SaveChangesAsync();
            return eventLog;
        }

        public async Task<List<EventLogsDto>> GetEventLogsAsync()
        {
            return await _context.EventLogs
            .Select(q => new EventLogsDto
            {
                Id = q.Id,
                Tipo = q.Tipo.Nombre,
                Descripcion = q.Descripcion,
                FechaRegistra = q.FechaRegistra
            })
            .ToListAsync();
        }

        public async Task<List<EventLogsDto>> GetEventLogsByDatesAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.EventLogs
            .Where(x => x.FechaRegistra >= fechaInicio && x.FechaRegistra <= fechaFin)
            .Select(q => new EventLogsDto
            {
                Id = q.Id,
                Tipo = q.Tipo.Nombre,
                Descripcion = q.Descripcion,
                FechaRegistra = q.FechaRegistra
            })
            .ToListAsync();
        }

        public async Task<List<EventLogsDto>> GetAllByIdTypeAsync(int idTipo)
        {
            return await _context.EventLogs
                .Where(x => x.IdTipo == idTipo)
                .Select(q => new EventLogsDto
                {
                    Id = q.Id,
                    Tipo = q.Tipo.Nombre,
                    Descripcion = q.Descripcion,
                    FechaRegistra = q.FechaRegistra
                })
                .ToListAsync();
        }
    }
}
