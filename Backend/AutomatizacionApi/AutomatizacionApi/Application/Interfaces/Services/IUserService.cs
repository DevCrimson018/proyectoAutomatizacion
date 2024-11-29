using AutomatizacionApi.Application.Common;
using AutomatizacionApi.Application.DTOs.Auth;
using AutomatizacionApi.Domain.Entities.User;
using AutomatizacionApi.Entities;

namespace AutomatizacionApi.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<LoginResponse>> AuthenticationAsync(LoginRequest request);
        Task<ApplicationUser> RegisterAsync(ApplicationUser user, string password);
    }
}