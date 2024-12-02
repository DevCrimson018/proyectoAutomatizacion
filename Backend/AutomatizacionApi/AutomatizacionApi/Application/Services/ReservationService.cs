using AutoMapper;
using AutomatizacionApi.Application.DTOs.Reservation;
using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository,
            IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return (List<Reservation>)await _reservationRepository.GetAll();
        }

        public async Task<Reservation> GetByIdAsync(Guid id)
        {
            return await _reservationRepository.GetById(id);
        }

        public async Task<Reservation> CreateAsync(ReservationCreate reservation)
        {
            return await _reservationRepository.Create(_mapper.Map<Reservation>(reservation));
        }

        public async Task<Reservation> UpdateAsync(Reservation reservation)
        {
            return await _reservationRepository.Update(reservation);
        }

      
    }
}
