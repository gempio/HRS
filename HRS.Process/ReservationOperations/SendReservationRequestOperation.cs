﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Models;
using HRS.Types.AbstractClasses;

namespace HRS.Process.ReservationOperations
{
    internal class SendReservationRequestOperation : AReservationOperation
    {
        public SendReservationRequestOperation(Reservation reservation, bool criticalOperation) : base(reservation, criticalOperation)
        {
        }

        public override OperationResult ReservationOperation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}