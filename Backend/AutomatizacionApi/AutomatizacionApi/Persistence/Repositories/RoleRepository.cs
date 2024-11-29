using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Domain.Entities.User;
using AutomatizacionApi.Persistence.Context.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutomatizacionApi.Persistence.Repositories
{
    public class RoleRepository(IdentityContext context) : IRoleRepository
    {
        private readonly IdentityContext _context = context;


        public async Task<List<IdentityRole>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task Add(ApplicationRole role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }
    }
}
