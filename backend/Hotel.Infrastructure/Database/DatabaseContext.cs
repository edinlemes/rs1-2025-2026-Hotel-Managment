using Hotel.Application.Abstractions;
using Hotel.Domain.Entities.Billing;
using Hotel.Domain.Entities.Bookings;
using Hotel.Domain.Entities.Hotel;
using Hotel.Domain.Entities.Services;
using Hotel.Domain.Entities.Staff;
using Hotel.Domain.Entities.Users;

namespace Hotel.Infrastructure.Database;

public partial class DatabaseContext : DbContext, IAppDbContext
{

    public DbSet<BillsEntity> Bills => Set<BillsEntity>();
    public DbSet<PaymentsEntity> Payments => Set<PaymentsEntity>();
    public DbSet<PaymentStatusEntity> PaymentStatuses => Set<PaymentStatusEntity>();
    public DbSet<PaymentTypesEntity> PaymentTypes => Set<PaymentTypesEntity>();
    public DbSet<BookingsEntity> Bookings => Set<BookingsEntity>();
    public DbSet<BookingStatusEntity> BookingStatuses => Set<BookingStatusEntity>();
    public DbSet<ChannelsEntity> Channels => Set<ChannelsEntity>();
    public DbSet<DiscountsEntity> Discounts => Set<DiscountsEntity>();
    public DbSet<RoomsBookedEntity> RoomsBooked => Set<RoomsBookedEntity>();
    public DbSet<AmenitiesEntity> Amenities => Set<AmenitiesEntity>();
    public DbSet<HotelsEntity> Hotels => Set<HotelsEntity>();
    public DbSet<RatesEntity> Rates => Set<RatesEntity>();
    public DbSet<RateTypesEntity> RateTypes => Set<RateTypesEntity>();
    public DbSet<RoomAmenitiesEntity> RoomAmenities => Set<RoomAmenitiesEntity>();
    public DbSet<RoomsEntity> Rooms => Set<RoomsEntity>();
    public DbSet<RoomStatusEntity> RoomStatuses => Set<RoomStatusEntity>(); 
    public DbSet<RoomTypesEntity> RoomTypes => Set<RoomTypesEntity>();
    public DbSet<GuestServicesEntity> GuestServices => Set<GuestServicesEntity>();
    public DbSet<HotelServicesEntity> HotelServices => Set<HotelServicesEntity>();
    public DbSet<StaffEntity> Staffs => Set<StaffEntity>();
    public DbSet<StaffRoomsEntity> StaffRooms => Set<StaffRoomsEntity>();
    public DbSet<StaffShiftAssignmentsEntity> StaffShiftAssignments => Set<StaffShiftAssignmentsEntity>();
    public DbSet<StaffShiftEntity> StaffShifts => Set<StaffShiftEntity>();
    public DbSet<PersonsEntity> Persons => Set<PersonsEntity>();
    public DbSet<PositionsEntity> JobPositions => Set<PositionsEntity>();
    public DbSet<UserRolesEntity> UserRoles => Set<UserRolesEntity>();
    public DbSet<UsersEntity> UserTable => Set<UsersEntity>(); 


    private readonly TimeProvider _clock;
    public DatabaseContext(DbContextOptions<DatabaseContext> options, TimeProvider clock) : base(options)
    {
        _clock = clock;
    }
}