using Hotel.Application.Modules.Auth.Queries.GetById;

public sealed class UserGetByIdQuery : IRequest<UserGetByIdQueryDto>
{
    public int Id { get; set; }
}