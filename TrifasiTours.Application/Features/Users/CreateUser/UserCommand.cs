using TrifasiTours.Application.Messaging;
using System.ComponentModel.DataAnnotations;

namespace TrifasiTours.Application.Features.Users.CreateUser;
public record UserCommand(
    [Required] string FirstName,
    string? SecondName,
    [Required] string SurName,
    string? SecondSurName,
    [Required][Range(0, 150)] int Age,
    [Required][EmailAddress] string Email,
    [Required][MinLength(8)] string Password,
    [Required] string Document,
    [Required] string Role,
    bool Enabled = true
    ) : ICommand<UserCommandResponse>;
