using HRS.Types.Models;
using System;

namespace HRS.Process
{
    using System.Text.RegularExpressions;

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
            // Return true if email is in valid e-mail format.
            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
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
