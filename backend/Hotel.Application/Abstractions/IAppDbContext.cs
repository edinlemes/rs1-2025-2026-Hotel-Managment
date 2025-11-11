using Hotel.Domain.Entities.Billing;
using Hotel.Domain.Entities.Bookings;
using Hotel.Domain.Entities.Hotel;
using Hotel.Domain.Entities.Services;
using Hotel.Domain.Entities.Staff;
using Hotel.Domain.Entities.Users;

namespace Hotel.Application.Abstractions;

// Application layer
public interface IAppDbContext
{
    DbSet<ProductEntity> Products { get; }
    DbSet<ProductCategoryEntity> ProductCategories { get; }
    DbSet<HotelUserEntity> Users { get; }
    DbSet<RefreshTokenEntity> RefreshTokens { get; }
    DbSet<BillsEntity> Bills { get; }
    DbSet<PaymentsEntity> Payments { get; }
    DbSet<PaymentStatusEntity> PaymentStatuses { get; }
    DbSet<PaymentTypesEntity> PaymentTypes { get; }
    DbSet<BookingsEntity> Bookings { get; }
    DbSet<BookingStatusEntity> BookingStatuses { get; }
    DbSet<ChannelsEntity> Channels { get; }
    DbSet<DiscountsEntity> Discounts { get; }
    DbSet<RoomsBookedEntity> RoomsBooked { get; }
    DbSet<AmenitiesEntity> Amenities { get; }
    DbSet<HotelsEntity> Hotels { get; }
    DbSet<RatesEntity> Rates { get; }
    DbSet<RateTypesEntity> RateTypes { get; }
    DbSet<RoomAmenitiesEntity> RoomAmenities { get; }
    DbSet<RoomsEntity> Rooms { get; }
    DbSet<RoomStatusEntity> RoomStatuses { get; }
    DbSet<RoomTypesEntity> RoomTypes { get; }
    DbSet<GuestServicesEntity> GuestServices { get; }
    DbSet<HotelServicesEntity> HotelServices { get; }
    DbSet<StaffEntity> Staffs { get; }
    DbSet<StaffRoomsEntity> StaffRooms { get; }
    DbSet<StaffShiftAssignmentsEntity> StaffShiftAssignments { get; }
    DbSet<StaffShiftEntity> StaffShifts { get; }
    DbSet<PersonsEntity> Persons { get; }
    DbSet<PositionsEntity> JobPositions { get; }
    DbSet<UserRolesEntity> UserRoles { get; }
    DbSet<UsersEntity> UserTable { get; }

    Task<int> SaveChangesAsync(CancellationToken ct);
}