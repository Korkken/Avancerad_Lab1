using Avancerad_Lab1.DTOs;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Services;
using Avancerad_Lab1.Services.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Avancerad_Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        // GET api/<ReservationController>/5
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ReservationDTO>>> GetAllReservations()
        {
            var reservations = await _reservationService.GetReservationsAsync();
            return Ok(reservations);
        }

        // POST api/<ReservationController>
        [HttpPost]
        public async Task<ActionResult<ReservationDTO>> CreateReservation(ReservationDTO reservationDTO)
        {
            var reservationId = await _reservationService.CreateReservationAsync(reservationDTO);
            return Ok(reservationId);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetReservationById(int reservationId)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(reservationId);
            return Ok(reservation);
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ReservationDTO>> UpdateReservationAsync(ReservationDTO reservationDTO)
        {
            var reservation = await _reservationService.UpdateReservationAsync(reservationDTO);
            return Ok(reservation);
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservation>> DeleteReservation(int reservationId)
        {
            var reservation = await _reservationService.DeleteReservationAsync(reservationId);
            return Ok(reservation);

        }
    }
}
