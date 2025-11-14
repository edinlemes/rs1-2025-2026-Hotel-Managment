namespace Hotel.Application.Modules.Auth.Roles.Querries.GetList;

public sealed class ListRolesQueryDto
{
    public required int Id { get; set; }
    public required string RoleName { get; set; }
    public required bool IsActive { get; set; }
}
