using Avancerad_Lab1.DTOs;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Repositories.IRepositories;
using Avancerad_Lab1.Services.IServices;

namespace Avancerad_Lab1.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<List<MenuDTO>> GetAllMenusAsync()
        {
            var Menus = await _menuRepository.GetAllMenusAsync();

            var menuDTO = Menus.Select(r => new MenuDTO
            {
                Id = r.Id,
                MenuItem = r.MenuItem,
                Description = r.Description,
                IsPopular = r.IsPopular,
                Price = r.Price,
                PictureUrl = r.PictureUrl,
            }).ToList();
            return menuDTO;
        }
        public async Task<MenuDTO> GetMenuByIdAsync(int menuId)
        {
            var menu = await _menuRepository.GetMenuByIdAsync(menuId);
            if (menu == null)
            {
                return null;
            }
            var menuDTO = new MenuDTO
            {
                Id = menu.Id,
                MenuItem = menu.MenuItem,
                Description = menu.Description,
                IsPopular = menu.IsPopular,
                Price = menu.Price,
                PictureUrl = menu.PictureUrl,
            };
            return menuDTO;
        }
        public async Task<int> CreateMenuAsync(MenuDTO menuDTO)
        {
            var menu = new Menu
            {
                MenuItem = menuDTO.MenuItem,
                Description = menuDTO.Description,
                IsPopular = menuDTO.IsPopular,
                Price = menuDTO.Price,
                PictureUrl = menuDTO.PictureUrl,
            };
            var newMenuId = await _menuRepository.AddMenuAsync(menu);
            return newMenuId;
        }
        public async Task<bool> UpdateMenuAsync(MenuDTO menuDTO)
        {
            var menu = new Menu
            {
                Id = menuDTO.Id,
                MenuItem = menuDTO.MenuItem,
                Description = menuDTO.Description,
                IsPopular = menuDTO.IsPopular,
                Price = menuDTO.Price,
                PictureUrl = menuDTO.PictureUrl,
            };
            var updatedMenu = await _menuRepository.UpdateMenuAsync(menu);
            return updatedMenu;
        }
        public Task<bool> DeleteMenuAsync(int menuId)
        {
            var deletedMenu = _menuRepository.DeleteMenuAsync(menuId);
            return deletedMenu;
        }
    }
}
