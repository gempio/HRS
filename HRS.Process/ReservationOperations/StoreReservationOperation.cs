using System;
using HRS.Types.AbstractClasses;
using HRS.Types.Models;

namespace HRS.Process.ReservationOperations
{
    public class StoreReservationOperation : AReservationOperation
    {
        public StoreReservationOperation(bool criticalOperation) : base(criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            if (string.IsNullOrEmpty(reservation.ReservationId))
            {
                throw new InvalidOperationException("Storing reservation failed. ReservationId is missing.");
            }

            return new OperationResult(true, string.Empty, this);
        }

        public override void RollbackOperation(Reservation reservation)
        {
            return;
        }
    }
}