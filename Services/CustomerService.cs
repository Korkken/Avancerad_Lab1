using Avancerad_Lab1.DTOs;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Repositories.IRepositories;
using Avancerad_Lab1.Services.IServices;

namespace Avancerad_Lab1.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            var Customers = await _customerRepository.GetAllCustomersAsync();

            var customerDTO = Customers.Select(r => new CustomerDTO
            {
                Name = r.Name,
                Email = r.Email,
                Phone = r.Phone,
            }).ToList();
            return customerDTO;
        }
        public async Task<CustomerDTO> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                return null;
            }
            var customerDTO = new CustomerDTO
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
            };
            return customerDTO;
        }
        public async Task<int> CreateCustomerAsync(CustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                Name = customerDTO.Name,
                Email = customerDTO.Email,
                Phone = customerDTO.Phone,
            };
            var newCustomerId = await _customerRepository.AddCustomerAsync(customer);
            return newCustomerId;
        }
        public async Task<bool> UpdateCustomerAsync(CustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                Name = customerDTO.Name,
                Email = customerDTO.Email,
                Phone = customerDTO.Phone,
            };
            var updatedCustomer = await _customerRepository.UpdateCustomerAsync(customer);
            return updatedCustomer;
        }
        public Task<bool> DeleteCustomerAsync(int customerId)
        {
            var deletedCustomer = _customerRepository.DeleteCustomerAsync(customerId);
            return deletedCustomer;
        }
    }
}
