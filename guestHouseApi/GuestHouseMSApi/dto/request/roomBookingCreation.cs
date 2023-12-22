using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class RoomBookingCreation
    {
        public int roomBookingID { get; set; }
        public int partyID { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public string checkInTime { get; set; }
        public string checkOutTime { get; set; }
        public string transactionType { get; set; }
       public string reservationStatus { get; set; }
        public string roomJson { get; set; }
        public int userID { get; set; }
        public string spType { get; set; }
    }
}