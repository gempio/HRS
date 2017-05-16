using System.Collections.Generic;
using HRS.Types.Enums;
using HRS.Types.Models;

namespace HRS.NunitTests.TestDataClasses
{
    public static class TestRoomsData
    {
        public static List<Room> GetTestRooms()
        {
            var roomList = new List<Room>
            {
                new Room
                {
                    NoOfSingleBeds = 1,
                    RoomTypeEnum = RoomTypeEnum.Single
                },
                new Room
                {
                    NoOfSingleBeds = 2,
                    RoomTypeEnum = RoomTypeEnum.Double
                },
                new Room
                {
                    NoOfQueenBeds = 1,
                    RoomTypeEnum = RoomTypeEnum.Deluxe
                }
            };


            return roomList;
        }
    }
}