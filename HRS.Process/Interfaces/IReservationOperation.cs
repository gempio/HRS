using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Models;

namespace HRS.Process.Interfaces
{
    public interface IReservationOperation
    {
        OperationResult ReservationOperation(Reservation reservation);
    }
}
