namespace Hotel.Application.Modules.Auth.Queries.GetList;

public sealed class UserGetListQueryDto
{
    public required int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
}

