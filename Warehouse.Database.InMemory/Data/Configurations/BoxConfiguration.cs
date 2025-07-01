using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Warehouse.Database.InMemory.Entities;

namespace Warehouse.Database.InMemory.Data.Configurations
{
    public class BoxConfiguration : IEntityTypeConfiguration<BoxEntity>
    {
        public void Configure(EntityTypeBuilder<BoxEntity> builder)
        {
            builder.HasKey(b => b.ID);
            builder
                .HasOne(b => b.Pallete)
                .WithOne();
        }
    }
}
