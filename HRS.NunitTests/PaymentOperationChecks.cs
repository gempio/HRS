using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Exceptions;
using NUnit.Framework;
namespace HRS.NunitTests
{
    using HRS.Process.ReservationOperations;
    using HRS.Types.AbstractClasses;
    using HRS.Types.Models;

    [TestFixture]
    public class PaymentOperationChecks
    {
        private Reservation _reservation;

        private AReservationOperation _operation;

        [SetUp]
        public void SetUp()
        {
           _reservation = new Reservation{CardNumber = "test", Price=100}; 
           _operation = new ProcessPaymentOperation(false);
        }

        [Test]
        public void ShouldProcessPayment()
        {
            OperationResult result = _operation.ReservationOperation(_reservation);
            Assert.True(result.OperationSuccess);
        }

        [Test]
        public void FailNegativePrice()
        {
            _reservation.Price = -10000000.00;
            Assert.Throws<OperationException>(() => _operation.ReservationOperation(_reservation));
        }

        [Test]
        public void FailOnMissingCardNumber()
        {
            _reservation.CardNumber = null;
            Assert.Throws<OperationException>(() => _operation.ReservationOperation(_reservation));
        }

        [Test]
        public void FailZeroPrice()
        {
            _reservation.Price = 0;
            Assert.Throws<OperationException>(() => _operation.ReservationOperation(_reservation));
        }
    }
}
