using System.Text.Json.Serialization;

namespace BackWebApi.Entities
{
    public class EventLog
    {
        public int Id { get; set; }
        public int? IdTipo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistra { get; set; }

        [JsonIgnore]
        public EventLogType? Tipo { get; set; }
    }
}