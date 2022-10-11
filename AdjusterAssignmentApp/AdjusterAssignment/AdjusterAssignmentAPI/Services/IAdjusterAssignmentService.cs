using System.Collections.Generic;
using System.Threading.Tasks;
using AdjusterAssignmentAPI.Models;

namespace AdjusterAssignmentAPI.Services
{
    public interface IAdjusterAssignmentService
    {
        Task<List<AdjAssignment>> GetAllAsync();
        Task<AdjAssignment> GetByIdAsync(string id);
        Task<AdjAssignment> CreateAsync(AdjAssignment customer);
        Task UpdateAsync(string id, AdjAssignment customer);
        Task DeleteAsync(string id);
    }
}
