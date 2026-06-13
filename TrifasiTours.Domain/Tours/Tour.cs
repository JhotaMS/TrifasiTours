using TrifasiTours.Domain.Abstractions;
using TrifasiTours.Domain.Users;

namespace TrifasiTours.Domain.Tours;
public class Tour : Entity<Guid> {
    private Tour(
        string nombreTour,
        string tipoTour,
        string municipio,
        string codigo,
        string dificultad,
        string requisitos,
        decimal valorTour,
        Guid guiaTuristicoId
    ) {
        Id = Guid.NewGuid();
        NombreTour = nombreTour;
        TipoTour = tipoTour;
        Municipio = municipio;
        Codigo = codigo;
        Dificultad = dificultad;
        Requisitos = requisitos;
        ValorTour = valorTour;
        GuiaTuristicoId = guiaTuristicoId;
    }

    public string NombreTour { get; private set; } = default!;
    public string TipoTour { get; private set; } = default!;
    public string Municipio { get; private set; } = default!;
    public string Codigo { get; private set; } = default!;
    public string Dificultad { get; private set; } = default!;
    public string Requisitos { get; private set; } = default!;
    public decimal ValorTour { get; private set; }
    public Guid GuiaTuristicoId { get; private set; }
    public User? GuiaTuristico { get; private set; }

    public static Tour Create(
        string nombreTour,
        string tipoTour,
        string municipio,
        string codigo,
        string dificultad,
        string requisitos,
        decimal valorTour,
        Guid guiaTuristicoId
    ) => new(
        nombreTour,
        tipoTour,
        municipio,
        codigo,
        dificultad,
        requisitos,
        valorTour,
        guiaTuristicoId
    );
}
