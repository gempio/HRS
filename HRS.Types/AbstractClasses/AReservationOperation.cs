﻿using HRS.Types.Models;

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

        public abstract void RollbackOperation(Reservation reservation);
    }
}
