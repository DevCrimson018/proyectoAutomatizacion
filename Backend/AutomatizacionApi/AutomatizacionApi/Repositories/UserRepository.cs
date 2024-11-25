using AutomatizacionApi.Entities;
using AutomatizacionApi.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace AutomatizacionApi.Repositories
{
    public class UserRepository(UserManager<ApplicationUser> userManager) : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<ApplicationUser> Add(ApplicationUser user)
        {
            user.EmailConfirmed = true;
            await _userManager.CreateAsync(user);
            return user;
        }

        public async Task<ApplicationUser?> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id)!;
        }
    }
}
