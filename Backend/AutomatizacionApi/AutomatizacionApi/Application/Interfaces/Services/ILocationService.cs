using AutomatizacionApi.Application.DTOs.Location;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Interfaces.Services
{
    public interface ILocationService
    {
        Task<Location> CreateAsync(LocationCreate location);
        Task<List<Location>> GetAllAsync();
        Task<Location> GetByIdAsync(int id);
        Task<Location> UpdateAsync(Location location);
    }
}