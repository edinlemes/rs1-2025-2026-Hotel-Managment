using Hotel.Domain.Common;
using Hotel.Domain.Entities.Bookings;

namespace Hotel.Domain.Entities.Users;

public class PersonsEntity : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string MailAddress { get; set; }
    public string Gender { get; set; }
    public UsersEntity? User { get; set; }
    public int UserId { get; set; }
    public List<BookingsEntity?> Bookings { get; set; } = new();
}
