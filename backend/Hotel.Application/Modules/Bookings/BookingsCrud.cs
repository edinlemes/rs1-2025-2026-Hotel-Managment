using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Hotel.Application.Abstractions;
using Hotel.Domain.Entities.Bookings;

namespace Hotel.Application.Modules.Bookings;

#region DTOs
public record BookingDto(int Id, DateTime DateFrom, DateTime DateTo, int RoomCount, int HotelId, int PersonId, int BookingStatusId, int DiscountId, int ChannelId);

public record CreateBookingRequest(DateTime DateFrom, DateTime DateTo, int RoomCount, int HotelId, int PersonId, int BookingStatusId, int DiscountId, int ChannelId);
public record UpdateBookingRequest(DateTime DateFrom, DateTime DateTo, int RoomCount, int HotelId, int PersonId, int BookingStatusId, int DiscountId, int ChannelId);
#endregion

#region Queries
public record GetAllBookingsQuery : IRequest<List<BookingDto>>;

public sealed class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, List<BookingDto>>
{
    private readonly IAppDbContext _ctx;
    public GetAllBookingsQueryHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<List<BookingDto>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
    {
        return await _ctx.Bookings
            .AsNoTracking()
            .Select(b => new BookingDto(b.Id, b.DateFrom, b.DateTo, b.RoomCount, b.HotelId, b.PersonId, b.BookingStatusId, b.DiscountId, b.ChannelId))
            .ToListAsync(cancellationToken);
    }
}

public record GetBookingByIdQuery(int Id) : IRequest<BookingDto?>;

public sealed class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, BookingDto?>
{
    private readonly IAppDbContext _ctx;
    public GetBookingByIdQueryHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<BookingDto?> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var b = await _ctx.Bookings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (b is null) return null;
        return new BookingDto(b.Id, b.DateFrom, b.DateTo, b.RoomCount, b.HotelId, b.PersonId, b.BookingStatusId, b.DiscountId, b.ChannelId);
    }
}
#endregion

#region Commands
public record CreateBookingCommand(CreateBookingRequest Payload) : IRequest<BookingDto>;

public sealed class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingDto>
{
    private readonly IAppDbContext _ctx;
    public CreateBookingCommandHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<BookingDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var entity = new BookingsEntity
        {
            DateFrom = request.Payload.DateFrom,
            DateTo = request.Payload.DateTo,
            RoomCount = request.Payload.RoomCount,
            HotelId = request.Payload.HotelId,
            PersonId = request.Payload.PersonId,
            BookingStatusId = request.Payload.BookingStatusId,
            DiscountId = request.Payload.DiscountId,
            ChannelId = request.Payload.ChannelId,
            CreatedAtUtc = DateTime.UtcNow,
            
            // required navigations must be assigned (null! used because we set FKs)
            BookingStatus = null!,
            Discount = null!
        };

        _ctx.Bookings.Add(entity);
        await _ctx.SaveChangesAsync(cancellationToken);

        return new BookingDto(entity.Id, entity.DateFrom, entity.DateTo, entity.RoomCount, entity.HotelId, entity.PersonId, entity.BookingStatusId, entity.DiscountId, entity.ChannelId);
    }
}

public record UpdateBookingCommand(int Id, UpdateBookingRequest Payload) : IRequest<BookingDto?>;

public sealed class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, BookingDto?>
{
    private readonly IAppDbContext _ctx;
    public UpdateBookingCommandHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<BookingDto?> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ctx.Bookings.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity is null) return null;

        entity.DateFrom = request.Payload.DateFrom;
        entity.DateTo = request.Payload.DateTo;
        entity.RoomCount = request.Payload.RoomCount;
        entity.HotelId = request.Payload.HotelId;
        entity.PersonId = request.Payload.PersonId;
        entity.BookingStatusId = request.Payload.BookingStatusId;
        entity.DiscountId = request.Payload.DiscountId;
        entity.ChannelId = request.Payload.ChannelId;

        await _ctx.SaveChangesAsync(cancellationToken);

        return new BookingDto(entity.Id, entity.DateFrom, entity.DateTo, entity.RoomCount, entity.HotelId, entity.PersonId, entity.BookingStatusId, entity.DiscountId, entity.ChannelId);
    }
}

public record DeleteBookingCommand(int Id) : IRequest<bool>;

public sealed class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, bool>
{
    private readonly IAppDbContext _ctx;
    public DeleteBookingCommandHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<bool> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ctx.Bookings.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity is null) return false;

        entity.IsDeleted = true;
        entity.ModifiedAtUtc = DateTime.UtcNow;

        await _ctx.SaveChangesAsync(cancellationToken);
        return true;
    }
}
#endregion
