using Hotel.Application.Modules.Auth.Commands.Login;
using Hotel.Application.Modules.Auth.Roles.Commands.Create;
using Hotel.Domain.Entities.Users;

namespace Hotel.Application.Modules.Auth.Commands.Create;

public sealed class RegisterUserCommandHandler(
    IAppDbContext ctx,
    IPasswordHasher<UsersEntity> hasher)
    : IRequestHandler<RegisterUserCommand, RegisterUserCommandDto>
{
    public async Task<RegisterUserCommandDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var exists = await ctx.UserTable
            .AnyAsync(x => x.Username == request.Username || x.Email == request.Email);

        if (exists)
            throw new Exception("User already exists");

        var user = new UsersEntity
        {
            Username = request.Username,
            Email = request.Email,
            Active = true,
            CreatedAtUtc = DateTime.UtcNow,
        };

        user.Password = hasher.HashPassword(user, request.Password);

        ctx.UserTable.Add(user);
        await ctx.SaveChangesAsync(cancellationToken);

        var person = new PersonsEntity
        {
            UserId = user.Id,
            FirstName = "",
            LastName = "",
            MailAddress = request.Email,
            CreatedAtUtc = DateTime.UtcNow,
        };
        ctx.Persons.Add(person);
        await ctx.SaveChangesAsync(cancellationToken);

        // OPTIONAL: dodaj defaultnu rolu USER
        var defaultRole = await ctx.Roles.FirstOrDefaultAsync(x => x.RoleName == "User", cancellationToken);
        if (defaultRole != null)
        {   
            ctx.UserRoles.Add(new UserRolesEntity
            {
                UserId = user.Id,
                RoleId = defaultRole.Id,
                AssignedDate = DateTime.UtcNow,
                Active = true
            });
                await ctx.SaveChangesAsync(cancellationToken);
        }

        return new RegisterUserCommandDto
        {
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email
        };
    }
}