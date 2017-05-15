using System;
using System.Collections.Generic;

namespace HRS.Types.Models
{
    public class Reservation
    {
        public Hotel Hotel { get; set; }
        public List<Room> Rooms { get; set; }
        public DateTime DateOfReservation { get; set; }
        public long NoOfReservees { get; set; }
        public long NightsToStay { get; set; }
        public double price { get; set; }
    }
}
