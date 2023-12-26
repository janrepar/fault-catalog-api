using FaultCatalogAPI.Models;

namespace FaultCatalogAPI.Services
{
    public interface ISuccessCriterionService
    {
        Task<List<SuccessCriterion>> GetAllSuccessCriterions();
        Task<SuccessCriterion?> GetSuccessCriterion(string id);
    }
}
