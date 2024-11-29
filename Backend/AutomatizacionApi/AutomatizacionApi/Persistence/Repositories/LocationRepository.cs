using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.Persistence.Context.Identity;

namespace AutomatizacionApi.Persistence.Repositories
{
    public class LocationRepository(IdentityContext context) : BaseRepository<Location, int>(context), ILocationRepository
    {
    }
}
