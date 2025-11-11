
using Hotel.Domain.Common;

namespace Hotel.Domain.Entities.Bookings;

public class BookingsEntity : BaseEntity
{
    public required int HotelID { get; set; }
    public required int PersonID { get; set; }
    public required DateTime DateFrom { get; set; }
    public required DateTime DateTo { get; set; }
    public required int RoomCount { get; set; }
    public required int BookingStatusID { get; set; }
    public required int DiscountID { get; set; }
    public required int ChannelID { get; set; }

    public Hotels Hotel { get; set; }
    public int HotelId { get; set; }
    public Persons Person { get; set; }
    public required BookingStatus BookingStatus { get; set; }
    public required Discounts Discount { get; set; }
    public required Channels Channel { get; set; }


}
