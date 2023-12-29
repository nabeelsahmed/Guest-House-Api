using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class FoodRoomServicesCreation
    {
        public int roomServiceID { get; set; }
        public int roomBookingDetailID { get; set; }
        public int userID { get; set; }
        public string json { get; set; }
        public string spType  { get; set; }
    }
}