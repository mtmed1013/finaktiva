using BackWebApi.Entities;

namespace BackWebApi.Interfaces
{
    public interface IEventLogsServiceGet
    {
        Task<List<EventLog>> GetAllEventLogsAsync();
    }
}