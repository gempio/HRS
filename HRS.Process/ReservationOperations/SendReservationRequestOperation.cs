using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Models;
using HRS.Types.AbstractClasses;

namespace HRS.Process.ReservationOperations
{
    using System.CodeDom;

    using HRS.Types.Exceptions;

    public class SendReservationRequestOperation : AReservationOperation
    {
        public SendReservationRequestOperation(bool criticalOperation) : base(criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            if (reservation.Hotel.HotelId > 3 && reservation.Hotel.HotelId < 0)
            {
                return new OperationResult(true, "Reservation succeeded.");
            }

            throw new OperationException("Unsupported hotel!");
        }
    }
}
