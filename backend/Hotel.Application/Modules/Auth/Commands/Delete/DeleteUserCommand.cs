namespace Hotel.Application.Modules.Auth.Commands.Delete;

public class DeleteUserCommand : IRequest<int>
{
    public int Id { get; set; }
}
