using AutomatizacionApi.Context.Identity;
using AutomatizacionApi.Entities;
using AutomatizacionApi.Interfaces.Repositories;

namespace AutomatizacionApi.Repositories
{
    public class TicketRepository(IdentityContext context) : BaseRepository<Ticket, int>(context), ITicketRepository
    {
    }
}
