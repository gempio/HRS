using System;
using System.Collections.Generic;

namespace HRS.Types.Models
{
    public class Reservation
    {
        public Hotel Hotel { get; set; }
        public List<Room> Rooms { get; set; }
        public DateTime DateOfReservation { get; set; }
        public int NoOfReservees { get; set; }
        public int NightsToStay { get; set; }
        public double price { get; set; }
    }
}
