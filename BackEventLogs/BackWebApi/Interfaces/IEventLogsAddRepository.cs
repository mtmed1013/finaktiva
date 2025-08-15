using BackWebApi.Entities;
namespace BackWebApi.Interfaces
{
    public interface IEventLogsAddRepository
    {
        Task<EventLog> AddEventLogAsync(EventLog eventLog);
    }

}