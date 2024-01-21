using FaultCatalogAPI.Models;
using FaultCatalogAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaultCatalogAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SuccessCriterionController : ControllerBase
    {
        private readonly ISuccessCriterionService _successCriterionService;

        public SuccessCriterionController(ISuccessCriterionService successCriterionService)
        {
            _successCriterionService = successCriterionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuccessCriterion>>> GetAllSuccessCriteria()
        {
            return await _successCriterionService.GetAllSuccessCriteria();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuccessCriterion>> GetSuccessCriterion(string id)
        {
            var successCriterion = await _successCriterionService.GetSuccessCriterion(id);
            if (successCriterion == null)
            {
                return NotFound("Success Criterion not found.");
            }

            return Ok(successCriterion);
        }
    }
}
