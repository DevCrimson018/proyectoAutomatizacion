using AutomatizacionApi.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace AutomatizacionApi.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task Add(ApplicationRole role);
        Task<List<IdentityRole>> GetAllAsync();
    }
}