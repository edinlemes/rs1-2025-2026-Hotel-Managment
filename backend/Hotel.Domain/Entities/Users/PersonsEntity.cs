using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Users;

public class Persons
{
    public required int PersonID { get; set; }
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
    public required int UserID { get; set; }

    //public required Users User { get; set; }
    //public List<Bookings> Bookings { get; set; } = new();
}
