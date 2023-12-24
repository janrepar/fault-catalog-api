using FaultCatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaultCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Fault>>> GetAllFaults()
        {

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fault>> GetFault(long id)
        {

        }

        [HttpPost]
        public async Task<ActionResult<List<Fault>>> AddFault(Fault fault)
        {

        }

        [HttpPut]
        public async Task<ActionResult<List<Fault>>> UpdateFault(Fault fault)
        {

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Fault>>> DeleteFault(long id)
        {

        }
    }
}
