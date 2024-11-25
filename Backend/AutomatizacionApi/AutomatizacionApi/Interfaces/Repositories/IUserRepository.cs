using AutomatizacionApi.Entities;

namespace AutomatizacionApi.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser> Add(ApplicationUser user);
        Task<ApplicationUser?> GetById(string id);
    }
}