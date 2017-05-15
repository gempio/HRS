using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.ConfigClasses;
using HRS.Types.Enums;
using HRS.Types.Models;
using HRS.Types.Exceptions;

namespace HRS.Process.Validators
{
    public class ConfigValidator
    {
        public static void ValidateConfig(Hotel hotel, List<OperationConfig> configItems)
        {
            if (configItems.Any(
                config => (config.OperationId == OperationEnum.SendReservationRequestOperation
                    && config.CriticalOperation)))
            {
                return;
            }
            
            LogInvalidConfig(hotel);
            throw new InvalidOperationException("Invalid configuration. Please contact administration team.");
        }

        private static void LogInvalidConfig(Hotel hotel)
        {
            //Normally some connection to db would be made 
            //here to log which hotel has some sort of configuraion 
            //issue.
            return; 
        }
    }
}
