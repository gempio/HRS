using HRS.Types.AbstractClasses;

namespace HRS.Types.Models
{
    public class OperationResult
    {
        public bool OperationSuccess { get; private set; }
        public string AdditionalInfo { get; private set; }
        public AReservationOperation Operation { get; private set; }

        public OperationResult(bool operationSuccess, string additionalInfo, AReservationOperation operation)
        {
            OperationSuccess = operationSuccess;
            AdditionalInfo = additionalInfo;
            Operation = operation;
        }
    }
}
