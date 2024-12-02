using AutomatizacionApi.Application.DTOs.TicketCode;
using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Services
{
    public class TicketCodeService(ITicketsCodeRepository ticketsCodeRepository,
        IReservationService reservationService) : ITicketCodeService
    {
        private readonly ITicketsCodeRepository _ticketCodeRepository = ticketsCodeRepository;
        private readonly IReservationService _reservationService = reservationService;

        public async Task<List<TicketsCode>> GetAllAsync()
        {
            return (List<TicketsCode>)await _ticketCodeRepository.GetAll();
        }

        public async Task<TicketsCode> GetByIdAsync(Guid id)
        {
            return await _ticketCodeRepository.GetById(id);
        }

        public async Task<List<TicketsCode>> CreateAsync(TicketCodeCreate ticketCode)
        {
            var ticketsCodeList = new List<TicketsCode>();
            var reservation = await _reservationService.GetByIdAsync(ticketCode.ReservationId) ?? throw new Exception("Reservation not found");
            for (var i = 0; i < reservation.Quantity; i++) {
                var ticket = new TicketsCode
                {
                    TicketCode = Guid.NewGuid().ToString(),
                    ReservationId = ticketCode.ReservationId
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
