using TrifasiTours.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrifasiTours.Infrastructure.PostgreSql.Configurations;
internal sealed class UserConfiguration
    : IEntityTypeConfiguration<User> {
    public void Configure( EntityTypeBuilder<User> builder ) {
        builder.ToTable( "Users" );
        builder.HasKey( key => key.Id );
        builder.Property( property => property.FirstName ).IsRequired( true );
        builder.Property( property => property.SecondName ).IsRequired( false );
        builder.Property( property => property.SurName ).IsRequired( true );
        builder.Property( property => property.SecondSurName ).IsRequired( false );
        builder.Property( property => property.Enabled );
        builder.Property( property => property.Age ).IsRequired( true );
        builder.Property( property => property.Email ).IsRequired( true );
        builder.Property( property => property.Password ).IsRequired( true );
        builder.Property( property => property.Document ).IsRequired( true );
        builder.Property( property => property.Role ).IsRequired( true );
    }
}
