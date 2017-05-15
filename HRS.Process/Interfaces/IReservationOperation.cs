using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Models;

namespace HRS.Process.AbstractClasses
{
    public abstract class AReservationOperation
    {
        public bool CriticalOperation { get; private set; }
        private Reservation _reservation;

        public AReservationOperation(Reservation reservation, bool criticalOperation)
        {
            CriticalOperation = criticalOperation;
            _reservation = reservation;
        }
        public abstract OperationResult ReservationOperation(Reservation reservation);
    }
}
