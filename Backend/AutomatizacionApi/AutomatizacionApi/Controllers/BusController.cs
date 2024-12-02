
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.NewFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AutomatizacionApi.Controllers
{
    [Authorize]
    [Route("Api/[Controller]")]
    [ApiController]
    public class BusController(IBusService busService, ClaimsHelper claimsHelper) : ControllerBase
    {
        private readonly IBusService _busServices = busService;
        private readonly ClaimsHelper claimsHelper = claimsHelper;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _busServices.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _busServices.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bus bus)
        {
            var response = await _busServices.CreateAsync(bus);
            return Ok(response);
        }
    }
}
