using BackWebApi.Dtos;
namespace BackWebApi.Interfaces
{
    public interface IEventLogsGetRepository
    {
        Task<List<EventLogsDto>> GetEventLogsAsync();
        Task<List<EventLogsDto>> GetEventLogsByDatesAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<List<EventLogsDto>> GetAllByIdTypeAsync(int idTipo);
    }
}
