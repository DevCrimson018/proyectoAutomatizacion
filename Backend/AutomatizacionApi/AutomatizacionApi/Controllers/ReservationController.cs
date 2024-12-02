using AutomatizacionApi.Application.DTOs.Reservation;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutomatizacionApi.Controllers
{
    [Authorize]
    [Route("Api/[Controller]")]
    [ApiController]
    public class ReservationController(IReservationService reservationService) : ControllerBase
    {
        private readonly IReservationService _reservationServices = reservationService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _reservationServices.GetAllAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _reservationServices.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreate reservation)
        {
            var response = await _reservationServices.CreateAsync(reservation);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Reservation reservation)
        {
            var response = await _reservationServices.UpdateAsync(reservation);
            return Ok(response);
        }
    }
}
