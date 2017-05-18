using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.NunitTests.TestDataClasses;
using HRS.Process.Validators;
using HRS.Types.Models;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace HRS.NunitTests
{
    [TestFixture]
    class ReservationValidation
    {
        private Reservation _reservation;

        [SetUp]
        public void SetUp()
        {
            _reservation = TestReservationData.GetTestReservation();
        }

        [Test]
        public void ShouldPassValidReservation()
        {
            Assert.True(ReservationValidator.ValidateReservation(_reservation));
        }

        [Test]
        public void ShouldFailOnBackdating()
        {
            _reservation.DateOfReservation = _reservation.DateOfReservation.AddYears(-4);
            Assert.False(ReservationValidator.ValidateReservation(_reservation));
        }

        [Test]
        public void ShouldFailOnTooFarAhead()
        {
            _reservation.DateOfReservation = _reservation.DateOfReservation.AddYears(1);
            Assert.False(ReservationValidator.ValidateReservation(_reservation));
        }
    }
}
