using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Models;

namespace HRS.NunitTests.TestDataClasses
{
    class TestReservationData
    {
        public static Reservation GetTestReservation()
        {
            return new Reservation
            {
                CardNumber = "test",
                DateOfReservation = DateTime.Now.AddDays(1),
                EmailAddress = "test@test.com",
                Hotel = TestHotelsData.GetTestHotels()[0],
                NightsToStay = 2,
                NoOfReservees = 2,
                Price = 1000,
                ReservationId = TestUtility.GenerateReservationId(),
                ReserveeName = "Tester Class",
                Rooms = TestRoomsData.GetTestRooms()
            };
        }
    }
}
