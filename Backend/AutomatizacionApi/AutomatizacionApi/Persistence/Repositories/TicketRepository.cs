using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.Persistence.Context.Identity;

namespace AutomatizacionApi.Persistence.Repositories
{
    public class TicketRepository(IdentityContext context) : BaseRepository<Ticket, int>(context), ITicketRepository
    {
    }
}
