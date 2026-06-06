using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrifasiTours.Domain.Tours;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrifasiTours.Infrastructure.PostgreSql.Configurations;

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
    }
}
