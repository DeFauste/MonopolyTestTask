using Microsoft.EntityFrameworkCore;
using Warehouse.Database.InMemory.Data.Configurations;
using Warehouse.Database.InMemory.Entities;

namespace Warehouse.Database.InMemory.Data
{
    public class AppDbInMemoryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDatabase");
        }
        public DbSet<BoxEntity> Boxes { get; set; }
        public DbSet<PalletEntity> Pallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoxConfiguration());
            modelBuilder.ApplyConfiguration(new PalleteConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
