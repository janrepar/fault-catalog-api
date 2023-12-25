using FaultCatalogAPI.Models;
using FaultCatalogAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaultCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultController : ControllerBase
    {
        private readonly IFaultService _faultservice;

        public FaultController(IFaultService faultService) 
        {
            _faultservice = faultService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fault>>> GetAllFaults()
        {
            return _faultservice.GetAllFaults();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fault>> GetFault(long id)
        {
            return _faultservice.GetFault(id);
        }

        [HttpPost]
        public async Task<ActionResult<List<Fault>>> AddFault(Fault fault)
        {
            // todo
        }

        [HttpPut]
        public async Task<ActionResult<List<Fault>>> UpdateFault(Fault fault)
        {
            var result = _faultservice.UpdateFault(fault);
            if (result == null)
            {
                return NotFound("Fault not found.");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Fault>>> DeleteFault(long id)
        {
            var result = _faultservice.DeleteFault(id);
            if (result == null)
            {
                return NotFound("Fault not found.");
            }

            return Ok(result);
        }
    }
}
