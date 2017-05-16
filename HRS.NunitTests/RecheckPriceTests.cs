using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Process.ReservationOperations;
using HRS.Types.AbstractClasses;
using HRS.Types.Exceptions;
using HRS.Types.Models;

namespace HRS.NunitTests
{
    [TestFixture]
    public class RecheckPriceTests
    {
        private Reservation _reservation;
        private AReservationOperation _operation;

        [SetUp]
        public void SetUp()
        {
            _reservation = new Reservation {Price = 100};
            _operation = new RecheckPriceOperation(true);
        }

        [Test]
        public void ShouldSubmitRequest()
        {
            Assert.True(_operation.ReservationOperation(_reservation).OperationSuccess);
        }

        [Test]
        public void ShouldAlertOnPriceChange()
        {
            _reservation.Price = 1000.00;
            Assert.Throws<PriceCheckException>(() => _operation.ReservationOperation(_reservation));
        }
    }
}
