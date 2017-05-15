using HRS.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.NunitTests.TestData
{
    public class TestHotelsData
    {
        public static List<Hotel> GetTestHotels()
        {
            var hotelList = new List<Hotel>();
            hotelList.Add(new Hotel { HotelId = 1, HotelName = "TestHotel1" });
            hotelList.Add(new Hotel { HotelId = 2, HotelName = "TestHotel2" });
            hotelList.Add(new Hotel { HotelId = 3, HotelName = "TestHotel3" });
            return hotelList;
        }
    }
}
