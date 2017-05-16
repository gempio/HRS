using HRS.Types.AbstractClasses;
using HRS.Types.Exceptions;
using HRS.Types.Models;

namespace HRS.Process.ReservationOperations
{

    public class SendReservationRequestOperation : AReservationOperation
    {
        public SendReservationRequestOperation(bool criticalOperation) : base(criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            if (reservation.Hotel.HotelId > 0 && reservation.Hotel.HotelId < 3)
            {
                return new OperationResult(true, "Reservation succeeded.");
            }

            throw new OperationException("Unsupported hotel!");
        }
    }
}