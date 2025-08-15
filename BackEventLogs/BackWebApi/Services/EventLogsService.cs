using BackWebApi.Entities;
using BackWebApi.Interfaces;

namespace BackWebApi.Services
{
    public class EventLogsService : IEventLogsServiceAdd, IEventLogsServiceGet
    {
        private readonly IEventLogsAddRepository _eventAdd;
        private readonly IEventLogsGetRepository _eventGet;
        public EventLogsService(IEventLogsAddRepository eventAdd, IEventLogsGetRepository eventGet)
        {
            _eventAdd = eventAdd;
            _eventGet = eventGet;
        }

        public async Task<EventLog> AddEventLogAsync(EventLog eventLog)
        {
            EventLogsValidator.ValidateFields(eventLog);
            return await _eventAdd.AddEventLogAsync(eventLog);
        }

        public async Task<List<EventLog>> GetAllEventLogsAsync()
        {
            return await _eventGet.GetEventLogsAsync();
        }
    }
}