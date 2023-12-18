using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class ServiceChargesCreation
    {
        public int roomServiceID { get; set; }
        public int roomBookingID { get; set; }
        public int serviceID { get; set; }
        public float serviceQuantity { get; set; }
        public int userID { get; set; }
        public string spType { get; set; }
    }
}