using AutoMapper;
using AutomatizacionApi.Application.DTOs.Reservation;
using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.Domain.Enum;

namespace AutomatizacionApi.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITicketCodeService _ticketCodeService;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository,
            IMapper mapper,
            ITicketCodeService ticketCodeService)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _ticketCodeService = ticketCodeService;
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return (List<Reservation>)await _reservationRepository.GetAll();
        }

        public async Task<Reservation> GetByIdAsync(Guid id)
        {
            return await _reservationRepository.GetById(id);
        }

        public async Task<Reservation> CreateAsync(ReservationCreate reservation, string customerId)
        {
            var data = _mapper.Map<Reservation>(reservation);
            data.CustomerId = customerId;
            return await _reservationRepository.Create(data);
        }

        public async Task<Reservation> UpdateAsync(Reservation reservation)
        {
            return await _reservationRepository.Update(reservation);
        }


        public async Task ConfirmReservationAsync(string customerId, Guid reservationId)
        {
            var reservation = await GetByIdAsync(reservationId);
            if(reservation.CustomerId != customerId)
            {
                throw new("This reservation is not yours");
            }
            if(reservation is null)
            {
                throw new("Reservation not found");
            }

            await _ticketCodeService.CreateAsync(new()
            {
                Reservation = reservation
            });
        }

      
    }
}
