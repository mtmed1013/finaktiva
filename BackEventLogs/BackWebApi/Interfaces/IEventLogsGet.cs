using BackWebApi.Entities;
namespace BackWebApi.Interfaces
{
    public interface IEventLogsGet
    {
        Task<List<EventLog>> GetEventLogs();
    }
}
