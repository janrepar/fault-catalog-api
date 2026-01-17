using Microsoft.AspNetCore.Mvc;

namespace FaultCatalogAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class HealthController : Controller
    {
        [HttpGet("health")]
        public IActionResult GetHealth() => Ok("Healthy");

        [HttpGet("liveness")]
        public IActionResult GetLiveness() => Ok("Live");
    }  
}
