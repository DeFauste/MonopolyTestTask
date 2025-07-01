using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Warehouse.Database.InMemory.Entities;

namespace Warehouse.Database.InMemory.Data.Configurations
{
    public class PalleteConfiguration : IEntityTypeConfiguration<PalletEntity>
    {
        public void Configure(EntityTypeBuilder<PalletEntity> builder)
        {
            builder.HasKey(p => p.ID);
            builder
                .HasMany(p => p.Boxes)
                .WithOne(b => b.Pallete)
                .HasForeignKey(k => k.PalleteId);
        }
    }
}
