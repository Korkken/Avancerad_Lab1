using Avancerad_Lab1.DTOs;

namespace Avancerad_Lab1.Services.IServices
{
    public interface IAdminService
    {
        Task<List<AdminDTO>> GetAllAdminsAsync();
        Task<AdminDTO> GetAdminByIdAsync(int adminId);
        Task<int> CreateAdminAsync(AdminDTO adminDTO);
        Task<bool> UpdateAdminAsync(AdminDTO adminDTO);
        Task<bool> DeleteAdminAsync(int adminDTO);
    }
}
