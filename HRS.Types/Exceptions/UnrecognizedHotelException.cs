using System;

namespace HRS.Types.Exceptions
{
    public class UnrecognizedHotelException : Exception
    {
        public UnrecognizedHotelException(string message) : base(message)
        {}
    }
}
