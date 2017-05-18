using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.AbstractClasses;
using HRS.Types.Models;

namespace HRS.Process.ValidationOperations
{
    public class DateValidationOperation : AValidationOperation
    {
        public override bool ValidateOperation(Reservation reservation)
        {
            if (reservation.DateOfReservation < DateTime.Now)
            {
                return false;
            }

            if (reservation.DateOfReservation.Date > DateTime.Now.AddYears(1).Date)
            {
                return false;
            }

            return true;
        }
    }
}
