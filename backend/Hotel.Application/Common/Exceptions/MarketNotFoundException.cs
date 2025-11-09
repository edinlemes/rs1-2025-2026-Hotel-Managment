namespace Hotel.Application.Common.Exceptions;

public sealed class HotelNotFoundException : Exception
{
    public HotelNotFoundException(string message) : base(message) { }
}
