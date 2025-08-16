using BackWebApi.Entities;
using BackWebApi.Interfaces;

namespace BackWebApi.Services
{
    public class EventLogsTypeService : IEventLogsTypeGetService
    {
        private readonly IEventLogsTypeGetRepository _repository;

        public EventLogsTypeService(IEventLogsTypeGetRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<EventLogType>> GetAllEventLogTypesAsync()
        {
            return await _repository.GetAllEventLogTypesAsync();
        }
    }
}