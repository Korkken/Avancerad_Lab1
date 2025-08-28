using Avancerad_Lab1.DTOs;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Services.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Avancerad_Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        // GET: api/<MenuController>
        private readonly IMenuService _menuService; 

        // GET api/<ReservationController>/5
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        [HttpGet]
        public async Task<ActionResult<List<MenuDTO>>> GetAllMenus()
        {
            var menus = await _menuService.GetAllMenusAsync();
            return Ok(menus);
        }

        // POST api/<ReservationController>
        [HttpPost]
        public async Task<ActionResult<MenuDTO>> CreateMenu(MenuDTO menuDTO)
        {
            var menuId = await _menuService.CreateMenuAsync(menuDTO);
            return Ok(menuId);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuDTO>> GetMenuById(int menuId)
        {
            var menu = await _menuService.GetMenuByIdAsync(menuId);
            return Ok(menu);
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MenuDTO>> UpdateMenuAsync(MenuDTO menuDTO)
        {
            var menu = await _menuService.UpdateMenuAsync(menuDTO);
            return Ok(menu);
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Menu>> DeleteMenu(int menuId)
        {
            var menu = await _menuService.DeleteMenuAsync(menuId);
            return Ok(menu);

        }
    }
}
