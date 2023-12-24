using FaultCatalogAPI.Models;

namespace FaultCatalogAPI.Services
{
    public interface ISuccessCriterionService
    {
        List<SuccessCriterion> GetAllSuccessCriteria();
        SuccessCriterion GetSuccessCriterion(string id);
    }
}
