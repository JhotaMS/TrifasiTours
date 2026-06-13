using TrifasiTours.Application.Messaging;
using System.ComponentModel.DataAnnotations;

namespace TrifasiTours.Application.Features.Users.CreateUser;
public record UserCommand(
<<<<<<< HEAD
    [Required] string Nombre
    , [Required] int Edad
    , [Required] string Documento
    , [Required] string Correo
    , [Required] DateTime FechaNacimiento
    , [Required] string Rol
=======
    [Required] string FirstName
    , string? SecondName
    , [Required] string SurName
    , string? SecondSurName
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
    ) : ICommand<UserCommandResponse>;
