namespace Hotel.Application.Modules.Auth.Queries.GetById;

/// <summary>
/// FluentValidation validator for <see cref="UserGetByIdQueryValidator"/>.
/// </summary>
public sealed class UserGetByIdQueryValidator : AbstractValidator<UserGetByIdQuery>
{
    public UserGetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

    }
}