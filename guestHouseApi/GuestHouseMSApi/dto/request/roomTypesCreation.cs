using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class RoomTypesCreation
    {
        public int roomTypeID { get; set; }
        public string roomTypeTitle { get; set; }
        public int userID { get; set; }
        public string spType { get; set; }
    }
}