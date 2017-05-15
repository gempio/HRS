using HRS.NunitTests.TestData;
using HRS.NunitTests.TestDataClasses;
using HRS.Process.Operations;
using HRS.Types.Enums;
using HRS.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRS.ConsoleHarness
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Hotel> hotelList = TestHotelsData.GetTestHotels();
            List<Room> roomList = TestRoomsData.GetTestRooms();
            Reservation reservation = new Reservation();

            Console.WriteLine("Welcome to HRS Console Harness");
            Console.WriteLine("Athenticating User");
            UserAuthentication.AuthenticateUser("user", "pass");
            Console.ReadLine();
            Console.WriteLine("Authentication passed");

            Console.WriteLine("Please select a hotel:");
            foreach(Hotel hotel in hotelList)
            {
                Console.WriteLine(string.Format("{0}. {1}", hotel.HotelId, hotel.HotelName));
            }
            reservation.Hotel = hotelList[int.Parse(Console.ReadLine())];

            Console.WriteLine("Please Select a room:");
            foreach(Room room in roomList)
            {
                Console.WriteLine(
                    string.Format("{0}. No of Single Beds: " +
                    "{1}, No of Double Beds {2} " +
                    "No of Queen Beds {3}", 
                    room.RoomTypeEnum, 
                    room.NoOfSingleBeds, 
                    room.NoOfDoubleBeds, 
                    room.NoOfQueenBeds
                    ));
            }
            reservation.Rooms = new List<Room>();
            reservation.Rooms.Add(roomList[int.Parse(Console.ReadLine())]);

            Console.WriteLine("Please type in reservation date in dd/mm/yyyy");

            reservation.DateOfReservation = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please type in no of nights to stay:");

            reservation.NightsToStay = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter amount of adults: ");

            reservation.NoOfReservees = int.Parse(Console.ReadLine());

            Console.WriteLine("The price for the room is {0}", GetReservationPrice(reservation));
            Console.WriteLine("Do you accept this reservation?");

            Console.ReadLine();

            Console.Write("Please type in your card number: ");
            reservation.CardNumber = Console.ReadLine();
            Console.WriteLine(string.Format("Card number used: {0}", reservation.CardNumber));

            Console.Write("Please type in your email address: ");
            reservation.EmailAddress = Console.ReadLine();
            Console.WriteLine("Email Address User: {0}", reservation.EmailAddress);

            reservation.ReservationId = TestUtility.GenerateReservationId();
            Console.Write("Processing reservation: {0}", reservation.ReservationId);

            HotelReservationModule hrm = new HotelReservationModule("user", "pass");
            hrm.MakeReservation(reservation);

            Console.WriteLine("Process Completed");

            Console.ReadLine();
        }

        private static double GetReservationPrice(Reservation reservation)
        {
            return (double) (50*((int) reservation.Rooms[0].RoomTypeEnum)*reservation.NightsToStay*reservation.NoOfReservees*reservation.Hotel.HotelId)*0.7;
        }
    }
}
