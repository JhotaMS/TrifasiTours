using TrifasiTours.Domain.Packages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrifasiTours.Infrastructure.PostgreSql.Configurations;
internal sealed class PackageConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {
        builder.ToTable("Packages");
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Name).IsRequired(true).HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired(true).HasMaxLength(500);
        builder.Property(p => p.Type).IsRequired(true);
        builder.Property(p => p.Price).IsRequired(true);
        builder.Property(p => p.Duration).IsRequired(true);
        builder.Property(p => p.Benefits).IsRequired(false).HasMaxLength(500);
        builder.Property(p => p.Destination).IsRequired(true);
        builder.Property(p => p.MaxCapacity).IsRequired(false);
        builder.Property(p => p.AvailableDate).IsRequired(true);
    }
}
