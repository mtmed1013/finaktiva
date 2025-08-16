using BackWebApi.Entities;

namespace BackWebApi.Interfaces
{
    public interface IEventLogsTypeGetService
    {
        Task<List<EventLogType>> GetAllEventLogTypesAsync();
    }
}
