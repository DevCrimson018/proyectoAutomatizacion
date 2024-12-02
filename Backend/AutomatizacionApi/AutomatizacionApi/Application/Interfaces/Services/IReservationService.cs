using AutomatizacionApi.Application.DTOs.Reservation;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Interfaces.Services
{
    public interface IReservationService
    {
        Task<Reservation> CreateAsync(ReservationCreate reservation);
        Task<List<Reservation>> GetAllAsync();
        Task<Reservation> GetByIdAsync(Guid id);
        Task<Reservation> UpdateAsync(Reservation reservation);
    }
}