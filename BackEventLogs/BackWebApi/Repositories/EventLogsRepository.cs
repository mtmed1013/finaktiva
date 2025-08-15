using BackWebApi.Data;
using BackWebApi.Entities;
using BackWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BackWebApi.Repositories
{
    public class EventLogsRepository : IEventLogsGet, IEventLogsAdd
    {
        private readonly AppDbContext _context;

        public EventLogsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddEventLog(EventLog eventLog)
        {
            _context.EventLogs.Add(eventLog);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EventLog>> GetEventLogs()
        {
            return await _context.EventLogs.ToListAsync();
        }
    }
}
