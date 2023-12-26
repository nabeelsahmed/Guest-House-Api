using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class GuestBookedRooms
    {
        public int floorID { get; set; }
        public string floorNo { get; set; }
        public int floorRoomID { get; set; }
        public string floorRoomNo { get; set; }
        public int roomTypeID { get; set; }
        public string roomtTypeTitle { get; set; }
        public int status { get; set; }
    }
}