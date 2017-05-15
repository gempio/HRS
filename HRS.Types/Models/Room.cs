using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRS.Types.Enums;

namespace HRS.Types.Models
{
    public class Room
    {
        public int NoOfSingleBeds { set; get; }
        public int NoOfDoubleBeds { set; get; }
        public int NoOfKingBeds { set; get; }
        public int NoOfQueenBeds { set; get; }
        public RoomTypeEnum RoomTypeEnum { set; get; }
    }
}
