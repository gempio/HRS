using System;
using System.Collections.Generic;
using HRS.Types.Models;
using HRS.Process.Factories;
using HRS.Process.Operations;
using HRS.Types.Exceptions;
using HRS.Process.AbstractClasses;

namespace HRS
{
    //TODO In the future might be good to implement an interface for multiple module accesses.
    public class HotelReservationModule
    {
        public HotelReservationModule(string username, string password)
        {
            try
            {
                UserAuthentication.AuthenticateUser(username, password);
            }
            catch (Exception e)
            {
                LogInitializationException(e);
                throw;
            }
        }

        public ReservationResult MakeReservation(Reservation reservation)
        {
            List<AReservationOperation> operations = RetrieveOperations(reservation);
            return ProcessOperations(operations, reservation);
        }
        
        private ReservationResult ProcessOperations(List<AReservationOperation> operations, Reservation reservation)
        {
            //TODO: Need to think about how to exctract the try/catch into a separate method or class.
            foreach (AReservationOperation operation in operations)
            {
                try
                {
                    //Since we know which operations are not essential there
                    //might be some atomic method cherries that could be ran assynchrously.
                    operation.ReservationOperation(reservation);
                }
                catch (PriceCheckException exn)
                {
                    return ProcessPriceCheckException(operations, reservation, exn.NewPrice);
                }
                catch (OperationException ex)
                {
                    if (operation.CriticalOperation)
                    {
                        return new ReservationResult { Success = false, AdditionalInfo = ex.Message };
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return new ReservationResult { Success = true, AdditionalInfo = "" };
        }

        private ReservationResult ProcessPriceCheckException(List<AReservationOperation> operations, Reservation reservation, int newPrice)
        {
            Console.Write(string.Format("New Price alert! New price: {0}. Do you agree with the new price?", newPrice));
            Console.ReadLine();
            return ProcessOperations(operations, reservation);
        }

        private List<AReservationOperation> RetrieveOperations(Reservation reservation)
        {
            return ReservationOpsBuilder.BuildReservationOps(reservation);
        }
        private void LogInitializationException(Exception exception)
        {
            //Some sort of logging to db before throwing the exception further.
            return;
        }
    }
}
