using System.Collections.Generic;
using System.Threading.Tasks;
using AdjusterAssignmentAPI.Models;
using AdjusterAssignmentAPI.Repository;

namespace AdjusterAssignmentAPI.Services
{
    public class AdjusterAssignmentService : IAdjusterAssignmentService
    {
        private readonly IAdjusterAssignmentRepository _adjusterAssignmentRepository;

        public AdjusterAssignmentService(IAdjusterAssignmentRepository adjusterAssignmentRepository)
        {
            _adjusterAssignmentRepository = adjusterAssignmentRepository;
        }

        public Task<List<AdjAssignment>> GetAllAsync()
        {
            return _adjusterAssignmentRepository.GetAllAsync();
        }

        public Task<AdjAssignment> GetByIdAsync(string id)
        {
            return _adjusterAssignmentRepository.GetByIdAsync(id);
        }

        public Task<AdjAssignment> CreateAsync(AdjAssignment customer)
        {
            return _adjusterAssignmentRepository.CreateAsync(customer);
        }

        public Task UpdateAsync(string id, AdjAssignment customer)
        {
            return _adjusterAssignmentRepository.UpdateAsync(id, customer);
        }

        public Task DeleteAsync(string id)
        {
            return _adjusterAssignmentRepository.DeleteAsync(id);
        }
    }
}
