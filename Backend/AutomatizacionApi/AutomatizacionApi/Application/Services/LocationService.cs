using AutoMapper;
using AutomatizacionApi.Application.DTOs.Location;
using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Services
{
    public class LocationService(ILocationRepository locationRepository
        ,IMapper mapper) : ILocationService
    {
        private readonly ILocationRepository _locationRepository = locationRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<List<Location>> GetAllAsync()
        {
            return (List<Location>)await _locationRepository.GetAll();
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            return await _locationRepository.GetById(id);
        }

        public async Task<Location> CreateAsync(LocationCreate location)
        {
            return await _locationRepository.Create(_mapper.Map<Location>(location));
        }

        public async Task<Location> UpdateAsync(Location location)
        {
            return await _locationRepository.Update(location);
        }
    }
}
