namespace Hotel.Application.Modules.Auth.Roles.Querries.GetList;

public sealed class ListRolesQueryHandler (IAppDbContext dbContext)
    : IRequestHandler<ListRolesQuery, PageResult<ListRolesQueryDto>>
{
    public async Task<PageResult<ListRolesQueryDto>> Handle(ListRolesQuery request, CancellationToken cancellationToken)
    {
       var query = dbContext.Roles.AsNoTracking();
        
        if(!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(r => r.RoleName.Contains(request.Search));
        }

        var projectedQuery = query
            .OrderBy(r => r.RoleName)
            .Select(r => new ListRolesQueryDto
        {
            Id = r.Id,
            RoleName = r.RoleName,
            IsActive = r.Active
        });
        return await PageResult<ListRolesQueryDto>.FromQueryableAsync(projectedQuery,request.Paging,cancellationToken);
    }
}
