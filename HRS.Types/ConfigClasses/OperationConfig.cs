using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
