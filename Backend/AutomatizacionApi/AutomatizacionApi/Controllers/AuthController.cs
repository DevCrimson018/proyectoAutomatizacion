using AutomatizacionApi.Application.DTOs.Auth;
using AutomatizacionApi.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutomatizacionApi.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class AuthController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;


        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            var response = await _userService.AuthenticationAsync(request);

            if (!response.IsSuccess)
            {
                return Unauthorized();
            }

            return Ok(response);
        }


        [HttpPost("Customer")]
        public async Task<IActionResult> RegisterCustomer(CustomerCreate request)
        {
            var response = await _userService.CreateCustomerAsync(request);
            return Ok(response);
        }

        [HttpPost("Admin")]
        public async Task<IActionResult> RegisterAdmin(AdminCreate request)
        {
            var response = await _userService.CreateAdminAsync(request);
            return Ok(response);
        }

        [HttpPost("Driver")]
        public async Task<IActionResult> RegisterDriver(DriverCreate request)
        {
            var response = await _userService.CreateDriverAsync(request);
            return Ok(response);
        }
    }
}
