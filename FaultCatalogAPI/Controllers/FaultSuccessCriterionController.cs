using FaultCatalogAPI.Models;
using FaultCatalogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FaultCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultSuccessCriterionController : ControllerBase
    {
        private readonly IFaultSuccessCriterionService _faultSuccessCriterionService;

        public FaultSuccessCriterionController(IFaultSuccessCriterionService faultSuccessCriterionService)
        {
            _faultSuccessCriterionService = faultSuccessCriterionService;
        }

        [HttpPost]
        public async Task<ActionResult<List<Fault>>> AddFault(Fault fault)
        {
            var result = await _faultSuccessCriterionService.AddFault(fault);
            if (result == null)
            {
                return NotFound("Success Criterion does not exist.");
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Fault>>> UpdateFaultSuccessCriteria(Fault fault)
        {
            var result = await _faultSuccessCriterionService.UpdateFault(fault);
            if (result == null)
            {
                return NotFound("Fault not found or success criteria doesn't exist.");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<FaultSuccessCriterion>>> GetAllFaultsSuccessCriteria()
        {
            return await _faultSuccessCriterionService.GetAllFaultsSuccessCriteria();
        }

        [HttpGet("GetFaultsBySuccessCriterionRefId/{refId}")]
        public async Task<ActionResult<List<Fault>>> GetFaultsBySuccessCriterionRefId(string refId)
        {
            var result = await _faultSuccessCriterionService.GetFaultsBySuccessCriterionRefId(refId);
            if (result == null)
            {
                return NotFound("Faults not found or success criteria doesn't exist.");
            }

            return Ok(result);
        }

        [HttpGet("GetSuccessCriteriaByFaultId/{id}")]
        public async Task<ActionResult<List<Fault>>> GetSuccessCriteriaByFaultId(long id)
        {
            var result = await _faultSuccessCriterionService.GetSuccessCriteriaByFaultId(id);
            if (result == null)
            {
                return NotFound("Success Criteria not found or Fault doesn't exist.");
            }

            return Ok(result);
        }
    }
}
