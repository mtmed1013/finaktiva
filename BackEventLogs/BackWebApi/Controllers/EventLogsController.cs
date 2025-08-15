using BackWebApi.Entities;
using BackWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventLogsController : ControllerBase
    {
        private readonly IEventLogsServiceGet _eventLogsGet;
        private readonly IEventLogsServiceAdd _eventLogsAdd;

        public EventLogsController(IEventLogsServiceGet eventLogsGet, IEventLogsServiceAdd eventLogsAdd)
        {
            _eventLogsGet = eventLogsGet;
            _eventLogsAdd = eventLogsAdd;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventLog>>> GetEventLogs()
        {
            var eventLogs = await _eventLogsGet.GetAllEventLogsAsync();
            return Ok(eventLogs);
        }

        [HttpPost]
        public async Task<ActionResult<EventLog>> AddEventLog(EventLog eventLog)
        {
            var createdEventLog = await _eventLogsAdd.AddEventLogAsync(eventLog);
            return Ok(createdEventLog);
        }
    }
}
