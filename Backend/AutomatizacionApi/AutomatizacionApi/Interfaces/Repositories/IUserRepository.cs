using AutomatizacionApi.Entities;

namespace AutomatizacionApi.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser> Add(ApplicationUser user, string password);
        Task<ApplicationUser?> GetById(string id);
        Task<ApplicationUser?> GetByEmail(string email);
    }
}