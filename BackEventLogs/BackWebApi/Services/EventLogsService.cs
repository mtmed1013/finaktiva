using BackWebApi.Dtos;
using BackWebApi.Entities;
using BackWebApi.Interfaces;
using HelperDates;

namespace BackWebApi.Services
{
    public class EventLogsService : IEventLogsServiceAdd, IEventLogsServiceGet
    {
        private readonly IEventLogsAddRepository _eventAdd;
        private readonly IEventLogsGetRepository _eventGet;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EventLogsService(IEventLogsAddRepository eventAdd,
        IEventLogsGetRepository eventGet,
        IHttpContextAccessor httpContextAccessor)
        {
            _eventAdd = eventAdd;
            _eventGet = eventGet;
            _httpContextAccessor = httpContextAccessor;
        }

        /*
          Método : AddEventLogAsync
          Descripción: Agrega un nuevo registro de evento
          Flujo:
            1. Se obtiene de la cabecera el tipo de evento, donde 
                si viene con un header tipo, se obtiene este que debería 
                ser Formulario, si no lo tiene es considerado petición por API.
            2. Se valida la los campos obligatorios sino se considera error 
               y se lanza una excepción de deriba en un error 400, 
               error que será tomado por angular para mostrar
            3. Se agrega el evento a la base de datos
        */
        public async Task<EventLog> AddEventLogAsync(EventLog eventLog)
        {
            EventLogsTransform.TransformToEventLog(eventLog, _httpContextAccessor);
            EventLogsValidator.ValidateFields(eventLog);
            return await _eventAdd.AddEventLogAsync(eventLog);
        }

        /*
          Método : GetAllEventLogsAsync
          Descripción: Obtiene todos los registros de los eventos
          Flujo:
            1. Se obtiene todos los registros de los eventos
            2. Se valida si existe información, sino respuesta 204 : No Content
            3. Se retorna la lista de registros de eventos.
        */
        public async Task<List<EventLogsDto>> GetAllEventLogsAsync()
        {
            List<EventLogsDto> data = await _eventGet.GetEventLogsAsync();
            EventLogsValidator.ValidateData(data);
            return data;
        }

        /*
          Método : GetEventLogsByDatesAsync
          Descripción: Obtiene los registros de eventos por rango de fechas.
          Flujo:
            1. Se valida el rango de fechas.
            2. Se transforman las fechas a DateTime.
            3. Se obtienen los registros de eventos por rango de fechas.
            4. Se valida si existe información, sino respuesta 204 : No Content
            5. Se retorna la lista de registros de eventos.
        */

        public async Task<List<EventLogsDto>> GetEventLogsByDatesAsync(DateRangeDto fechas)
        {
            EventLogsValidator.ValidateDates(fechas);
            DateTime fechaInicio = DateHelper.TransformDates(fechas.FechaInicial);
            DateTime fechaFin = DateHelper.TransformDates(fechas.FechaFinal);
            List<EventLogsDto> data = await _eventGet.GetEventLogsByDatesAsync(fechaInicio, fechaFin);
            EventLogsValidator.ValidateData(data);
            return data;
        }
        /*
          Método : GetAllByIdTypeAsync
          Descripción: Obtiene todos los registros de eventos por tipo.
          Flujo:
            1. Se valida el ID del tipo de evento.
            2. Se obtienen los registros de eventos por tipo.
            3. Se valida si existe información, sino respuesta 204 : No Content
            4. Se retorna la lista de registros de eventos.
        */

        public async Task<List<EventLogsDto>> GetAllByIdTypeAsync(int idTipo)
        {
            List<EventLogsDto> data = await _eventGet.GetAllByIdTypeAsync(idTipo);
            EventLogsValidator.ValidateData(data);
            return data;
        }
    }
}