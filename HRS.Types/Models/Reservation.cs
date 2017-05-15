using System;
using System.Collections.Generic;

namespace HRS.Types.Models
{
    /*
     * TODO: Normally card details and user details would be in separate classes. This will get changed in the
     * future release.
     */
    public class Reservation
    {
        public string ReservationId { get; set; }
        public string ReserveeName { get; set; }
        public Hotel Hotel { get; set; }
        public List<Room> Rooms { get; set; }
        public DateTime DateOfReservation { get; set; }
        public int NoOfReservees { get; set; }
        public int NightsToStay { get; set; }
        public double Price { get; set; }
        public string CardNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
