using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Services
{
    public class BusStatusServices(IBusStatusRepository busStatusRepository) : IBusStatusServices
    {
        private readonly IBusStatusRepository _busStatusRepository = busStatusRepository;


        public async Task<List<BusStatus>> GetAllAsync()
        {
            return (List<BusStatus>)await _busStatusRepository.GetAll();
        }
    }
}
