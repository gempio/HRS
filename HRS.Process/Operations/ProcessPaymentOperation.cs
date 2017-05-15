using HRS.Process.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Models;

namespace HRS.Process.Operations
{
    public class ProcessPaymentOperation : AReservationOperation
    {
        private Reservation reservation;

        public ProcessPaymentOperation(Reservation reservation, bool criticalOperation) : base(reservation, criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
