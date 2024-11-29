using AutomatizacionApi.Domain.Entities.User;
using AutomatizacionApi.Entities;

namespace AutomatizacionApi.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser> Add(ApplicationUser user, string password);
        Task<ApplicationUser?> GetById(string id);
        Task<ApplicationUser?> GetByEmail(string email);
    }
}