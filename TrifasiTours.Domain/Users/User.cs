using TrifasiTours.Domain.Abstractions;

namespace TrifasiTours.Domain.Users;
public class User : Entity<Guid> {
<<<<<<< HEAD
    public User() {
        
    }
    private User(
        string nombre,
        int edad,
        string documento,
        string correo,
        DateTime fechaNacimiento,
        string rol
    ) {
        Id = Guid.NewGuid();
        Nombre = nombre;
        Edad = edad;
        Documento = documento;
        Correo = correo;
        FechaNacimiento = fechaNacimiento;
        Rol = rol;
    }

    public string Nombre { get; private set; } = default!;
    public int Edad { get; private set; }
    public string Documento { get; private set; } = default!;
    public string Correo { get; private set; } = default!;
    public DateTime FechaNacimiento { get; private set; }
    public string Rol { get; private set; } = default!;

    public static User Create(
        string nombre,
        int edad,
        string documento,
        string correo,
        DateTime fechaNacimiento,
        string rol
    ) => new(
        nombre,
        edad,
        documento,
        correo,
        fechaNacimiento,
        rol
=======
    private User(
        string firstName,
        string? secondName,
        string surName,
        string? secondSurName
    ) {
        FirstName = firstName;
        SecondName = secondName;
        SurName = surName;
        SecondSurName = secondSurName;
    }

    public string FirstName { get; private set; } = default!;
    public string? SecondName { get; private set; }
    public string SurName { get; private set; } = default!;
    public string? SecondSurName { get; private set; }

    public static User Create(
        string firstName,
        string? secondName,
        string surName,
        string? secondSurname
    ) => new(
        firstName,
        secondName,
        surName,
        secondSurname
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
    );
}
