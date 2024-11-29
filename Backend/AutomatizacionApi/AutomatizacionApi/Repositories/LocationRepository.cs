using AutomatizacionApi.Context.Identity;
using AutomatizacionApi.Entities;
using AutomatizacionApi.Interfaces.Repositories;

namespace AutomatizacionApi.Repositories
{
    public class LocationRepository(IdentityContext context) : BaseRepository<Location, int>(context), ILocationRepository
    {
    }
}
