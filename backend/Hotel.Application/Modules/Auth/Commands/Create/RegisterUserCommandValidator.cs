using Hotel.Application.Modules.Auth.Commands.Login;

namespace Hotel.Application.Modules.Auth.Commands.Create;

/// <summary>
/// FluentValidation validator for <see cref="RegisterUserCommand"/>.
/// </summary>
public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(5).WithMessage("Password must be at least 6 characters long.");

        RuleFor(x => x.FirstName)
          .NotEmpty().WithMessage("Firstname is required.");

        RuleFor(x => x.LastName)
          .NotEmpty().WithMessage("Lastname is required.");
    }
}