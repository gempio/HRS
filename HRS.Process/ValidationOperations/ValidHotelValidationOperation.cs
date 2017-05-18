using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.AbstractClasses;
using HRS.Types.Models;

namespace HRS.Process.ValidationOperations
{
    public class ValidHotelValidationOperation : AValidationOperation 
    {
        public override bool ValidateOperation(Reservation reservation)
        {
            return CheckHotelExistsInDb(reservation);
        }

        private bool CheckHotelExistsInDb(Reservation reservation)
        {
            //Normally some sort of DAL function would be called here to check.
            return reservation.Hotel.HotelId > 0 && reservation.Hotel.HotelId < 4;
        }
    }
}
