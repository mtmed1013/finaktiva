using BackWebApi.Entities;

namespace BackWebApi.Interfaces
{
    public interface IEventLogsTypeGetRepository
    {
        Task<List<EventLogType>> GetAllEventLogTypesAsync();
    }
}
