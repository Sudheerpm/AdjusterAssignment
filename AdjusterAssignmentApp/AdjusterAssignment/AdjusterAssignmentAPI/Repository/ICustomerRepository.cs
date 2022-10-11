using System.Collections.Generic;
using System.Threading.Tasks;
using AdjusterAssignmentAPI.Models;

namespace AdjusterAssignmentAPI.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(string id);
        Task<Customer> CreateAsync(Customer customer);
        Task UpdateAsync(string id, Customer customer);
        Task DeleteAsync(string id);
    }
}
