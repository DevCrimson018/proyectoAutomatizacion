using AutomatizacionApi.Application.DTOs.Location;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutomatizacionApi.Controllers
{
    [Authorize]
    [Route("Api/[Controller]")]
    [ApiController]
    public class LocationController(ILocationService locationService) : ControllerBase
    {
        private readonly ILocationService _locationServices = locationService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _locationServices.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _locationServices.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LocationCreate location)
        {
            var response = await _locationServices.CreateAsync(location);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Location location)
        {
            var response = await _locationServices.UpdateAsync(location);
            return Ok(response);
        }

    }
}
