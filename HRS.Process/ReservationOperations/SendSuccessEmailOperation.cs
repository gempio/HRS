using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Models;
using HRS.Types.AbstractClasses;

namespace HRS.Process.ReservationOperations
{
    using System.Text.RegularExpressions;

    public class SendSuccessEmailOperation : AReservationOperation
    {
        public SendSuccessEmailOperation(Reservation reservation, bool criticalOperation) : base(reservation, criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            var validator = new InputValidator();
            if (validator.ValidateEmail(reservation.EmailAddress))
            {
                return new OperationResult(true, "Email Successfully sent.");
            }

            return new OperationResult(false, "Failed to send email. Invalid email address.");
        }
    }
}
