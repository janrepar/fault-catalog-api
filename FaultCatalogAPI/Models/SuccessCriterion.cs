using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FaultCatalogAPI.Models
{
    [Table("SuccessCriteria")]
    public class SuccessCriterion
    {
        [Key] // set string RefId as primary key (ef core doesn't do it automatically, because field is of type string)
        [Required]
        [JsonProperty(PropertyName = "Ref_id")]
        public string RefId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? URL { get; set; }
        public string? Level { get; set; }

        // Basic many to many (relationship is mapped by convention in Entity Framework)
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Fault> Faults { get; set; } = new();
    }
}
