using FaultCatalogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaultCatalogAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Fault> Faults { get; set; }

        public DbSet<SuccessCriterion> SuccessCriteria { get; set; }
    }
}
