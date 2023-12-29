using FaultCatalogAPI.Models;

namespace FaultCatalogAPI.Services
{
    public interface IFaultSuccessCriterionService
    {
        Task<List<FaultSuccessCriterion>> GetAllFaultsSuccessCriteria();
        Task<List<Fault>?> GetFaultsBySuccessCriterionRefId(string refId);
        Task<List<SuccessCriterion>?> GetSuccessCriteriaByFaultId(long id);
        Task<List<Fault>> AddFault(Fault fault);
        Task<List<Fault>?> UpdateFaultSuccessCriteria(Fault fault);
    }
}
