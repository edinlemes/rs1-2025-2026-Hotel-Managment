namespace Hotel.Application.Modules.Auth.Roles.Commands.Create;

/// <summary>
/// FluentValidation validator for <see cref="CreateRoleCommand"/>.
/// </summary>
public sealed class CreateRolesCommandValidator : AbstractValidator<CreateRolesCommand>
{
    public CreateRolesCommandValidator()
    {
        RuleFor(x => x.RoleName)
            .NotEmpty().WithMessage("Rolename is required.");
    }
}