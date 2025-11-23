namespace Hotel.Application.Modules.Auth.Queries.GetById;

public sealed class UserGetByIdQueryHandler(IAppDbContext dbContext)
    : IRequestHandler<UserGetByIdQuery, UserGetByIdQueryDto>
{
    public async Task<UserGetByIdQueryDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.UserRoles.AsNoTracking();

        if (query.Any(x => x.Id == request.Id))
        {
            query = query.Where(x => x.Id == request.Id);
        }
        else
        {
            throw new HotelNotFoundException("User not found.");
        }

        var projectedQuery = query
            .Select(u => new UserGetByIdQueryDto
            { 
                UserId = u.Id,
                UserName = u.User!.Username,
                UserEmail = u.User.Email,
                Role = new RolesDto
                {
                    RoleId = u.Role!.Id,
                    RoleName = u.Role.RoleName
                }
            }
            );
        var result = await projectedQuery.FirstOrDefaultAsync(cancellationToken);
        if (result is null)
        {
            throw new HotelNotFoundException("User not found.");
        }

        return result;

    }
}

