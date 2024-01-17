
using FaultCatalogAPI.Data;
using FaultCatalogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaultCatalogAPI.Services
{
    public class FaultService : IFaultService
    {
        public readonly DataContext _context;

        public FaultService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Fault>?> DeleteFault(long id)
        {
            var fault = await _context.Faults.FindAsync(id);
            if (fault == null)
            {
                return null;
            }

            _context.Faults.Remove(fault);
            await _context.SaveChangesAsync();

            return await _context.Faults.ToListAsync();
        }

        public async Task<List<Fault>> GetAllFaults()
        {
            var faults = await _context.Faults.ToListAsync();
            return faults;
        }

        public async Task<Fault?> GetFault(long id)
        {
            var fault = await _context.Faults.FindAsync(id);
            if (fault == null)
            {
                return null;
            }

            return fault;
        }
    }
}
