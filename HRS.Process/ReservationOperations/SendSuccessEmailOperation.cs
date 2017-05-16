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

    using HRS.Types.Exceptions;

    public class SendSuccessEmailOperation : AReservationOperation
    {
        public SendSuccessEmailOperation( bool criticalOperation) : base(criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            var validator = new InputValidator();
            if (validator.ValidateEmail(reservation.EmailAddress))
            {
                return new OperationResult(true, "Email Successfully sent.");
            }

            throw new OperationException("Failed to send email. Invalid email address.");
        }
    }
}
