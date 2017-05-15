using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Types.Enums
{
    public enum OperationEnum
    {
        SendReservationRequestOperation = 0,
        RecheckPriceOperation = 1,
        SendSuccessEmailOperation = 2,
        StoreReservationOperation = 3,
        ProcessPaymentOperation = 4
    }
}
