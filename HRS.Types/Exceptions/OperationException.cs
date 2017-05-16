using System;

namespace HRS.Types.Exceptions
{
    public class OperationException : Exception
    {
        public OperationException(string message) : base(message)
        {
        }
    }
}
