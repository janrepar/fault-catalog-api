
using FaultCatalogAPI.Data;
using FaultCatalogAPI.Models;

namespace FaultCatalogAPI.Services
{
    public class FaultService : IFaultService
    {
        public readonly DataContext _context;

        public FaultService(DataContext context)
        {
            _context = context;
        }

        public List<Fault> AddFault(Fault fault)
        {
            throw new NotImplementedException();
        }

        public List<Fault> DeleteFault(long id)
        {
            throw new NotImplementedException();
        }

        public List<Fault> GetAllFaults()
        {
            throw new NotImplementedException();
        }

        public Fault GetFault(long id)
        {
            throw new NotImplementedException();
        }

        public List<Fault> UpdateFault(Fault fault)
        {
            throw new NotImplementedException();
        }
    }
}
