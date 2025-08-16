using BackWebApi.Entities;
using BackWebApi.Interfaces;
using BackWebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BackWebApi.Controllers
{
    /// <summary>
    /// Controlador para la gestión de eventos de logs
    /// </summary>
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

        /// <summary>
        /// Retorna todos los eventos sin filtrar
        /// </summary>
        /// <remarks>
        /// Este endpoint retorna todos los eventos disponibles en el sistema.
        /// </remarks>
        /// <returns>
        /// Una lista de todos los eventos disponibles.
        /// </returns>
        /// <response code="200">Retorna la lista de eventos.</response>
        /// <response code="204">Si no hay eventos disponibles.</response>
        /// <response code="500">Si ocurrió un error interno del servidor.</response>
        [HttpGet]
        public async Task<ActionResult<List<EventLogsDto>>> GetEventLogs()
        {
            var eventLogs = await _eventLogsGet.GetAllEventLogsAsync();
            return Ok(eventLogs);
        }

        /// <summary>
        /// Retorna todos los eventos filtrados por un rango de fechas
        /// </summary>
        /// <remarks>
        /// Este endpoint retorna todos los eventos disponibles por un rango de fechas.
        /// </remarks>
        /// <returns>
        /// Una lista de eventos filtrados por fecha.
        /// </returns>
        /// <response code="200">Retorna la lista de eventos.</response>
        /// <response code="204">Si no hay eventos disponibles.</response>
        /// <response code="500">Si ocurrió un error interno del servidor.</response>
        [HttpPost("dates")]
        public async Task<ActionResult<List<EventLogsDto>>> GetEventLogsByDatesAsync([FromBody] DateRangeDto dateRange)
        {
            var eventLogs = await _eventLogsGet.GetEventLogsByDatesAsync(dateRange);
            return Ok(eventLogs);
        }

        /// <summary>
        /// Retorna todos los eventos filtrados por un tipo
        /// </summary>
        /// <remarks>
        /// Este endpoint retorna todos los eventos disponibles por un tipo
        /// </remarks>
        /// <returns>
        /// Una lista de eventos filtrados por tipo.
        /// </returns>
        /// <response code="200">Retorna la lista de eventos.</response>
        /// <response code="204">Si no hay eventos disponibles.</response>
        /// <response code="500">Si ocurrió un error interno del servidor.</response>
        [HttpGet("types/{idTipo}")]
        public async Task<ActionResult<List<EventLogsDto>>> GetAllByIdTypeAsync([FromRoute] int idTipo)
        {
            var eventLogs = await _eventLogsGet.GetAllByIdTypeAsync(idTipo);
            return Ok(eventLogs);
        }

        /// <summary>
        /// Agrega un nuevo evento al sistema
        /// </summary>
        /// <remarks>
        /// Este endpoint permite agregar un nuevo evento al sistema.
        /// </remarks>
        /// <param name="dto"></param>
        /// <returns>
        /// El evento creado con su ID asignado.
        /// </returns>
        /// <response code="200">Evento creado exitosamente.</response>
        /// <response code="400">Si los datos del evento son inválidos.</response>
        /// <response code="500">Si ocurrió un error interno del servidor.</response>
        [HttpPost]
        public async Task<ActionResult<EventLogsDto>> AddEventLog([FromBody] EventLogsAddDto dto)
        {
            EventLog eventLog = new EventLog();
            eventLog.Descripcion = dto.Descripcion;
            var createdEventLog = await _eventLogsAdd.AddEventLogAsync(eventLog);
            return Ok(createdEventLog);
        }
    }
}
