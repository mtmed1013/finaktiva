namespace BackWebApi.Entities
{
    public class EventLog
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }

        public string? Descripcion { get; set; }
        public DateTime FechaRegistra { get; set; }
    }
}