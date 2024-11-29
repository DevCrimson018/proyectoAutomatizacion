using AutomatizacionApi.Context.Identity;
using AutomatizacionApi.Entities;
using AutomatizacionApi.Interfaces.Repositories;

namespace AutomatizacionApi.Repositories
{
    public class TicketsCodeRepository(IdentityContext context) : BaseRepository<TicketsCode, Guid>(context), ITicketsCodeRepository
    {
    }
}
