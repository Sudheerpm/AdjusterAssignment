using System.Collections.Generic;
using System.Threading.Tasks;
using AdjusterAssignmentAPI.Models;

namespace AdjusterAssignmentAPI.Repository
{
    public interface IAdjusterAssignmentRepository
    {
        Task<List<AdjAssignment>> GetAllAsync();
        Task<AdjAssignment> GetByIdAsync(string id);
        Task<AdjAssignment> CreateAsync(AdjAssignment customer);
        Task UpdateAsync(string id, AdjAssignment customer);
        Task DeleteAsync(string id);
    }
}
