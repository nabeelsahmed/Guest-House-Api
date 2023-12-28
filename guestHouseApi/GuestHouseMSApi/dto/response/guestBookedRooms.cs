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
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public int branch_id { get; set; }
        public int status { get; set; }
        public string Availability { get; set; }
    }
}