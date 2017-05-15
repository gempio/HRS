using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.ConfigClasses;
using HRS.Types.Interfaces;
using HRS.Types.Models;

namespace HRS.Process.Factories
{
    public class ReservationOpsBuilder
    {
        public static List<AReservationOperation> BuildReservationOps(Reservation reservation)
        {
            return new List<AReservationOperation>();
        }

        private List<AReservationOperation> RetrieveHotelConfiguration()
        {
            return null;
        }
    }
}
