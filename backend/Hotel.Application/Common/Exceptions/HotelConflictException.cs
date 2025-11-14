namespace Hotel.Application.Common.Exceptions;

public sealed class HotelConflictException : Exception
{
    public HotelConflictException(string message) : base(message) { }
}
