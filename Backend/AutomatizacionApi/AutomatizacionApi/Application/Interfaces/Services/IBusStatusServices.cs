using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Interfaces.Services
{
    public interface IBusStatusServices
    {
        Task<List<BusStatus>> GetAllAsync();
    }
}