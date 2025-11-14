namespace Hotel.Application.Modules.Auth.Roles.Querries.GetList;
public sealed class ListRolesQuery : BasePagedQuery<ListRolesQueryDto>
{
    public string? Search { get; set; }
}
