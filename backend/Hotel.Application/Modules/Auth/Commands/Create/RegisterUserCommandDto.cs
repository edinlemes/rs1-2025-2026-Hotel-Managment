namespace Hotel.Application.Modules.Auth.Commands.Create;

public sealed class RegisterUserCommandDto
{

    public int UserId { get; init; }
    public string Email { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Address { get; init; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string Password { get; init; } = null!;
}
