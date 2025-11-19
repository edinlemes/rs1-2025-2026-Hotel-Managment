using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;

namespace Hotel.Domain.Entities.Users;

public class PersonsEntity : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string MailAddress { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public UsersEntity? User { get; set; }
    public int UserId { get; set; }
    public List<BookingsEntity> Bookings { get; set; } = new();
}
