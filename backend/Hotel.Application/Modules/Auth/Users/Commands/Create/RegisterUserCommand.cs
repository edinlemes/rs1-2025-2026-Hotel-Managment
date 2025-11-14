namespace Hotel.Application.Modules.Auth.Users.Commands.Create;

public sealed class RegisterUserCommand : IRequest<RegisterUserCommandDto>
{
    public string Username { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
}