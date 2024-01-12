﻿
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

        public async Task<List<Fault>?> UpdateFault(Fault fault)
        {
            var faultToUpdate = await _context.Faults.FindAsync(fault.Id);
            if (faultToUpdate == null)
            {
                return null;
            }

            faultToUpdate.Title = fault.Title;
            faultToUpdate.Description = fault.Description;
            faultToUpdate.ShortDescription = fault.ShortDescription;
            faultToUpdate.SuccessCriterionRefIds = faultToUpdate.SuccessCriterionRefIds;

            await _context.SaveChangesAsync();

            return await _context.Faults.ToListAsync();
        }
    }
}
