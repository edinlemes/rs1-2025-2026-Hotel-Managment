using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;

namespace Hotel.Domain.Entities.Users;

public class PersonsEntity : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
    public required string Country { get; set; }
    public required string PhoneNumber { get; set; }
    public required string MailAddress { get; set; }
    public required string Gender { get; set; }
    public UsersEntity? User { get; set; }
    public int UserId { get; set; }
    public List<BookingsEntity?> Bookings { get; set; } = new();
}
