using System.Collections.Generic;
using HRS.Types.Models;

namespace HRS.NunitTests.TestDataClasses
{
    public static class TestHotelsData
    {
        public static List<Hotel> GetTestHotels()
        {
            var hotelList = new List<Hotel>
            {
                new Hotel {HotelId = 1, HotelName = "TestHotel1"},
                new Hotel {HotelId = 2, HotelName = "TestHotel2"},
                new Hotel {HotelId = 3, HotelName = "TestHotel3"}
            };
            return hotelList;
        }
    }
}