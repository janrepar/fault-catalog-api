using FaultCatalogAPI.Data;
using FaultCatalogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FaultCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataContext _context;

        public DataController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("process-data")]
        public IActionResult ProcessData()
        {
            var jsonData = System.IO.File.ReadAllText("wcag.json");
            var successCriteriaList = JsonConvert.DeserializeObject<List<SuccessCriterion>>(jsonData);

            _context.SuccessCriteria.AddRange(successCriteriaList);
            _context.SaveChanges();

            return Ok("Success criteria data has been inserted into the database.");
        }
    }
}
