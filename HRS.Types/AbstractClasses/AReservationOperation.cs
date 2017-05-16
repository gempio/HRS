using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Models;

namespace HRS.Types.AbstractClasses
{
    public abstract class AReservationOperation
    {
        public bool CriticalOperation { get; private set; }

        public AReservationOperation(bool criticalOperation)
        {
            CriticalOperation = criticalOperation;
        }
        public abstract OperationResult ReservationOperation(Reservation reservation);
    }
}
