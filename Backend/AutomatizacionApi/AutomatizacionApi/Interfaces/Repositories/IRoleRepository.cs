using AutomatizacionApi.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace AutomatizacionApi.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task Add(ApplicationRole role);
        Task<List<IdentityRole>> GetAllAsync();
    }
}