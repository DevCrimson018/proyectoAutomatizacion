using AutomatizacionApi.Application.DTOs.TicketCode;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Interfaces.Services
{
    public interface ITicketCodeService
    {
        Task<List<TicketsCode>> CreateAsync(TicketCodeCreate ticketCode);
        Task<List<TicketsCode>> GetAllAsync();
        Task<TicketsCode> GetByIdAsync(Guid id);
        Task<List<TicketsCode>> GetByReservationId(Guid reservationId);
    }
}