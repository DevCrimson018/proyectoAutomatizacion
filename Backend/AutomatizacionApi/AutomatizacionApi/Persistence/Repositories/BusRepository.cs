using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.Persistence.Context.Identity;

namespace AutomatizacionApi.Persistence.Repositories
{
    public class BusRepository(IdentityContext context) : BaseRepository<Bus, Guid>(context), IBusRepository
    {
    }
}
