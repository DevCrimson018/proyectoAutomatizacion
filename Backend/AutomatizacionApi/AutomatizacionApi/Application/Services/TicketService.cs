using AutoMapper;
using AutomatizacionApi.Application.DTOs.Ticket;
using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Services
{
    public class TicketService(ITicketRepository ticketRepository,
        IMapper mapper) : ITicketService
    {
        private readonly ITicketRepository _ticketRepository = ticketRepository;
        private readonly IMapper _mapper = mapper;


        public async Task<List<Ticket>> GetAllAsync()
        {
            return (List<Ticket>)await _ticketRepository.GetAll();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _ticketRepository.GetById(id);
        }

        public async Task<Ticket> CreateAsync(TicketCreateDTo ticket)
        {
            return await _ticketRepository.Create(_mapper.Map<Ticket>(ticket));
        }

        public async Task<Ticket> UpdateAsync(Ticket ticket)
        {
            return await _ticketRepository.Update(ticket);
        }


    }
}
