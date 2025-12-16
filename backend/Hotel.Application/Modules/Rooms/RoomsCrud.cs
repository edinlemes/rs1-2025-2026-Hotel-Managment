using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel.Application.Abstractions;
using Hotel.Domain.Entities.Hotel;

namespace Hotel.Application.Modules.Rooms;

public record RoomDto(int Id, string RoomNumber, string Description, int Floor, int HotelId, int RoomTypeId, int RoomStatusId, bool IsDeleted);
public record CreateRoomDto(string RoomNumber, string Description, int Floor, int HotelId, int RoomTypeId, int RoomStatusId);
public record UpdateRoomDto(string RoomNumber, string Description, int Floor, int HotelId, int RoomTypeId, int RoomStatusId);

public class RoomsCrud
{
    private readonly IAppDbContext _context;

    public RoomsCrud(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<RoomDto> CreateAsync(CreateRoomDto dto, CancellationToken ct = default)
    {
        var entity = new RoomsEntity
        {
            RoomNumber = dto.RoomNumber,
            Description = dto.Description,
            Floor = dto.Floor,
            HotelId = dto.HotelId,
            RoomTypeId = dto.RoomTypeId,
            RoomStatusId = dto.RoomStatusId,
            CreatedAtUtc = DateTime.UtcNow,
            
            IsDeleted = false
        };

        _context.Rooms.Add(entity);
        await _context.SaveChangesAsync(ct);

        return ToDto(entity);
    }

    public async Task<List<RoomDto>> GetAllAsync(bool includeDeleted = false, CancellationToken ct = default)
    {
        var query = includeDeleted
            ? _context.Rooms.IgnoreQueryFilters().AsNoTracking()
            : _context.Rooms.AsNoTracking();

        return await query
            .Select(r => ToDto(r))
            .ToListAsync(ct);
    }

    public async Task<RoomDto?> GetByIdAsync(int id, bool includeDeleted = false, CancellationToken ct = default)
    {
        var query = includeDeleted
            ? _context.Rooms.IgnoreQueryFilters().AsNoTracking()
            : _context.Rooms.AsNoTracking();

        var r = await query.FirstOrDefaultAsync(x => x.Id == id, ct);
        return r is null ? null : ToDto(r);
    }

    public async Task<bool> UpdateAsync(int id, UpdateRoomDto dto, CancellationToken ct = default)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id, ct);
        if (room == null) return false;

        room.RoomNumber = dto.RoomNumber;
        room.Description = dto.Description;
        room.Floor = dto.Floor;
        room.HotelId = dto.HotelId;
        room.RoomTypeId = dto.RoomTypeId;
        room.RoomStatusId = dto.RoomStatusId;
        room.ModifiedAtUtc = DateTime.UtcNow;

        await _context.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id, ct);
        if (room == null) return false;

        // soft-delete
        room.IsDeleted = true;
        room.ModifiedAtUtc = DateTime.UtcNow;

        await _context.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> RestoreAsync(int id, CancellationToken ct = default)
    {
        var room = await _context.Rooms.IgnoreQueryFilters().FirstOrDefaultAsync(r => r.Id == id, ct);
        if (room == null || !room.IsDeleted) return false;

        room.IsDeleted = false;
        room.ModifiedAtUtc = DateTime.UtcNow;

        await _context.SaveChangesAsync(ct);
        return true;
    }

    private static RoomDto ToDto(RoomsEntity r)
        => new RoomDto(r.Id, r.RoomNumber, r.Description, r.Floor, r.HotelId, r.RoomTypeId, r.RoomStatusId, r.IsDeleted);
}
