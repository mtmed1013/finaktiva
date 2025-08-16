
using BackWebApi.Entities;
using BackWebApi.Interfaces;
using BackWebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BackWebApi.Controllers
{
    /// <summary>
    /// Controlador para la gestión de tipos de eventos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventLogsTypeController : ControllerBase
    {
        private readonly IEventLogsTypeGetService _eventLogsTypeGet;

        public EventLogsTypeController(IEventLogsTypeGetService eventLogsTypeGet)
        {
            _eventLogsTypeGet = eventLogsTypeGet;
        }

        /// <summary>
        /// Retorna todos los tipos de eventos sin filtrar
        /// </summary>
        /// <remarks>
        /// Este endpoint retorna todos los tipos de eventos disponibles en el sistema.
        /// </remarks>
        /// <returns>
        /// Una lista de tipos de eventos disponibles.
        /// </returns>
        /// <response code="200">Retorna la lista de tipos de eventos.</response>
        /// <response code="204">Si no hay eventos disponibles.</response>
        /// <response code="500">Si ocurrió un error interno del servidor.</response>
        [HttpGet]
        public async Task<ActionResult<List<EventLogType>>> GetAllEventLogTypesAsync()
        {
            var eventLogs = await _eventLogsTypeGet.GetAllEventLogTypesAsync();
            return Ok(eventLogs);
        }
    }
}
