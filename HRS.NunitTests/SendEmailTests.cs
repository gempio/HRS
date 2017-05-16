using NUnit.Framework;
using HRS.Process.ReservationOperations;
using HRS.Types.AbstractClasses;
using HRS.Types.Exceptions;
using HRS.Types.Models;

namespace HRS.NunitTests
{
    [TestFixture]
    public class SendEmailTests
    {
        private AReservationOperation _sendEmailOperation;

        private Reservation _reservation;

        [SetUp]
        public void SetUp()
        {
            _reservation = new Reservation {EmailAddress = "test@somewhere.com"};

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