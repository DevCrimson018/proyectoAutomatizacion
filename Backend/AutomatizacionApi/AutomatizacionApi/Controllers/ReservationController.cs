using AutomatizacionApi.Application.DTOs.Reservation;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.NewFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace AutomatizacionApi.Controllers
{
    [Authorize]
    [Route("Api/[Controller]")]
    [ApiController]
    public class ReservationController(IReservationService reservationService
        , ClaimsHelper claimsHelper) : ControllerBase
    {
        private readonly IReservationService _reservationServices = reservationService;
        private readonly ClaimsHelper claimsHelper = claimsHelper;

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
            string customerId = claimsHelper.GetUserId()!;
            var response = await _reservationServices.CreateAsync(reservation, customerId);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Reservation reservation)
        {
            var response = await _reservationServices.UpdateAsync(reservation);
            return Ok(response);
        }

        [HttpPut("Status/Confirm")]
        public async Task<IActionResult> ConfirmReservation(Guid reservationId)
        {
            try
            {
                var customerId = claimsHelper.GetUserId();
                await _reservationServices.ConfirmReservationAsync(customerId!, reservationId);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
