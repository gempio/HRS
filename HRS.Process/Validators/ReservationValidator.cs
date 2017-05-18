using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Process.ValidationOperations;
using HRS.Types.AbstractClasses;
using HRS.Types.Models;

namespace HRS.Process.Validators
{
    public class ReservationValidator
    {
        public static bool ValidateReservation(Reservation reservation)
        {
            var validationOperations = GetGenericValidationList();
            foreach (AValidationOperation operation in validationOperations)
            {
                if (!operation.ValidateOperation(reservation))
                {
                    return false;
                }
            }

            return true;
        }

        private static List<AValidationOperation> GetGenericValidationList()
        {
            List<AValidationOperation> validationOperations =
                new List<AValidationOperation>
                {
                    new ValidHotelValidationOperation(),
                    new DateValidationOperation(),
                    new EmailCheckValidationOperation(),
                    new CardNumberValidationOperation()
                };
            return validationOperations;
        }
    }
}
