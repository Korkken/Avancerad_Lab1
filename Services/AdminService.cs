using Avancerad_Lab1.Data;
using Avancerad_Lab1.DTOs;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Repositories.IRepositories;
using Avancerad_Lab1.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Avancerad_Lab1.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly AppDBContext _context;
        public AdminService(IAdminRepository adminRepository, AppDBContext context)
        {
            _adminRepository = adminRepository;
            _context = context;
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
            var existingAdmin = await _context.Admins.FirstOrDefaultAsync(a => a.UserName == adminDTO.UserName);
            if (existingAdmin != null)
            {
                throw new InvalidOperationException("Username already exists");
            }
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(adminDTO.PasswordHash);
            var admin = new Admin
            {
                UserName = adminDTO.UserName,
                PasswordHash = hashedPassword,
                Role = "Admin"
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
