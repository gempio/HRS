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
    public class PaymentOperationChecks
    {
        private Reservation reservation;

        private AReservationOperation operation;

        [SetUp]
        public void SetUp()
        {
           reservation = new Reservation{Price=100}; 
           operation = new ProcessPaymentOperation(reservation, false);
        }

        [Test]
        public void ShouldProcessPayment()
        {
            OperationResult result = operation.ReservationOperation(reservation);
            Assert.True(result.OperationSuccess);
        }

        [Test]
        public void FailNegativePrice()
        {
            reservation.Price = -10000000.00;
            Assert.Throws<InvalidOperationException>(() => operation.ReservationOperation(reservation));
        }

        [Test]
        public void FailZeroPrice()
        {
            reservation.Price = 0;
            Assert.Throws<InvalidOperationException>(() => operation.ReservationOperation(reservation));
        }
    }
}
