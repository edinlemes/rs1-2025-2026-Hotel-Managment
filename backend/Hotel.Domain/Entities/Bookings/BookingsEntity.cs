
using Hotel.Domain.Common;
using Hotel.Domain.Entities.Hotel;
using Hotel.Domain.Entities.Users;

namespace Hotel.Domain.Entities.Bookings;

public class BookingsEntity : BaseEntity
{
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int RoomCount { get; set; }

    public HotelsEntity? Hotel { get; set; }
    public int HotelId { get; set; }
    public PersonsEntity? Person { get; set; }
    public int PersonId { get; set; }
    public required BookingStatusEntity? BookingStatus { get; set; }
    public int BookingStatusId { get; set; }
    public required DiscountsEntity? Discount { get; set; }
    public int DiscountId { get; set; }
    public ChannelsEntity? Channel { get; set; }
    public int ChannelId { get; set; }

}
