using FaultCatalogAPI.Models;

namespace FaultCatalogAPI.Services
{
    public interface IFaultService
    {
        Task<List<Fault>> GetAllFaults();
        Task<Fault?> GetFault(long id);
        Task<List<Fault>> AddFault(Fault fault);
        Task<List<Fault>?> UpdateFault(Fault fault);
        Task<List<Fault>?> DeleteFault(long id);
    }
}
 