using BackWebApi.Data;
using BackWebApi.Entities;
using BackWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackWebApi.Repositories;

public class EventLogsTypeRepository : IEventLogsTypeGetRepository
{
    private readonly AppDbContext _context;

    public EventLogsTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EventLogType>> GetAllEventLogTypesAsync()
    {
        return await _context.EventLogType.ToListAsync();
    }
}