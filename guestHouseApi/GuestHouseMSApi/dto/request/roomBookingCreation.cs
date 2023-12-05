using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class RoomBookingCreation
    {
        public string partyFirstName { get; set; }
        public string partyLastName { get; set; }
        public string partyCNIC { get; set; }
        public string partyMobile { get; set; }
        public string partyNTN { get; set; }
        public int newRoomBookingID { get; set; }
        public string roomBookingDate { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public string checkInTime { get; set; }
        public string checkOutTime { get; set; }
        public int transactionType { get; set; }
        public string roomJson { get; set; }
        public string serviceJson { get; set; }
        public int userID { get; set; }
        public string spType { get; set; }
    }
}