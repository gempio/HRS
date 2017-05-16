using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HRS.Types.Models;
using HRS.Types.AbstractClasses;

namespace HRS.Process.ReservationOperations
{
    using HRS.Types.Exceptions;

    public class ProcessPaymentOperation : AReservationOperation
    {
        private Reservation reservation;

        public ProcessPaymentOperation(bool criticalOperation) : base(criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            if (reservation.Price < 1)
            {
                throw new OperationException("Payment Failed. Invalid Price.");
            }
            if (string.IsNullOrEmpty(reservation.CardNumber)) 
            {
                throw new OperationException("Payment failed. Missing Card Number.");
            }
            // For the purpose of the exercise allow for a test card number here.
            if (!Regex.Match(reservation.CardNumber, @"\d\d\d\d \d\d\d\d \d\d\d\d \d\d\d\d").Success && reservation.CardNumber != "test")
            {
               throw new OperationException("Payment failed. Invalid Card Number"); 
            }
            return new OperationResult(true, "Payment successful.");
        }
    }
}
