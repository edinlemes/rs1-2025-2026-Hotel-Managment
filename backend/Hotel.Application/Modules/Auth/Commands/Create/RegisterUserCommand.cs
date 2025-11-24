namespace Hotel.Application.Modules.Auth.Commands.Create;

public sealed class RegisterUserCommand : IRequest<RegisterUserCommandDto>
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;  
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
}