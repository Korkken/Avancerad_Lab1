using Avancerad_Lab1.Models;

namespace Avancerad_Lab1.Repositories.IRepositories
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllMenusAsync();
        Task<Menu> GetMenuByIdAsync(int menuId);
        Task<int> AddMenuAsync(Menu menu);
        Task<bool> UpdateMenuAsync(Menu menu);
        Task<bool> DeleteMenuAsync(int menuId);
    }
}
