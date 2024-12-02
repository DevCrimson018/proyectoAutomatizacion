using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Interfaces.Repositories
{
    public interface ITicketsCodeRepository : IBaseRepository<TicketsCode, Guid>
    {
        Task<List<TicketsCode>> GetByReservationId(Guid reservationId);
    }
}
