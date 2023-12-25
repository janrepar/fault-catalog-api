using System.ComponentModel.DataAnnotations;

namespace FaultCatalogAPI.Models
{
    public class SuccessCriterion
    {
        [Key] // set string RefId as primary key (ef core doesn't do it automatically, because field is of type string)
        public string RefId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Level { get; set; }

        // Basic many to many (relationship is mapped by convention in Entity Framework)
        public List<Fault> Faults { get; set; } = new();
    }
}
