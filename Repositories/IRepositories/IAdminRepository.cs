using Avancerad_Lab1.Models;

namespace Avancerad_Lab1.Repositories.IRepositories
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAllAdminsAsync();
        Task<Admin> GetAdminByIdAsync(int adminId);
        Task<int> AddAdminAsync(Admin admin);
        Task<bool> UpdateAdminAsync(Admin admin);
        Task<bool> DeleteAdminAsync(int adminId);
    }
}
