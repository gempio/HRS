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
            return new OperationResult(true, string.Empty);
        }
    }
}