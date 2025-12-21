using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Hotel.Application.Abstractions;
using Hotel.Application.Common;
using Hotel.Domain.Entities.Hotel;

namespace Hotel.Application.Modules.Hotels;

#region DTOs
public record HotelDto(
    int Id,
    string HotelCode,
    string Name,
    string Address,
    string City,
    string State,
    string ZipCode,
    string PhoneNumber,
    string CompanyMailAddress,
    string WebsiteAddress,
    bool IsDeleted,
    DateTime CreatedAtUtc,
    DateTime? ModifiedAtUtc
);

public record CreateHotelRequest(
    string HotelCode,
    string Name,
    string Address,
    string City,
    string State,
    string ZipCode,
    string PhoneNumber,
    string CompanyMailAddress,
    string WebsiteAddress
);

public record UpdateHotelRequest(
    string HotelCode,
    string Name,
    string Address,
    string City,
    string State,
    string ZipCode,
    string PhoneNumber,
    string CompanyMailAddress,
    string WebsiteAddress
);

public record HotelFilterParams
{
    public string? SearchTerm { get; init; }
    public string? City { get; init; }
    public string? State { get; init; }
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public record PagedHotelDto(
    IReadOnlyList<HotelDto> Items,
    int Total,
    int PageNumber,
    int PageSize,
    int TotalPages
)
{
    public static PagedHotelDto FromPageResult(PageResult<HotelDto> result, int pageNumber, int pageSize)
    {
        var totalPages = (int)Math.Ceiling((double)result.Total / pageSize);
        return new PagedHotelDto(result.Items, result.Total, pageNumber, pageSize, totalPages);
    }

    // Map to match frontend response format
    public dynamic ToResponse()
    {
        return new
        {
            items = Items,
            totalCount = Total,
            pageNumber = PageNumber,
            pageSize = PageSize,
            totalPages = TotalPages
        };
    }
}
#endregion

#region Queries
public record GetAllHotelsQuery(HotelFilterParams FilterParams) : IRequest<PagedHotelDto>;

public sealed class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQuery, PagedHotelDto>
{
    private readonly IAppDbContext _ctx;
    public GetAllHotelsQueryHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<PagedHotelDto> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
    {
        var query = _ctx.Hotels.AsNoTracking();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(request.FilterParams.SearchTerm))
        {
            var searchTerm = request.FilterParams.SearchTerm.ToLower();
            query = query.Where(h =>
                h.Name.ToLower().Contains(searchTerm) ||
                h.Address.ToLower().Contains(searchTerm) ||
                h.HotelCode.ToLower().Contains(searchTerm)
            );
        }

        if (!string.IsNullOrWhiteSpace(request.FilterParams.City))
        {
            query = query.Where(h => h.City == request.FilterParams.City);
        }

        if (!string.IsNullOrWhiteSpace(request.FilterParams.State))
        {
            query = query.Where(h => h.State == request.FilterParams.State);
        }

        // Create paging request
        var pageRequest = new PageRequest
        {
            Page = request.FilterParams.Page,
            PageSize = request.FilterParams.PageSize
        };

        // Project to DTO before pagination
        var dtoQuery = query.Select(h => new HotelDto(
            h.Id,
            h.HotelCode,
            h.Name,
            h.Address,
            h.City,
            h.State,
            h.ZipCode,
            h.PhoneNumber,
            h.CompanyMailAddress,
            h.WebsiteAddress,
            h.IsDeleted,
            h.CreatedAtUtc,
            h.ModifiedAtUtc
        ));

        // Apply pagination
        var pageResult = await PageResult<HotelDto>.FromQueryableAsync(
            dtoQuery,
            pageRequest,
            cancellationToken
        );

        return PagedHotelDto.FromPageResult(pageResult, request.FilterParams.Page, request.FilterParams.PageSize);
    }
}

public record GetHotelByIdQuery(int Id) : IRequest<HotelDto?>;

public sealed class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, HotelDto?>
{
    private readonly IAppDbContext _ctx;
    public GetHotelByIdQueryHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<HotelDto?> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _ctx.Hotels
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (hotel is null) return null;

        return new HotelDto(
            hotel.Id,
            hotel.HotelCode,
            hotel.Name,
            hotel.Address,
            hotel.City,
            hotel.State,
            hotel.ZipCode,
            hotel.PhoneNumber,
            hotel.CompanyMailAddress,
            hotel.WebsiteAddress,
            hotel.IsDeleted,
            hotel.CreatedAtUtc,
            hotel.ModifiedAtUtc
        );
    }
}
#endregion

#region Commands
public record CreateHotelCommand(CreateHotelRequest Payload) : IRequest<HotelDto>;

public sealed class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, HotelDto>
{
    private readonly IAppDbContext _ctx;
    public CreateHotelCommandHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<HotelDto> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var entity = new HotelsEntity
        {
            HotelCode = request.Payload.HotelCode,
            Name = request.Payload.Name,
            Address = request.Payload.Address,
            City = request.Payload.City,
            State = request.Payload.State,
            ZipCode = request.Payload.ZipCode,
            PhoneNumber = request.Payload.PhoneNumber,
            CompanyMailAddress = request.Payload.CompanyMailAddress,
            WebsiteAddress = request.Payload.WebsiteAddress,
            CreatedAtUtc = DateTime.UtcNow
        };

        _ctx.Hotels.Add(entity);
        await _ctx.SaveChangesAsync(cancellationToken);

        return new HotelDto(
            entity.Id,
            entity.HotelCode,
            entity.Name,
            entity.Address,
            entity.City,
            entity.State,
            entity.ZipCode,
            entity.PhoneNumber,
            entity.CompanyMailAddress,
            entity.WebsiteAddress,
            entity.IsDeleted,
            entity.CreatedAtUtc,
            entity.ModifiedAtUtc
        );
    }
}

public record UpdateHotelCommand(int Id, UpdateHotelRequest Payload) : IRequest<HotelDto?>;

public sealed class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, HotelDto?>
{
    private readonly IAppDbContext _ctx;
    public UpdateHotelCommandHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<HotelDto?> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ctx.Hotels.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity is null) return null;

        entity.HotelCode = request.Payload.HotelCode;
        entity.Name = request.Payload.Name;
        entity.Address = request.Payload.Address;
        entity.City = request.Payload.City;
        entity.State = request.Payload.State;
        entity.ZipCode = request.Payload.ZipCode;
        entity.PhoneNumber = request.Payload.PhoneNumber;
        entity.CompanyMailAddress = request.Payload.CompanyMailAddress;
        entity.WebsiteAddress = request.Payload.WebsiteAddress;
        entity.ModifiedAtUtc = DateTime.UtcNow;

        await _ctx.SaveChangesAsync(cancellationToken);

        return new HotelDto(
            entity.Id,
            entity.HotelCode,
            entity.Name,
            entity.Address,
            entity.City,
            entity.State,
            entity.ZipCode,
            entity.PhoneNumber,
            entity.CompanyMailAddress,
            entity.WebsiteAddress,
            entity.IsDeleted,
            entity.CreatedAtUtc,
            entity.ModifiedAtUtc
        );
    }
}

public record DeleteHotelCommand(int Id) : IRequest<bool>;

public sealed class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, bool>
{
    private readonly IAppDbContext _ctx;
    public DeleteHotelCommandHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<bool> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ctx.Hotels.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity is null) return false;

        _ctx.Hotels.Remove(entity);
        await _ctx.SaveChangesAsync(cancellationToken);
        return true;
    }
}
#endregion
