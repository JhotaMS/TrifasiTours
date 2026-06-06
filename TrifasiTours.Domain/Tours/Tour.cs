using System;
using TrifasiTours.Domain.Abstractions;

namespace TrifasiTours.Domain.Tours;

public class Tour : Entity<Guid>
{
    private Tour(
        string name,
        string tipoTour,
        string municipio,
        string dificultad,
        decimal valorTour,
        Guid guiaAsignadoId,
        string requisitos
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        TipoTour = tipoTour;
        Municipio = municipio;
        Dificultad = dificultad;
        ValorTour = valorTour;
        GuiaAsignadoId = guiaAsignadoId;
        Requisitos = requisitos;
        Enabled = true;
    }

    public string Name { get; private set; } = default!;
    public string TipoTour { get; private set; } = default!;
    public string Municipio { get; private set; } = default!;
    public string Dificultad { get; private set; } = default!;
    public decimal ValorTour { get; private set; }
    public Guid GuiaAsignadoId { get; private set; }
    public string Requisitos { get; private set; } = default!;
    public bool Enabled { get; private set; }

    public static Tour Create(
        string name,
        string tipoTour,
        string municipio,
        string dificultad,
        decimal valorTour,
        Guid guiaAsignadoId,
        string requisitos
    ) => new(
        name,
        tipoTour,
        municipio,
        dificultad,
        valorTour,
        guiaAsignadoId,
        requisitos
    );
}
