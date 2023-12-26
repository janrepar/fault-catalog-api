using FaultCatalogAPI.Data;
using FaultCatalogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaultCatalogAPI.Services
{
    public class SuccessCriterionService : ISuccessCriterionService
    {
        public readonly DataContext _context;

        public SuccessCriterionService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuccessCriterion>> GetAllSuccessCriterions()
        {
            var successCriterions = await _context.SuccessCriterions.ToListAsync();
            return successCriterions;
        }

        public async Task<SuccessCriterion?> GetSuccessCriterion(string id)
        {
            var successCriterion = await _context.SuccessCriterions.FindAsync(id);
            if (successCriterion == null)
            {
                return null;
            }

            return successCriterion;
        }
    }
}
