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
        public bool CriticalOperation;

        public abstract OperationResult ReservationOperation(Reservation reservation);
    }
}
