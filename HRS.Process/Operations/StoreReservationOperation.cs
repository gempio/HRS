﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Models;
using HRS.Process.AbstractClasses;

namespace HRS.Process.Operations
{
    public class StoreReservationOperation : AReservationOperation
    {
        public StoreReservationOperation(Reservation reservation, bool criticalOperation) : base(reservation, criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
