using Avancerad_Lab1.Data;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Avancerad_Lab1.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDBContext _dbContext;

        public AdminRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAdminAsync(Admin admin)
        {
            _dbContext.Admins.Add(admin);
            await _dbContext.SaveChangesAsync();

            return admin.Id;

        }
        public async Task<bool> DeleteAdminAsync(int adminId)
        {
            var rowsAffected = await _dbContext.Admins.Where(s => s.Id == adminId).ExecuteDeleteAsync();

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<List<Admin>> GetAllAdminsAsync()
        {
            var admins = await _dbContext.Admins.ToListAsync();

            return admins;
        }
        public async Task<Admin> GetAdminByIdAsync(int adminId)
        {
            var admin = await _dbContext.Admins
                .FirstOrDefaultAsync(s => s.Id == adminId);

            return admin;

        }
        public async Task<bool> UpdateAdminAsync(Admin admin)
        {
            _dbContext.Admins.Update(admin);
            var result = await _dbContext.SaveChangesAsync();

            if (result != 0)
            {
                return true;
            }
            return false;
        }
    }
}
