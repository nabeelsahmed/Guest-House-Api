using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class GuestBookedRecord
    {
        public int roomBookingID { get; set; }
        public int partyID { get; set; }
        public string partyFirstName { get; set; }
        public string partyLastName { get; set; }
        public string partyCNIC { get; set; }
        public string partyMobile { get; set; }
        public string partyEmail { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public string checkInTime { get; set; }
        public string checkOutTime { get; set; }
        public string reservationStatus { get; set; }
        public string transactionType { get; set; }
        public int branch_id { get; set; }
    }
}