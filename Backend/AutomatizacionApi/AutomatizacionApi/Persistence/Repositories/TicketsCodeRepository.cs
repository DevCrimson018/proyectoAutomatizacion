using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.Persistence.Context.Identity;

namespace AutomatizacionApi.Persistence.Repositories
{
    public class TicketsCodeRepository(IdentityContext context) : BaseRepository<TicketsCode, Guid>(context), ITicketsCodeRepository
    {
    }
}
