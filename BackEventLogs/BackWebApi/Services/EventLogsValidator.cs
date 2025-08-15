using BackWebApi.Entities;

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
            if (string.IsNullOrWhiteSpace(eventLog.Tipo))
            {
                throw new ArgumentException("El tipo es requerido.");
            }
        }
    }
}