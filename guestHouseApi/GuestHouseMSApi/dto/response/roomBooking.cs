using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class RoomBooking
    {
        public int partyID { get; set; }
        public int roomBookingID { get; set; }
        public int roomBookingDetailID { get; set; }
        public string partyFirstName { get; set; }
        public string partyLastName { get; set; }
        public string partyCNIC { get; set; }
        public string partyMobile { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public string checkInTime { get; set; }
        public string checkOutTime { get; set; }
        public string reservationStatus { get; set; }
        public int floorRoomID { get; set; }
        public string floorRoomNo { get; set; }
        public int floorID { get; set; }
        public string floorNo { get; set; }
        public int roomTypeID { get; set; }
        public string roomtTypeTitle { get; set; }
        public string transactionType { get; set; }
        public int branch_id { get; set; }
        public string features { get; set; }
        public string services { get; set; }
        public string serviceJson { get; set; }
        public int rentPerNight { get; set; }
    }
}