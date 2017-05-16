using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Enums;

namespace HRS.Types.Exceptions
{
    public class InvalidConfigException : Exception
    {
        private OperationEnum operationId;

        public InvalidConfigException(string message) : base(message)
        {
        }

        public InvalidConfigException(string message, OperationEnum operationId) : this(message)
        {
            this.operationId = operationId;
        }
    }
}
