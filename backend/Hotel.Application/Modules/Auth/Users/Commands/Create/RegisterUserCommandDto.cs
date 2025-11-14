namespace Hotel.Application.Modules.Auth.Users.Commands.Create;

public sealed class RegisterUserCommandDto
{

    public int UserId { get; init; }
    public string Username { get; init; } = null!;
    public string Email { get; init; } = null!;
}
