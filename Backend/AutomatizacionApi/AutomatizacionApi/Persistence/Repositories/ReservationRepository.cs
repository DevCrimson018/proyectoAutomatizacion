using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.Persistence.Context.Identity;

namespace AutomatizacionApi.Persistence.Repositories
{
    public class ReservationRepository(IdentityContext context) : BaseRepository<Reservation, Guid>(context), IReservationRepository
    {
    }
}
