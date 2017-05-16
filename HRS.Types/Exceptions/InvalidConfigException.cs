using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Types.Exceptions
{
    public class InvalidConfigException : Exception
    {
        public InvalidConfigException(string message) : base(message) { }
    }
}
