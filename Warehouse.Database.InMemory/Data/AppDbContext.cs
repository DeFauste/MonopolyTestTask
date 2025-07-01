using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Database.InMemory.Entities;

namespace Warehouse.Database.InMemory.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDatabase");
        }
        public DbSet<BoxEntity> Boxes { get; set; }
        public DbSet<PalletEntity> Pallets { get; set; }
    }
}
