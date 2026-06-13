using TrifasiTours.Domain.Tours;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrifasiTours.Infrastructure.PostgreSql.Configurations;
internal sealed class TourConfiguration
    : IEntityTypeConfiguration<Tour> {
    public void Configure( EntityTypeBuilder<Tour> builder ) {
        builder.ToTable( "Tours" );
        builder.HasKey( key => key.Id );
        builder.Property( property => property.NombreTour ).IsRequired( true );
        builder.Property( property => property.TipoTour ).IsRequired( true );
        builder.Property( property => property.Municipio ).IsRequired( true );
        builder.Property( property => property.Codigo ).IsRequired( true );
        builder.Property( property => property.Dificultad ).IsRequired( true );
        builder.Property( property => property.Requisitos ).IsRequired( true );
        builder.Property( property => property.ValorTour )
            .HasColumnType( "decimal(18,2)" )
            .IsRequired( true );
        builder.Property( property => property.Enabled );

        builder.HasOne( tour => tour.GuiaTuristico )
            .WithMany()
            .HasForeignKey( tour => tour.GuiaTuristicoId )
            .OnDelete( DeleteBehavior.Restrict );
    }
}
