using FaultCatalogAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace FaultCatalogAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        // Method to configure join entity type for many to many relationship with navigations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fault>()
                .HasMany(e => e.SuccessCriteria)
                .WithMany(e => e.Faults)
                .UsingEntity<FaultSuccessCriterion>(
                    l => l.HasOne<SuccessCriterion>().WithMany().HasForeignKey(e => e.SuccessCriterionRefId),
                    r => r.HasOne<Fault>().WithMany().HasForeignKey(e => e.FaultId));
        }

        public DbSet<Fault> Faults { get; set; }

        public DbSet<SuccessCriterion> SuccessCriteria { get; set; }

        public DbSet<FaultSuccessCriterion> FaultsSuccessCriteria { get; set; }
    }
}
