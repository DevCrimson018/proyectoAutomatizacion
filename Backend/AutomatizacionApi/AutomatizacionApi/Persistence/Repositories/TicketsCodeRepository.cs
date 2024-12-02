using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.Persistence.Context.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutomatizacionApi.Persistence.Repositories
{
    public class TicketsCodeRepository(IdentityContext context) : BaseRepository<TicketsCode, Guid>(context), ITicketsCodeRepository
    {

        public async Task<List<TicketsCode>> GetByReservationId(Guid reservationId)
        {
            return await _dbSet.Where(x => x.ReservationId == reservationId).ToListAsync();
        }
    }
}
