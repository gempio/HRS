using System.Collections.Generic;
using HRS.DataAccessLayer.OperationDALs;
using HRS.Process.Factories;
using HRS.Process.ReservationOperations;
using HRS.Process.Validators;
using HRS.Types.AbstractClasses;
using HRS.Types.ConfigClasses;
using HRS.Types.Enums;
using HRS.Types.Exceptions;
using HRS.Types.Models;

namespace HRS.Process.Builder
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
                operations.Add(ReservationOperationFactory.ExtractOperation(config)); 
            }

            return operations;
        }
    }
}
