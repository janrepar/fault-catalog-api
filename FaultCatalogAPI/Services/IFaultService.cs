using FaultCatalogAPI.Models;

namespace FaultCatalogAPI.Services
{
    public interface IFaultService
    {
        List<Fault> GetAllFaults();
        Fault GetFault(long id);
        List<Fault> AddFault(Fault fault);
        List<Fault> UpdateFault(Fault fault);
        List<Fault> DeleteFault(long id);
    }
}
 