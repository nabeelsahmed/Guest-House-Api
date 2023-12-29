using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class UpdateRoomReservation
    {
        public string transactionType { get; set; }
        public string reservationStatus { get; set; }
        public string Json { get; set; }
        public int userID { get; set; }
        public string spType { get; set; }
    }
}