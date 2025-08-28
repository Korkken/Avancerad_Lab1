using Avancerad_Lab1.DTOs;

namespace Avancerad_Lab1.Services.IServices
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
        Task<int> CreateCustomerAsync(CustomerDTO customerDTO);
        Task<bool> UpdateCustomerAsync(CustomerDTO customerId);
        Task<bool> DeleteCustomerAsync(int customerId);
    }
}
