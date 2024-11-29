using AutomatizacionApi.Context.Identity;
using AutomatizacionApi.Entities;
using AutomatizacionApi.Interfaces.Repositories;

namespace AutomatizacionApi.Repositories
{
    public class ReservationRepository(IdentityContext context) : BaseRepository<Reservation, Guid>(context), IReservationRepository
    {
    }
}
