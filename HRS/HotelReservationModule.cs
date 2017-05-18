using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using HRS.Types.Models;
using HRS.Process.Factories;
using HRS.Process.Operations;
using HRS.Types.Exceptions;
using HRS.Types.AbstractClasses;

namespace HRS
{
    //TODO: In the future might be good to implement an interface for multiple module accesses.
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
            List<OperationResult> results = new List<OperationResult>();
            //TODO: Need to think about how to exctract the try/catch into a separate method or class.
            foreach (AReservationOperation operation in operations)
            {
                try
                {
                    //Since we know which operations are not essential there
                    //might be some atomic method cherries that could be ran assynchrously.
                    OperationResult result = operation.ReservationOperation(reservation);

                    results.Add(result);
                }
                catch (PriceCheckException exn)
                {
                    return ProcessPriceCheckException(operations, reservation, exn.NewPrice);
                }
                catch (OperationException ex)
                {
                    if (operation.CriticalOperation)
                    {
                        RollbackSuccessfulOperations(results, reservation);
                        return new ReservationResult { Success = false, AdditionalInfo = ex.Message };
                    }
                }
            }

            Console.WriteLine("Reservation Succesfull.");
            return new ReservationResult { Success = true, AdditionalInfo = "" };
        }

        private void RollbackSuccessfulOperations(List<OperationResult> results, Reservation reservation)
        {
            foreach (OperationResult result in results)
            {
                result.Operation.RollbackOperation(reservation);
            }
        }
        private ReservationResult ProcessPriceCheckException(List<AReservationOperation> operations, Reservation reservation, int newPrice)
        {
            Console.Write("New Price alert! New price: {0}. Do you agree with the new price?", newPrice);
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
