namespace Hotel.Application.Modules.Auth.Commands.Delete;

public class DeleteUserCommandHandler(IAppDbContext dbContext) 
    : IRequestHandler<DeleteUserCommand, int>
{
    public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {

        bool UserExists = await dbContext.UserTable
            .AnyAsync(r => r.Id == request.Id && r.IsDeleted, cancellationToken);

        if (UserExists)
        {
            throw new ValidationException($"User is already deleted or does not exist.");
        }

        var roleEntity = await dbContext.UserTable.FirstOrDefaultAsync(r => r.Id == request.Id);
        if (roleEntity != null)
        {
            roleEntity.IsDeleted = true;

            dbContext.UserTable.Update(roleEntity);
            await dbContext.SaveChangesAsync(cancellationToken);
            return roleEntity.Id;
        }
        else
        {
            throw new HotelNotFoundException($"User with Id {request.Id} not found.");
        }
    }
}
