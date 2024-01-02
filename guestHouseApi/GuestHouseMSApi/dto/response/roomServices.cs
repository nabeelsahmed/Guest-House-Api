using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class RoomServices
    {
        public int roomServiceID { get; set; }
        public int roomBookingDetailID { get; set; }
        public int serviceTypeID { get; set; }
        public string serviceTypeTitle { get; set; }
        public int serviceID { get; set; }
        public string serviceTitle { get; set; }
        public int quantity { get; set; }
        public float amount { get; set; }
    }
}