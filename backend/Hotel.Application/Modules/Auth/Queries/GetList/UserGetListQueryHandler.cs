using Hotel.Application.Modules.Auth.Roles.Querries.GetList;

namespace Hotel.Application.Modules.Auth.Queries.GetList;

public sealed class UserGetListQueryHandler(IAppDbContext dbContext)
    : IRequestHandler<UserGetListQuery, PageResult<UserGetListQueryDto>>
{
    public async Task<PageResult<UserGetListQueryDto>> Handle(UserGetListQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.UserTable.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(r => r.Username.Contains(request.Search));
        }

        var projectedQuery = query
            .OrderBy(r => r.Username)
            .Select(r => new UserGetListQueryDto
            {
                UserId = r.Id,
                UserName = r.Username,
                UserEmail = r.Email
            });
        return await PageResult<UserGetListQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, cancellationToken);
    }
}

