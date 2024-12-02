using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Services
{
    public class BusService(IBusRepository busRepository) : IBusService
    {
        private readonly IBusRepository _busRepository = busRepository;

        public async Task<List<Bus>> GetAllAsync()
        {
            return (List<Bus>)await _busRepository.GetAll();
        }

        public async Task<Bus?> GetByIdAsync(Guid id)
        {
            return await _busRepository.GetById(id);
        }


        public async Task<Bus> CreateAsync(Bus bus)
        {
            return await _busRepository.Create(bus);
        }
    }
}
