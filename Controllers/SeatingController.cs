using Avancerad_Lab1.DTOs;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Services.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Avancerad_Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatingController : ControllerBase
    {
        private readonly ISeatingService _seatingService; 

        // GET api/<ReservationController>/5
        public SeatingController(ISeatingService seatingService)
        {
            _seatingService = seatingService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SeatingDTO>>> GetAllSeating()
        {
            var customers = await _seatingService.GetAllSeatingsAsync();
            return Ok(customers);
        }

        // POST api/<ReservationController>
        [HttpPost]
        public async Task<ActionResult<SeatingDTO>> CreateCustomer(SeatingDTO seatingDTO)
        {
            var seatingId = await _seatingService.CreateSeatingAsync(seatingDTO);
            return Ok(seatingId);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatingDTO>> GetSeatingById(int seatingId)
        {
            var seating = await _seatingService.GetSeatingByIdAsync(seatingId);
            return Ok(seating);
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SeatingDTO>> UpdateSeatingAsync(SeatingDTO seatingDTO)
        {
            var seating = await _seatingService.UpdateSeatingAsync(seatingDTO);
            return Ok(seating);
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seating>> DeleteSeating(int seatingId)
        {
            var seating = await _seatingService.DeleteSeatingAsync(seatingId);
            return Ok(seating);

        }
       
    }
}
