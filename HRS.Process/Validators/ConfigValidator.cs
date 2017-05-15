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

namespace HRS.Process.Validators
{
    internal class ConfigValidator
    {
        static void ValidateConfig(List<OperationConfig> configItems)
        {
            if (configItems.Any(config => config.OperationId == OperationEnum.SendReservationRequestOperation))
            {
                return;
            }

            //TODO create bespoke exception
            throw new Exception("Send Request is not present in the config.");
        }

        static void RetrieveConfig(Hotel hotel)
        {
            //Normally I'd put a Retrieve FromDB method here.
            List<OperationConfig> retrievedConfig = new List<OperationConfig>();
            if(hotel.HotelId == 1)
            {
                
            }
            else if(hotel.HotelId == 2)
            {

            }
            else if(hotel.HotelId == 3)
            {

            }
            else
            {
                
            }
        }
    }
}
