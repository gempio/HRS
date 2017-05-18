namespace HRS.ConsoleHarness
{
    using System;
    using System.Collections.Generic;
    using NunitTests.TestDataClasses;
    using Types.Enums;
    using Types.Models;

    static class Program
    {
        public static void Main(string[] args)
        {
            List<Hotel> hotelList = TestHotelsData.GetTestHotels();
            List<Room> roomList = TestRoomsData.GetTestRooms();
            Reservation reservation = new Reservation();

            Console.WriteLine("Welcome to HRS Console Harness");


            foreach (Hotel hotel in hotelList)
            {
                Console.WriteLine("{0}. {1}", hotel.HotelId, hotel.HotelName);
            }
            var chosenHotel = GetUserInput<int>("Please select a hotel: ", ReturnTypeEnum.Int);
            reservation.Hotel = hotelList[chosenHotel - 1];


            foreach (Room room in roomList)
            {
                Console.WriteLine(
                    "{0}. No of Single Beds: " +
                    "{1}, No of Double Beds {2} " +
                    "No of Queen Beds {3}", 
                    room.RoomTypeEnum, 
                    room.NoOfSingleBeds, 
                    room.NoOfDoubleBeds, 
                    room.NoOfQueenBeds
                    );
            }
            int chosenRoom = GetUserInput<int>("Please Select a room: ", ReturnTypeEnum.Int);
            reservation.Rooms = new List<Room> {roomList[chosenRoom - 1]};

            reservation.DateOfReservation = GetUserInput<DateTime>("Please type in reservation date in dd/mm/yyyy: ", ReturnTypeEnum.DateTime);

            reservation.NightsToStay = GetUserInput<int>("Please type in no. of nights to stay: ", ReturnTypeEnum.Int);

            reservation.NoOfReservees = GetUserInput<int>("Please enter amount of adults: ", ReturnTypeEnum.Int);

            Console.WriteLine("The price for the room is {0}", GetReservationPrice(reservation));
            Console.WriteLine("Do you accept this reservation? ");

            Console.ReadLine();

            reservation.Price = GetReservationPrice(reservation);
            reservation.CardNumber = GetUserInput<string>("Please type in your card number: ", ReturnTypeEnum.String); 
            Console.WriteLine("Card number used: {0}", reservation.CardNumber);

            reservation.EmailAddress = GetUserInput<string>("Please type in your email address: ", ReturnTypeEnum.String); 
            Console.WriteLine("Email Address User: {0}", reservation.EmailAddress);

            reservation.ReservationId = TestUtility.GenerateReservationId();
            Console.WriteLine("Processing reservation: {0}", reservation.ReservationId);

            HotelReservationModule hrm = new HotelReservationModule("user", "pass");
            ReservationResult result = hrm.MakeReservation(reservation);

            Console.WriteLine("Process Completed. Reservation result: {0}", result.Success);
            if (!result.Success)
            {
                Console.Write("Reason for failure: {0}", result.AdditionalInfo);
            }

            Console.ReadLine();
        }

        private static double GetReservationPrice(Reservation reservation)
        {
            return 50 * (int)reservation.Rooms[0].RoomTypeEnum * reservation.NightsToStay *
                   reservation.NoOfReservees * reservation.Hotel.HotelId * 0.7;
        }

        private static T GetUserInput<T>(string message, ReturnTypeEnum returnType)
        {
            try
            {
                Console.Write(message);
                string input = Console.ReadLine();
                return (T) ReturnObjectType(input, returnType);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please try again.");
                return (T) GetUserInput<T>(message, returnType);
            }
        }

        private static object ReturnObjectType(string input, ReturnTypeEnum returnType)
        {
            switch (returnType)
            {
                case ReturnTypeEnum.String: return input;
                case ReturnTypeEnum.Int: return int.Parse(input);
                case ReturnTypeEnum.Double: return double.Parse(input);
                case ReturnTypeEnum.DateTime: return DateTime.Parse(input);
                default: return null;
            }
        }
    }
}
