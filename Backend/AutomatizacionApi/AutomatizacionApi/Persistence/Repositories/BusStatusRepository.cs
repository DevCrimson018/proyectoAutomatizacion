using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.Persistence.Context.Identity;

namespace AutomatizacionApi.Persistence.Repositories
{
    public class BusStatusRepository(IdentityContext context) : BaseRepository<BusStatus, int>(context), IBusStatusRepository
    {
    }
}
