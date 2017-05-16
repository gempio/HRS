using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HRS.NunitTests
{
    using System.Data;

    using HRS.Process.ReservationOperations;
    using HRS.Types.AbstractClasses;
    using HRS.Types.Exceptions;
    using HRS.Types.Models;

    [TestFixture]
    public class SendRequestOperationChecks
    {
        private AReservationOperation _operation;
        
        private Reservation _reservation;

        [SetUp]
        public void SetUp()
        {
            _operation = new SendReservationRequestOperation(true);
            _reservation = new Reservation { Hotel = new Hotel { HotelId = 1 } };
        }

        [Test]
        public void ShouldSendToSupportedHotel()
        {
            OperationResult result = _operation.ReservationOperation(_reservation);
            Assert.True(result.OperationSuccess);
        }
        
        [Test]
        public void ShouldSendToUnsupportedHotel()
        {
            this._reservation.Hotel.HotelId = 9;
            Assert.Throws<OperationException>(() => _operation.ReservationOperation(_reservation));
        }
    }
}
