using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HRS.NunitTests
{
    using HRS.Process.ReservationOperations;
    using HRS.Types.AbstractClasses;
    using HRS.Types.Models;

    [TestFixture]
    public class SendEmailTests
    {
        private AReservationOperation _sendEmailOperation;

        [SetUp]
        public void SetUp()
        {
            _sendEmailOperation = new SendSuccessEmailOperation(new Reservation(), false);
        }

        [Test]
        public void ShouldSendOnValidEmailAddress()
        {
            OperationResult result = _sendEmailOperation.ReservationOperation(new Reservation { EmailAddress = "email@address.com" });
            Assert.AreEqual(true, result.OperationSuccess);
        }

        [Test]
        public void ShouldFailOnInvalidEmailAddress()
        {
            OperationResult result = _sendEmailOperation.ReservationOperation(new Reservation { EmailAddress = "2" });
            Assert.AreEqual(false, result.OperationSuccess);
        }
    }
}
