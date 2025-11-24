using Hotel.Application.Modules.Auth.Queries.GetList;

public sealed class UserGetListQuery : BasePagedQuery<UserGetListQueryDto>
{
    public string? Search { get; set; }

}