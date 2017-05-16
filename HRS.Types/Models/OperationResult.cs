namespace HRS.Types.Models
{
    public class OperationResult
    {
        public bool OperationSuccess { get; private set; }
        public string AdditionalInfo { get; private set; }

        public OperationResult(bool operationSuccess, string additionalInfo)
        {
            OperationSuccess = operationSuccess;
            AdditionalInfo = additionalInfo;
        }
    }
}
