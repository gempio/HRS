using HRS.Types.Enums;
using HRS.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.NunitTests.TestDataClasses
{
    public class TestRoomsData
    {
        public static List<Room> GetTestRooms()
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
    }
}
