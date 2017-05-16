using HRS.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Process
{
    //This class could actually be a project of its own.
    public class InputValidator
    {
        public bool ValidateRoomChoice(Room roomChoice)
        {
            return true;
        }

        public bool ValidateHotelChoice(Hotel hotelChoice)
        {
            return true;
        }

        public bool ValidateEmail(string email)
        {
            return true;
        }

        public bool ValidateCardNumber(string cardNumber)
        {
            return true;
        }

        public bool ValidatePersonsName(string name)
        {
            return true;
        }

        public bool ValidateArrivalDate(DateTime date)
        {
            return true; 
        }

        public bool ValidateNoOfVisitors(int noOfVisitors)
        {
            return true;
        }

        public bool ValidateNightsToStart(int nightsToStay)
        {
            return true;
        }
    }
}
