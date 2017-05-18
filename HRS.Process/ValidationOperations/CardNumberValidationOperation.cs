using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HRS.Types.AbstractClasses;
using HRS.Types.Models;

namespace HRS.Process.ValidationOperations
{
    public class CardNumberValidationOperation : AValidationOperation
    {
        public override bool ValidateOperation(Reservation reservation)
        {
            return ValidateCardNumber(reservation.CardNumber);
        }

        private bool ValidateCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                return false;
            }

            if (!string.Equals(cardNumber, "test")
                && !Regex.Match(cardNumber, @"\d\d\d\d \d\d\d\d \d\d\d\d \d\d\d\d").Success)
            {
                return false;
            }

            if (!string.Equals(cardNumber, "test") && !ValidateCardWithProvider(cardNumber))
            {
                return false;
            }
            return true;
        }

        private bool ValidateCardWithProvider(string cardNumber)
        {
            return true;
        }
    }
}
