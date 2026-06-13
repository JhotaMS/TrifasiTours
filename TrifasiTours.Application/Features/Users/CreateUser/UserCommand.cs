using TrifasiTours.Application.Messaging;
using System.ComponentModel.DataAnnotations;

namespace TrifasiTours.Application.Features.Users.CreateUser;
public record UserCommand(
    [Required] string Nombre
    , [Required] int Edad
    , [Required] string Documento
    , [Required] string Correo
    , [Required] DateTime FechaNacimiento
    , [Required] string Rol
    ) : ICommand<UserCommandResponse>;
