using System;

namespace HRS.Types.Exceptions
{
    public class PriceCheckException : Exception
    {
        public int NewPrice { get; private set; }

        public PriceCheckException(int newPrice) : base()
        {
            NewPrice = newPrice;
        }
    }
}
