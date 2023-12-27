using FaultCatalogAPI.Models;

namespace FaultCatalogAPI.Services
{
    public interface ISuccessCriterionService
    {
        Task<List<SuccessCriterion>> GetAllSuccessCriteria();
        Task<SuccessCriterion?> GetSuccessCriterion(string id);
    }
}
