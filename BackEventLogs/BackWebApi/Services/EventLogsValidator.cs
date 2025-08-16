using BackWebApi.Dtos;
using BackWebApi.Entities;
using BackWebApi.Utils;

namespace BackWebApi.Services
{
    public class EventLogsValidator
    {
        public static void ValidateFields(EventLog eventLog)
        {
            if (string.IsNullOrWhiteSpace(eventLog.Descripcion))
            {
                throw new ArgumentException("La descripción es requerida.");
            }
            if (eventLog.IdTipo == 0)
            {
                throw new ArgumentException("El tipo es requerido.");
            }
        }

        public static void ValidateData(List<EventLogsDto> eventLogs)
        {
            if (eventLogs == null || !eventLogs.Any())
            {
                throw new CustomException("No se encontraron registros de eventos.", 204);
            }
        }

        public static void ValidateDates(DateRangeDto fechas)
        {
            if (string.IsNullOrWhiteSpace(fechas.FechaInicial) || string.IsNullOrWhiteSpace(fechas.FechaFinal))
            {
                throw new ArgumentException("Las fechas inicial y final son requeridas.");
            }
        }

        public static void ValidateType(int idTipo)
        {
            if (idTipo == 0)
            {
                throw new ArgumentException("El tipo es requerido.");
            }
        }
    }
}