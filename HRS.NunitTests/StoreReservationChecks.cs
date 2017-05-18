using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.NunitTests.TestDataClasses;
using HRS.Process.ReservationOperations;
using HRS.Types.AbstractClasses;
using HRS.Types.Models;
using NUnit.Framework;

namespace HRS.NunitTests
{
    [TestFixture]
    class StoreReservationChecks
    {
        private Reservation _reservation;
        private AReservationOperation _storeReservationOperation;

        [SetUp]
        public void SetUp()
        {
            _reservation = TestReservationData.GetTestReservation();
            _storeReservationOperation = new StoreReservationOperation(false);
        }

        [Test]
        public void ShouldStoreValidReservation()
        {
            Assert.True(_storeReservationOperation.ReservationOperation(_reservation).OperationSuccess);
        }

        [Test]
        public void ShouldFailOnMissingReservationId()
        {
            _reservation.ReservationId = null;
            Assert.Throws<InvalidOperationException>(() => _storeReservationOperation.ReservationOperation(_reservation));
        }
    }
}
