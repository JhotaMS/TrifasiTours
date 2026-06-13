using TrifasiTours.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrifasiTours.Infrastructure.PostgreSql.Configurations;
internal sealed class UserConfiguration
    : IEntityTypeConfiguration<User> {
    public void Configure( EntityTypeBuilder<User> builder ) {
        builder.ToTable( "Usuarios" );
        builder.HasKey( key => key.Id );
        builder.Property( property => property.Nombre ).IsRequired( true );
        builder.Property( property => property.Edad ).IsRequired( true );
        builder.Property( property => property.Documento ).IsRequired( true );
        builder.Property( property => property.Correo ).IsRequired( true );

        builder.Property( property => property.FechaNacimiento )
            .HasConversion(
                fecha => fecha,
                fecha => fecha
            )
            .HasColumnType( "date" )
            .IsRequired( true );

        builder.Property( property => property.Rol ).IsRequired( true );
        builder.Property( property => property.Enabled );
    }
}
