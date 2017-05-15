using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Interfaces;
using HRS.Types.Models;
using HRS.Process.Factories;
using HRS.Process.Operations;
using HRS.DataAccessLayer.OperationDALs;

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
            List<AReservationOperation> operations = ReservationOpsBuilder.BuildReservationOps(reservation);
            foreach(AReservationOperation operation in operations)
            {
                try
                {

                }
                catch(OperationException ex)
                {
                    if(operation.)
                }
            }
        }
        private void LogInitializationException(Exception exception)
        {
            //Some sort of logging to db before throwing the exception further.
            throw new NotImplementedException();
        }
    }
}
