

using BackWebApi.Entities;

namespace BackWebApi.Services
{
    public class EventLogsTransform
    {
        public static EventLog TransformToEventLog(EventLog eventLog, IHttpContextAccessor httpContextAccessor)
        {
            var tipo = httpContextAccessor.HttpContext?.Request.Headers["tipo"].FirstOrDefault() ?? "2";
            eventLog.IdTipo = int.Parse(tipo);
            return eventLog;
        }


    }
}