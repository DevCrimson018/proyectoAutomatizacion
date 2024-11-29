using AutomatizacionApi.Common;
using AutomatizacionApi.DTOs.Auth;
using AutomatizacionApi.Entities;
using AutomatizacionApi.Entities.User;

namespace AutomatizacionApi.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<LoginResponse>> AuthenticationAsync(LoginRequest request);
        Task<ApplicationUser> RegisterAsync(ApplicationUser user, string password);
    }
}