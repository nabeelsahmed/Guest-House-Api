using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class RoomReservation
    {
        public int partyID { get; set; }
        public int roomBookingID { get; set; }
        public int floorRoomID { get; set; }
        public string partyFirstName { get; set; }
        public string partyLastName { get; set; }
        public string partyCNIC { get; set; }
        public string partyMobile { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public string checkInTime { get; set; }
        public string checkOutTime { get; set; }
        public string floorRoomNo { get; set; }
        public string roomtTypeTitle { get; set; }
        public int branch_id { get; set; }
        public string reservationStatusDate { get; set; }
    }
}