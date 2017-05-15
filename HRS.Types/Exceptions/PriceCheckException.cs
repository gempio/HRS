using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Types.Exceptions
{
    public class PriceCheckException : Exception
    {
        public int NewPrice { get; private set; }

        public PriceCheckException(int newPrice)
        {
            NewPrice = newPrice;
        }
    }
}
