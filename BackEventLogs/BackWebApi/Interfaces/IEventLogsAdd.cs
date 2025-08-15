using BackWebApi.Entities;
namespace BackWebApi.Interfaces
{
    public interface IEventLogsAdd
    {
        Task AddEventLog(EventLog eventLog);
    }

}