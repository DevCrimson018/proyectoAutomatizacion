using AutomatizacionApi.Context.Identity;
using AutomatizacionApi.Entities;
using AutomatizacionApi.Interfaces.Repositories;

namespace AutomatizacionApi.Repositories
{
    public class BusRepository(IdentityContext context) : BaseRepository<Bus, Guid>(context), IBusRepository
    {
    }
}
