using BackWebApi.Entities;

namespace BackWebApi.Interfaces
{
    public interface IEventLogsServiceAdd
    {
        Task<EventLog> AddEventLogAsync(EventLog eventLog);
    }
}