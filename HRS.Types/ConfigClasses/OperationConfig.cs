using HRS.Types.Enums;

namespace HRS.Types.ConfigClasses
{
    public class OperationConfig
    {
        public OperationEnum OperationId { get; private set; }
        public bool CriticalOperation { get; private set; }

        public OperationConfig(OperationEnum operationId, bool criticalOperation)
        {
            OperationId = operationId;
            CriticalOperation = criticalOperation;
        }
    }
}
