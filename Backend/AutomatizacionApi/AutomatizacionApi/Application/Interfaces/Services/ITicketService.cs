using AutomatizacionApi.Application.DTOs.Ticket;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Interfaces.Services
{
    public interface ITicketService
    {
        Task<Ticket> CreateAsync(TicketCreateDTo ticket);
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket> GetByIdAsync(int id);
        Task<Ticket> UpdateAsync(Ticket ticket);
    }
}