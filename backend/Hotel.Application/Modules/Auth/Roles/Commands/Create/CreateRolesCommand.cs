namespace Hotel.Application.Modules.Auth.Roles.Commands.Create;

public class CreateRolesCommand : IRequest<int>
{
    public string RoleName { get; set; } =string.Empty;
    public string Description { get; set; } = string.Empty;
}
