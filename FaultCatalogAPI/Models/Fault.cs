﻿using System.Text.Json.Serialization;

namespace FaultCatalogAPI.Models
{
    public class Fault
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public List<string> SuccessCriterionRefIds { get; set; }

        // Basic many to many (relationship is mapped by convention in Entity Framework)
        [JsonIgnore]
        public List<SuccessCriterion> SuccessCriteria { get; set; } = new();
        // Navigations to join entity
        [JsonIgnore]
        public List<FaultSuccessCriterion> FaultSuccessCriteria { get; set; } = new();
    }
}
