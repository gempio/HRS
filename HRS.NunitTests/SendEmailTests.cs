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
    using HRS.Types.Exceptions;
    using HRS.Types.Models;

    [TestFixture]
    public class SendEmailTests
    {
        private AReservationOperation _sendEmailOperation;

        private Reservation _reservation;

        [SetUp]
        public void SetUp()
        {
            _reservation = new Reservation{EmailAddress = "Email Address"};
            
            _sendEmailOperation = new SendSuccessEmailOperation(false);
        }

        [Test]
        public void ShouldSendOnValidEmailAddress()
        {
            OperationResult result = _sendEmailOperation.ReservationOperation(_reservation);
            Assert.True(result.OperationSuccess);
        }

        [Test]
        public void ShouldFailOnInvalidEmailAddress()
        {
            _reservation.EmailAddress = "bot";
            Assert.Throws<OperationException>(() => _sendEmailOperation.ReservationOperation(_reservation));
        }
    }
}
