using System.Text.RegularExpressions;
using HRS.Types.AbstractClasses;
using HRS.Types.Exceptions;
using HRS.Types.Models;

namespace HRS.Process.ReservationOperations
{
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
            if (!Regex.Match(reservation.CardNumber, @"\d\d\d\d \d\d\d\d \d\d\d\d \d\d\d\d").Success &&
                reservation.CardNumber != "test")
            {
                throw new OperationException("Payment failed. Invalid Card Number");
            }

            return new OperationResult(true, "Payment successful.");
        }
    }
}