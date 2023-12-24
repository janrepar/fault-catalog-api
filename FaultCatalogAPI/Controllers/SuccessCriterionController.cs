using FaultCatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaultCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuccessCriterionController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuccessCriterion>>> GetAllSuccessCriteria()
        {

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuccessCriterion>> GetSuccessCriterion(string id)
        {

        }
    }
}
