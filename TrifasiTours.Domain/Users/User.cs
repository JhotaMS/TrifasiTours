using TrifasiTours.Domain.Abstractions;

namespace TrifasiTours.Domain.Users;
public class User : Entity<Guid> {
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
    );
}
