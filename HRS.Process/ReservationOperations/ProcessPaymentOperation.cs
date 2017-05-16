using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Models;
using HRS.Types.AbstractClasses;

namespace HRS.Process.ReservationOperations
{
    public class ProcessPaymentOperation : AReservationOperation
    {
        private Reservation reservation;

        public ProcessPaymentOperation(Reservation reservation, bool criticalOperation) : base(reservation, criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            if (reservation.Price < 1)
            {
                throw new InvalidOperationException("Payment Failed. Invalid Price.");
            }
            return new OperationResult(true, "Payment successful.");
        }
    }
}
