using Avancerad_Lab1.Data;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Avancerad_Lab1.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDBContext _dbContext;

        public CustomerRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddCustomerAsync(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            return customer.Id;

        }
        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var rowsAffected = await _dbContext.Customers.Where(s => s.Id == customerId).ExecuteDeleteAsync();

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var customers = await _dbContext.Customers.ToListAsync();

            return customers;
        }
        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(s => s.Id == customerId);

            return customer;

        }
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            var result = await _dbContext.SaveChangesAsync();

            if (result != 0)
            {
                return true;
            }
            return false;
        }
    }
}
