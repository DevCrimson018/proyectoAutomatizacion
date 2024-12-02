using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Interfaces.Services
{
    public interface IBusService
    {
        Task<Bus> CreateAsync(Bus bus);
        Task<List<Bus>> GetAllAsync();
        Task<Bus?> GetByIdAsync(Guid id);
    }
}