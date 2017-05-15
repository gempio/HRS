using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.ConfigClasses;
using HRS.Types.Models;
using HRS.DataAccessLayer.OperationDALs;
using HRS.Process.Validators;
using HRS.Types.Enums;
using HRS.Process.Operations;
using HRS.Process.AbstractClasses;

namespace HRS.Process.Factories
{
    public class ReservationOpsBuilder
    {
        public static List<AReservationOperation> BuildReservationOps(Reservation reservation)
        {
            List<OperationConfig> hotelConfig = RetrieveHotelConfiguration(reservation);

            ConfigValidator.ValidateConfig(reservation.Hotel, hotelConfig);

            var hotelOperations = ExtractOperations(reservation, hotelConfig);

            return hotelOperations;
        }

        private static List<OperationConfig> RetrieveHotelConfiguration(Reservation reservation)
        {
            var configDal = new ConfigDAL();
            return configDal.RetrieveConfig(reservation);
        }

        private static List<AReservationOperation> ExtractOperations(Reservation reservation, List<OperationConfig> hotelConfig)
        {
            var operations = new List<AReservationOperation>();
            
            foreach(OperationConfig config in hotelConfig)
            {
                operations.Add(ExtractOperation(reservation, config)); 
            }

            return operations;
        }

        private static AReservationOperation ExtractOperation(Reservation reservation, OperationConfig config)
        {
            switch(config.OperationId)
            {
                case OperationEnum.ProcessPaymentOperation:
                    return new ProcessPaymentOperation(reservation, config.CriticalOperation);
                case OperationEnum.RecheckPriceOperation:
                    return new RecheckPriceOperation(reservation, config.CriticalOperation);
                case OperationEnum.SendReservationRequestOperation:
                    return new SendReservationRequestOperation(reservation, config.CriticalOperation);
                case OperationEnum.SendSuccessEmailOperation:
                    return new SendSuccessEmailOperation(reservation, config.CriticalOperation); 
                case OperationEnum.StoreReservationOperation:
                    return new StoreReservationOperation(reservation, config.CriticalOperation);
                default:
                    throw new InvalidOperationException(string.Format("Invalid configuration value for operationId:{0}", config.OperationId));
            }
        }
    }
}
