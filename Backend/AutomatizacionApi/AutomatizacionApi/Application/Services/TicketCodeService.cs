using AutomatizacionApi.Application.DTOs.TicketCode;
using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Services
{
    public class TicketCodeService(ITicketsCodeRepository ticketsCodeRepository) : ITicketCodeService
    {
        private readonly ITicketsCodeRepository _ticketCodeRepository = ticketsCodeRepository;
    

        public async Task<List<TicketsCode>> GetAllAsync()
        {
            return (List<TicketsCode>)await _ticketCodeRepository.GetAll();
        }

        public async Task<TicketsCode> GetByIdAsync(Guid id)
        {
            return await _ticketCodeRepository.GetById(id);
        }

        public async Task<List<TicketsCode>> CreateAsync(TicketCodeCreate reservation)
        {
            var ticketsCodeList = new List<TicketsCode>();
         
            for (var i = 0; i < reservation.Reservation.Quantity; i++) {
                var ticket = new TicketsCode
                {
                    TicketCode = Guid.NewGuid().ToString(),
                    ReservationId = reservation.Reservation.Id
                };
                await _ticketCodeRepository.Create(ticket);
                ticketsCodeList.Add(ticket);
            }
            return ticketsCodeList.ToList();
        }

        public async Task<List<TicketsCode>> GetByReservationId(Guid reservationId)
        {
            return await _ticketCodeRepository.GetByReservationId(reservationId);
        }
    }
}
