using System.Text.Json.Serialization;

namespace FaultCatalogAPI.Models
{
    public class Fault
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        // Basic many to many (relationship is mapped by convention in Entity Framework)
        public List<SuccessCriterion> SuccessCriteria { get; set; } = new();
    }
}
