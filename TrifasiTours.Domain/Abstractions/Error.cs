namespace TrifasiTours.Domain.Abstractions;

public record Error(string Code, string Name)
{
    public static Error None = new(string.Empty, string.Empty);
    public static Error NullValue = new("Error.NullValue", "Un valor Null fue ingresado");
    public static Error DuplicateEmail = new("Error.DuplicateEmail", "El email ya existe");
    public static Error DuplicateDocument = new("Error.DuplicateDocument", "El documento ya existe");
    public static Error Validation = new("Error.Validation", "Error de validación");
}