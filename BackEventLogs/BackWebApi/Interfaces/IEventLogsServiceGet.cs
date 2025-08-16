using BackWebApi.Dtos;
using BackWebApi.Entities;

namespace BackWebApi.Interfaces
{
    public interface IEventLogsServiceGet
    {
        Task<List<EventLogsDto>> GetAllEventLogsAsync();
        Task<List<EventLogsDto>> GetEventLogsByDatesAsync(DateRangeDto fechas);
        Task<List<EventLogsDto>> GetAllByIdTypeAsync(int idTipo);
    }
}