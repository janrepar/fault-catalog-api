using FaultCatalogAPI.Data;
using FaultCatalogAPI.Models;

namespace FaultCatalogAPI.Services
{
    public class SuccessCriterionService : ISuccessCriterionService
    {
        public readonly DataContext _context;

        public SuccessCriterionService(DataContext context)
        {
            _context = context;
        }

        public List<SuccessCriterion> GetAllSuccessCriteria()
        {
            throw new NotImplementedException();
        }

        public SuccessCriterion GetSuccessCriterion(string id)
        {
            throw new NotImplementedException();
        }
    }
}
