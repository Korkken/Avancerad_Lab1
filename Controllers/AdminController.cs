using Avancerad_Lab1.DTOs;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Avancerad_Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        // GET api/<ReservationController>/5
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]

        // POST api/<ReservationController>
        [HttpPost]

        public async Task<ActionResult<ReservationDTO>> CreateAdmin(AdminDTO adminDTO)
        {
            var adminId = await _adminService.CreateAdminAsync(adminDTO);
            return Ok(adminId);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetAdminById(int adminId)
        {
            var admin = await _adminService.GetAdminByIdAsync(adminId);
            return Ok(admin);
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ReservationDTO>> UpdateAdminAsync(AdminDTO adminDTO)
        {
            var admin = await _adminService.UpdateAdminAsync(adminDTO);
            return Ok(admin);
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservation>> DeleteAdmin(int adminId)
        {
            var admin = await _adminService.DeleteAdminAsync(adminId);
            return Ok(admin);

        }
    }
}
