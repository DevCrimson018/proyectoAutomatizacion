using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Application.Interfaces.Repositories
{
    public interface IReservationRepository : IBaseRepository<Reservation, Guid>
    {
    }
}
