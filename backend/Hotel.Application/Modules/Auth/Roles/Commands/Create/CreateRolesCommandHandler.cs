using Hotel.Domain.Entities.Users;

namespace Hotel.Application.Modules.Auth.Roles.Commands.Create;

public class CreateRolesCommandHandler(IAppDbContext dbContext) 
    : IRequestHandler<CreateRolesCommand, int>
{
    public async Task<int> Handle(CreateRolesCommand request, CancellationToken cancellationToken)
    {
        var normalised = request.RoleName?.Trim();

        if (string.IsNullOrWhiteSpace(normalised))
        {
            throw new ValidationException("Role name cannot be empty.");
        }
        bool roleExists = await dbContext.Roles
            .AnyAsync(r => r.RoleName.ToLower() == normalised.ToLower() && !r.IsDeleted, cancellationToken);

        if (roleExists)
        {
            throw new ValidationException($"Role with name '{normalised}' already exists.");
        }

        var roleEntity = new RolesEntity
        {
            RoleName = request.RoleName!,
            Description = request.Description,
            Active = true,
            CreatedAtUtc = DateTime.UtcNow,
            IsDeleted = false
        };

        dbContext.Roles.Add(roleEntity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return roleEntity.Id;
    }
}
