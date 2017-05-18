using System.Text.RegularExpressions;
using HRS.Process.ValidationOperations;
using HRS.Types.AbstractClasses;
using HRS.Types.Exceptions;
using HRS.Types.Models;

namespace HRS.Process.ReservationOperations
{
    public class ProcessPaymentOperation : AReservationOperation
    {
        public ProcessPaymentOperation(bool criticalOperation) : base(criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            if (reservation.Price < 1)
            {
                throw new OperationException("Payment Failed. Invalid Price.");
            }

            AValidationOperation cardNumberValidator = new CardNumberValidationOperation();
            if (!cardNumberValidator.ValidateOperation(reservation))
            {
                throw new OperationException("Payment failed. Invalid Card Number");
            }

            return new OperationResult(true, "Payment successful.", this);
        }

        public override void RollbackOperation(Reservation reservation)
        {
            return;
        }
    }
}