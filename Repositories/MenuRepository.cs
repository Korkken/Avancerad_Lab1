using Avancerad_Lab1.Data;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Avancerad_Lab1.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDBContext _dbContext;

        public MenuRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddMenuAsync(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            await _dbContext.SaveChangesAsync();

            return menu.Id;

        }
        public async Task<bool> DeleteMenuAsync(int menuId)
        {
            var rowsAffected = await _dbContext.Menus.Where(s => s.Id == menuId).ExecuteDeleteAsync();

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<List<Menu>> GetAllMenusAsync()
        {
            var menus = await _dbContext.Menus.ToListAsync();

            return menus;
        }
        public async Task<Menu> GetMenuByIdAsync(int menuId)
        {
            var menu = await _dbContext.Menus
                .FirstOrDefaultAsync(s => s.Id == menuId);

            return menu;

        }
        public async Task<bool> UpdateMenuAsync(Menu menu)
        {
            _dbContext.Menus.Update(menu);
            var result = await _dbContext.SaveChangesAsync();

            if (result != 0)
            {
                return true;
            }
            return false;
        }
    }
}
