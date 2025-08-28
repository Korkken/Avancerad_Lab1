using Avancerad_Lab1.DTOs;

namespace Avancerad_Lab1.Services.IServices
{
    public interface IMenuService
    {
        Task<List<MenuDTO>> GetAllMenusAsync();
        Task<MenuDTO> GetMenuByIdAsync(int menuId);
        Task<int> CreateMenuAsync(MenuDTO menuDTO);
        Task<bool> UpdateMenuAsync(MenuDTO menuDTO);
        Task<bool> DeleteMenuAsync(int menuId);
    }
}
