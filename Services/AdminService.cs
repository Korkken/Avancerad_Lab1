using Avancerad_Lab1.DTOs;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Repositories.IRepositories;
using Avancerad_Lab1.Services.IServices;

namespace Avancerad_Lab1.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<List<AdminDTO>> GetAllAdminsAsync()
        {
            var admins = await _adminRepository.GetAllAdminsAsync();

            var adminDTO = admins.Select(r => new AdminDTO
            {
                UserName = r.UserName,
                PasswordHash = r.PasswordHash,
            }).ToList();
            return adminDTO;
        }
        public async Task<AdminDTO> GetAdminByIdAsync(int adminId)
        {
            var admin = await _adminRepository.GetAdminByIdAsync(adminId);
            if (admin == null)
            {
                return null;
            }
            var adminDTO = new AdminDTO
            {
                UserName = admin.UserName,
                PasswordHash = admin.PasswordHash,
            };
            return adminDTO;
        }
        public async Task<int> CreateAdminAsync(AdminDTO adminDTO)
        {
            var admin = new Admin
            {
                UserName = adminDTO.UserName,
                PasswordHash = adminDTO.PasswordHash,
            };
            var newAdminId = await _adminRepository.AddAdminAsync(admin);
            return newAdminId;
        }
        public async Task<bool> UpdateAdminAsync(AdminDTO adminDTO)
        {
            var admin = new Admin
            {
                UserName = adminDTO.UserName,
                PasswordHash = adminDTO.PasswordHash,
            };
            var updatedAdmin = await _adminRepository.UpdateAdminAsync(admin);
            return updatedAdmin;
        }
        public Task<bool> DeleteAdminAsync(int adminId)
        {
            var deletedAdmin = _adminRepository.DeleteAdminAsync(adminId);
            return deletedAdmin;
        }
    }
}
