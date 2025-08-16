namespace BackWebApi.Dtos
{
    public class EventLogsDto
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistra { get; set; }
    }
}