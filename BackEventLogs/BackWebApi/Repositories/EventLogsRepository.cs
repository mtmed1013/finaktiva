using BackWebApi.Data;
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

        public async Task<List<EventLog>> GetEventLogsAsync()
        {
            return await _context.EventLogs.ToListAsync();
        }
    }
}
