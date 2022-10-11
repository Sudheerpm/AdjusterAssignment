using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using AdjusterAssignmentAPI.Models;

namespace AdjusterAssignmentAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _collection;
        private readonly DbConfiguration _settings;
        private readonly List<Customer> _customers;
        public CustomerRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            //var client = new MongoClient(_settings.ConnectionString);
            //var database = client.GetDatabase(_settings.DatabaseName);
            //_collection = database.GetCollection<Customer>(_settings.CollectionName);
            _customers = GetCustomers().ToList();
        }

        public Task<List<Customer>> GetAllAsync()
        {
            return  Task.FromResult(_customers.ToList<Customer>());
        }
        public Task<Customer> GetByIdAsync(string id)
        {
            return Task.FromResult(_customers.FirstOrDefault<Customer>(x => x.Id == id));
        }
        public async Task<Customer> CreateAsync(Customer customer)
        {
             _customers.Add(customer);
            return await Task.FromResult(customer);
        }
        public Task UpdateAsync(string id, Customer customer)
        {
            var cust =  _customers.FirstOrDefault(c => c.Id == id);
            cust = customer;
            return Task.FromResult(cust);
        }
        public Task DeleteAsync(string id)
        {
            var cust = _customers.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(_customers.Remove(cust));
        }
        private IList<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer{ Email = "test@testdomain.com", Contact = "Test contact1" , Country = "India",
                               FirstName  = "Ganpath", LastName = "Sinha", Id = "1029992" },
                new Customer{ Email = "test1@testdomain1.com", Contact = "Test contact2" , Country = "India",
                               FirstName  = "Surya", LastName = "Vamsi", Id = "1029993" },
                new Customer{ Email = "test3@testdomain2.com", Contact = "Test contact3" , Country = "India",
                               FirstName  = "Wiliam", LastName = "Desouza", Id = "1029994" },
                new Customer{ Email = "test3@testdomain3.com", Contact = "Test contact4" , Country = "India",
                               FirstName  = "Imam", LastName = "Ali", Id = "1029995" },
            };
            return customers;
        }
    }
}
