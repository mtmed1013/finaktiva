using BackWebApi.Entities;
namespace BackWebApi.Interfaces
{
    public interface IEventLogsGetRepository
    {
        Task<List<EventLog>> GetEventLogsAsync();
    }
}
