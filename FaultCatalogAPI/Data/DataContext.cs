using FaultCatalogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FaultCatalogAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=faultcatalogdb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Fault> Faults { get; set; }

        public DbSet<SuccessCriterion> SuccessCriteria { get; set; }
    }
}
