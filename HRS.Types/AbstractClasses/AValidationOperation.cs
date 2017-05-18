using HRS.Types.Models;

namespace HRS.Types.AbstractClasses
{
    public abstract class AValidationOperation
    {
        //Technically this looks more like an interface but in the future if validation requires other input config value it might be better
        //to simply leave this as abstract.
        public abstract bool ValidateOperation(Reservation reservation);
    }
}
