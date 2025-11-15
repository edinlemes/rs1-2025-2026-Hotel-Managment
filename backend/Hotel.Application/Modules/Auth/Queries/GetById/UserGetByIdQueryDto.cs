using Hotel.Domain.Entities.Users;

namespace Hotel.Application.Modules.Auth.Queries.GetById;

public sealed class UserGetByIdQueryDto
{
    public required int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public RolesDto Role { get; set; } = new RolesDto();
}
public sealed class RolesDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
}
