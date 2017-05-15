﻿using HRS.Process.Operations;
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
            List<Hotel> hotelList = GetHotels();
            List<Room> roomList = GetRooms();


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
            Hotel chosenHotel = hotelList[int.Parse(Console.ReadLine())];

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
            Room chosenRoom = roomList[int.Parse(Console.ReadLine())];

            Console.WriteLine("Please type in reservation date in dd/mm/yyyy");

            DateTime chosenDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please type in no of nights to stay:");

            int NightsToStay = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter amount of adults: ");

            int NoOfReservees = int.Parse(Console.ReadLine());

            Console.WriteLine("The price for the room is {0}", GetReservationPrice(chosenHotel,chosenRoom,NightsToStay,NoOfReservees));
            Console.WriteLine("Do you accept this reservation?");

            Console.ReadLine();

            Console.Write("Please type in your card number: ");
            string cardnumber = Console.ReadLine();
            Console.WriteLine(string.Format("Card number used: {0}", cardnumber));

            Console.Write("Please type in your email address: ");
            string emailAddress = Console.ReadLine();
            Console.WriteLine("Email Address User: {0}", emailAddress);

            Console.Write("Processing reservation");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000); 
            Console.WriteLine("Payment Confirmed");
            Thread.Sleep(1000);
            Console.WriteLine("Reservation confirmed");
            Thread.Sleep(1000);
            Console.WriteLine("Email successfully sent");

            Console.ReadLine();
        }
        
        private static List<Hotel> GetHotels()
        {
            var hotelList = new List<Hotel>();
            hotelList.Add(new Hotel { HotelId = 1, HotelName = "Hotel1" });
            hotelList.Add(new Hotel { HotelId = 2, HotelName = "Hotel2" });
            hotelList.Add(new Hotel { HotelId = 3, HotelName = "Hotel3" });
            return hotelList;
        }

        private static List<Room> GetRooms()
        {
            var roomList = new List<Room>();

            roomList.Add(
                new Room
                {
                    NoOfSingleBeds = 1,
                    RoomTypeEnum = RoomTypeEnum.Single
                });

            roomList.Add(
                new Room
                {
                    NoOfSingleBeds = 2,
                    RoomTypeEnum = RoomTypeEnum.Double
                });

            roomList.Add(
                new Room
                {
                    NoOfQueenBeds = 1,
                    RoomTypeEnum = RoomTypeEnum.Deluxe
                });

            return roomList;
        }

        private static double GetReservationPrice(Hotel hotel, Room room, int NightsToStay, int NoOfReservees)
        {
            return (double) (50*((int) room.RoomTypeEnum)*NightsToStay*NoOfReservees*hotel.HotelId)*0.7;
        }
    }
}
