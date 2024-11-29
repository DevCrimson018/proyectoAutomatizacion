using AutomatizacionApi.Context.Identity;
using AutomatizacionApi.Entities;
using AutomatizacionApi.Interfaces.Repositories;

namespace AutomatizacionApi.Repositories
{
    public class BusStatusRepository(IdentityContext context) : BaseRepository<BusStatus, int>(context), IBusStatusRepository
    {
    }
}
