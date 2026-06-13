using TrifasiTours.Domain.Abstractions;

namespace TrifasiTours.Domain.Users;

public class User : Entity<Guid> {
    private User(
        string firstName,
        string? secondName,
        int age,
        string email,
        string password,
        string document,
        string role,
        bool enabled
    ) {
        FirstName = firstName;
        SecondName = secondName;
        Age = age;
        Email = email;
        Password = password;
        Document = document;
        Role = role;
        Enabled = enabled;
    }

    public string FirstName { get; private set; } = default!;
    public string? SecondName { get; private set; }
    public int Age { get; private set; }
    public string Email { get; private set; } = default!;
    public string Password { get; private set; } = default!;
    public string Document { get; private set; } = default!;
    public string Role { get; private set; } = default!;
    public bool Enabled { get; private set; }

    public static User Create(
        string firstName,
        string? secondName,
        int age,
        string email,
        string password,
        string document,
        string role,
        bool enabled = true
    ) {
        if (string.IsNullOrWhiteSpace( email ))
            throw new ArgumentException( "Email es requerido", nameof( email ) );

        if (string.IsNullOrWhiteSpace( document ))
            throw new ArgumentException( "Documento es requerido", nameof( document ) );

        if (string.IsNullOrWhiteSpace( role ))
            throw new ArgumentException( "Rol es requerido", nameof( role ) );

        return new(
            firstName,
            secondName,
            age,
            email,
            password,
            document,
            role,
            enabled
        );
    }
}
