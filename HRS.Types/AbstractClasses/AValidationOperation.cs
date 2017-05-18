using HRS.Types.Models;

namespace HRS.Types.AbstractClasses
{
    public abstract class AValidationOperation
    {
        public abstract bool ValidateOperation(Reservation reservation);
    }
}
