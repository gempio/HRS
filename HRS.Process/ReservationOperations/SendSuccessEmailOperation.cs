using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Process.ValidationOperations;
using HRS.Types.AbstractClasses;
using HRS.Types.Models;

namespace HRS.Process.ReservationOperations
{
    using System.Text.RegularExpressions;
    using HRS.Types.Exceptions;

    public class SendSuccessEmailOperation : AReservationOperation
    {
        public SendSuccessEmailOperation(bool criticalOperation) : base(criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            AValidationOperation operation = new EmailCheckValidationOperation();
            if (operation.ValidateOperation(reservation))
            {
                return new OperationResult(true, "Email Successfully sent.", this);
            }

            throw new OperationException("Failed to send email. Invalid email address.");
        }

        public override void RollbackOperation(Reservation reservation)
        {
            return;
        }
    }
}