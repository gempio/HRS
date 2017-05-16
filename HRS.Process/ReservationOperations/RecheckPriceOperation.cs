using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Models;
using HRS.Types.AbstractClasses;

namespace HRS.Process.ReservationOperations
{
    using HRS.Types.Exceptions;

    public class RecheckPriceOperation : AReservationOperation
    {
        public RecheckPriceOperation(bool criticalOperation) : base(criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            if (ValidForDiscount(reservation))
            {
                throw new PriceCheckException(900);
            }
            return new OperationResult(true, string.Empty);
        }

        private bool ValidForDiscount(Reservation reservation)
        {
            return Math.Abs(reservation.Price - 1000.00) < 2;
        }
    }
}
