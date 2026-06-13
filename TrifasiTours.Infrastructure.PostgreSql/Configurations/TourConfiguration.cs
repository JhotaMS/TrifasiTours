<<<<<<< HEAD
﻿using TrifasiTours.Domain.Tours;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrifasiTours.Domain.Tours;
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrifasiTours.Infrastructure.PostgreSql.Configurations;
<<<<<<< HEAD
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
=======

internal sealed class TourConfiguration : IEntityTypeConfiguration<Tour>
{
    public void Configure(EntityTypeBuilder<Tour> builder)
    {
        builder.ToTable("Tours");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnType("text")
            .HasMaxLength(100);

        builder.Property(t => t.TipoTour)
            .IsRequired()
            .HasColumnType("text")
            .HasMaxLength(500);

        builder.Property(t => t.Municipio)
            .IsRequired()
            .HasColumnType("text")
            .HasMaxLength(500);

        builder.Property(t => t.Dificultad)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(t => t.ValorTour)
            .IsRequired()
            .HasColumnType("numeric");

        builder.Property(t => t.GuiaAsignadoId)
            .IsRequired()
            .HasColumnType("uuid");

        builder.Property(t => t.Requisitos)
            .IsRequired()
            .HasColumnType("text")
            .HasMaxLength(500);

        builder.Property(t => t.Enabled)
            .IsRequired()
            .HasColumnType("boolean")
            .HasDefaultValue(true);
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
    }
}
