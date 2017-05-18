using System.Collections.Generic;
using HRS.Types.ConfigClasses;
using HRS.Types.Models;
using HRS.DataAccessLayer.OperationDALs;
using HRS.Process.Validators;
using HRS.Types.Enums;
using HRS.Types.AbstractClasses;
using HRS.Process.ReservationOperations;
using HRS.Types.Exceptions;

namespace HRS.Process.Factories
{
    public class ReservationOpsBuilder
    {
        public static List<AReservationOperation> BuildReservationOps(Reservation reservation)
        {
            List<OperationConfig> hotelConfig = RetrieveHotelConfiguration(reservation);

            ConfigValidator.ValidateConfig(reservation.Hotel, hotelConfig);

            var hotelOperations = ExtractOperationsFromConfig(reservation, hotelConfig);

            return hotelOperations;
        }

        private static List<OperationConfig> RetrieveHotelConfiguration(Reservation reservation)
        {
            var configDal = new ConfigDAL();
            return configDal.RetrieveConfig(reservation);
        }

        private static List<AReservationOperation> ExtractOperationsFromConfig(Reservation reservation, List<OperationConfig> hotelConfig)
        {
            var operations = new List<AReservationOperation>();
            
            foreach(OperationConfig config in hotelConfig)
            {
                operations.Add(ExtractOperation(config)); 
            }

            return operations;
        }

        private static AReservationOperation ExtractOperation(OperationConfig config)
        {
            switch(config.OperationId)
            {
                case OperationEnum.ProcessPaymentOperation:
                    return new ProcessPaymentOperation(config.CriticalOperation);
                case OperationEnum.RecheckPriceOperation:
                    return new RecheckPriceOperation(config.CriticalOperation);
                case OperationEnum.SendReservationRequestOperation:
                    return new SendReservationRequestOperation(config.CriticalOperation);
                case OperationEnum.SendSuccessEmailOperation:
                    return new SendSuccessEmailOperation(config.CriticalOperation); 
                case OperationEnum.StoreReservationOperation:
                    return new StoreReservationOperation(config.CriticalOperation);
                default:
                    throw new InvalidConfigException("Invalid configuration value for operationId:{0}", config.OperationId);
            }
        }
    }
}
