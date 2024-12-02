using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.Persistence.Context.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutomatizacionApi.Persistence.Repositories
{
    public class TicketRepository(IdentityContext context) : BaseRepository<Ticket, int>(context), ITicketRepository
    {
        public override async Task<Ticket?> GetById(int id)
        {
            return await _dbSet.Include(x => x.Location).FirstAsync(x => x.Id == id);
        }
    }
}
