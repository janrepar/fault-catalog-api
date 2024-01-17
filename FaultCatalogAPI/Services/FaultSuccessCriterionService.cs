using FaultCatalogAPI.Data;
using FaultCatalogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaultCatalogAPI.Services
{
    public class FaultSuccessCriterionService : IFaultSuccessCriterionService
    {
        public readonly DataContext _context;

        public FaultSuccessCriterionService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Fault>> AddFault(Fault fault)
        {
            var selectedSuccessCriterionRefIds = fault.SuccessCriterionRefIds;

            foreach (var idReference in selectedSuccessCriterionRefIds)
            {
                var successCriterionRequest = await _context.SuccessCriteria.FindAsync(idReference);
                if (successCriterionRequest == null)
                {
                    return null;
                }
            }

            var faultSuccessCriteria = new List<FaultSuccessCriterion>();

            _context.Add(fault);
            await _context.SaveChangesAsync();

            foreach (var refId in selectedSuccessCriterionRefIds)
            {
                var item = new FaultSuccessCriterion()
                {
                    FaultId = fault.Id,
                    SuccessCriterionRefId = refId
                };
                faultSuccessCriteria.Add(item);
            }

            _context.AddRange(faultSuccessCriteria);
            await _context.SaveChangesAsync();

            return await _context.Faults.ToListAsync();
        }

        public async Task<List<Fault>?> UpdateFaultSuccessCriteria(Fault fault)
        {
            var faultToUpdate = await _context.Faults.FindAsync(fault.Id);
            if (faultToUpdate == null)
            {
                return null;
            }

            // Updating fault item
            faultToUpdate.Title = fault.Title;
            faultToUpdate.Description = fault.Description;
            faultToUpdate.ShortDescription = fault.ShortDescription;

            var selectedSuccessCriterionRefIds = fault.SuccessCriterionRefIds;

            // Check if success criterion exists
            foreach (var idReference in selectedSuccessCriterionRefIds)
            {
                var successCriterionRequest = await _context.SuccessCriteria.FindAsync(idReference);
                if (successCriterionRequest == null)
                {
                    return null;
                }
            }

            fault.SuccessCriterionRefIds.Clear();

            await _context.SaveChangesAsync();

            faultToUpdate.SuccessCriterionRefIds = selectedSuccessCriterionRefIds;

            var faultSuccessCriteria = new List<FaultSuccessCriterion>();

            // Remove all faults with that id from assocciation table (FaultSuccessCriteria)
            var fscList = await _context.FaultsSuccessCriteria.Where(fsc => fsc.FaultId == fault.Id).ToListAsync();
            _context.RemoveRange(fscList);

            // Updating references to success criteria
            foreach (var refId in selectedSuccessCriterionRefIds)
            {
                var item = new FaultSuccessCriterion()
                {
                    FaultId = fault.Id,
                    SuccessCriterionRefId = refId
                };
                faultSuccessCriteria.Add(item);
            }
            _context.AddRange(faultSuccessCriteria);

            await _context.SaveChangesAsync();

            return await _context.Faults.ToListAsync();
        }

        public async Task<List<FaultSuccessCriterion>> GetAllFaultsSuccessCriteria()
        {
            var result = await _context.FaultsSuccessCriteria.ToListAsync();
            return result;
        }

        public async Task<List<Fault>?> GetFaultsBySuccessCriterionRefId(string refId)
        {
            var successCriterionRequest = await _context.SuccessCriteria.FindAsync(refId);
            if (successCriterionRequest == null)
            {
                return null;
            }

            var fscList = await _context.FaultsSuccessCriteria.Where(fsc => fsc.SuccessCriterionRefId == refId).ToListAsync();

            var faultIdList = new List<long>();
            var faults = new List<Fault>();

            // Get all FaultIds
            foreach (var fsc in fscList)
            {
                faultIdList.Add(fsc.FaultId);
            }

            // Get Faults by FaultIds
            foreach (var faultId in faultIdList)
            {
                var fault = await _context.Faults.FindAsync(faultId);
                if (fault == null)
                {
                    return null;
                }

                faults.Add(fault);
            }

            return faults;
        }

        public async Task<List<SuccessCriterion>?> GetSuccessCriteriaByFaultId(long id)
        {
            var faultRequest = await _context.Faults.FindAsync(id);
            if (faultRequest == null)
            {
                return null;
            }

            var fList = await _context.FaultsSuccessCriteria.Where(f => f.FaultId == id).ToListAsync();

            var successCriteriaIdList = new List<string>();
            var successCriteria = new List<SuccessCriterion>();

            // Get all SuccessCriteriaIds
            foreach (var f in fList)
            {
                successCriteriaIdList.Add(f.SuccessCriterionRefId);
            }

            // Get SuccessCriteria by SuccessCriteriaIds
            foreach (var successCriterionId in successCriteriaIdList)
            {
                var successCriterion = await _context.SuccessCriteria.FindAsync(successCriterionId);
                if (successCriterion == null)
                {
                    return null;
                }

                successCriteria.Add(successCriterion);
            }

            return successCriteria;
        }
    }
}
