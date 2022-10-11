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
    public class AdjusterAssignmentRepository : IAdjusterAssignmentRepository
    {
        private readonly IMongoCollection<AdjAssignment> _collection;
        private readonly DbConfiguration _settings;
        private readonly List<AdjAssignment> _assignments;
        public AdjusterAssignmentRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            //var client = new MongoClient(_settings.ConnectionString);
            //var database = client.GetDatabase(_settings.DatabaseName);
            //_collection = database.GetCollection<Customer>(_settings.CollectionName);
            _assignments = GetAssignments().ToList();
        }

        public Task<List<AdjAssignment>> GetAllAsync()
        {
            return  Task.FromResult(_assignments.ToList<AdjAssignment>());
        }
        public Task<AdjAssignment> GetByIdAsync(string id)
        {
            return Task.FromResult(_assignments.FirstOrDefault<AdjAssignment>(x => x.Id == id));
        }
        public async Task<AdjAssignment> CreateAsync(AdjAssignment adjAssignment)
        {
             _assignments.Add(adjAssignment);
            return await Task.FromResult(adjAssignment);
        }
        public Task UpdateAsync(string id, AdjAssignment adjAssignment)
        {
            
            var index = _assignments.FindIndex(x => x.Id == id);
            if (index > -1)
            {
                _assignments[index] = adjAssignment;
            }
            return Task.FromResult(adjAssignment);
        }
        public Task DeleteAsync(string id)
        {
            var cust = _assignments.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(_assignments.Remove(cust));
        }
        private IList<AdjAssignment> GetAssignments()
        {
            return new List<AdjAssignment>()
            {
                new AdjAssignment()
                {
                    Id = "00001",
                    AdjusterName = "Martin Flower",
                    AdjuterId = Guid.NewGuid().ToString(),
                    ClaimGroupId="Auto",
                    ClaimId = "ORDFF1231313"
                },
                new AdjAssignment()
                {
                    Id = "00002",
                    AdjusterName = "Brian Adams",
                    AdjuterId = Guid.NewGuid().ToString(),
                    ClaimGroupId="Property",
                    ClaimId = "ORDFF1231123313"
                },
                new AdjAssignment()
                {
                    Id = "00003",
                    AdjusterName = "Hari Nattuva",
                    AdjuterId = Guid.NewGuid().ToString(),
                    ClaimGroupId="Health",
                    ClaimId = "ORDFF12667878"
                },
                new AdjAssignment()
                {
                    AdjusterName = "Diana Adams",
                    AdjuterId = Guid.NewGuid().ToString(),
                    ClaimGroupId="Auto",
                    ClaimId = "ORDFF123451313"
                },
                new AdjAssignment()
                {
                    Id = "00004",
                    AdjusterName = "Eric Peter",
                    AdjuterId = Guid.NewGuid().ToString(),
                    ClaimGroupId="Property",
                    ClaimId = "ORDFF761313"
                },
                new AdjAssignment()
                {
                    Id = "00005",
                    AdjusterName = "Ian juliet",
                    AdjuterId = Guid.NewGuid().ToString(),
                    ClaimGroupId="Health",
                    ClaimId = "ORDFG1231313"
                }
            };
        }
    }
}
