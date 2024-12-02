using AutomatizacionApi.Application.Common;
using AutomatizacionApi.Application.DTOs.Auth;
using AutomatizacionApi.Domain.Entities.User;

namespace AutomatizacionApi.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<LoginResponse>> AuthenticationAsync(LoginRequest request);
        Task<ApplicationUser> CreateCustomerAsync(CustomerCreate customer);
        Task<ApplicationUser> CreateDriverAsync(DriverCreate driver);
        Task<ApplicationUser> CreateAdminAsync(AdminCreate admin);
    }
}