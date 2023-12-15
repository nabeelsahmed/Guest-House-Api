using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class FloorRoomCreation
    {
        public int floorRoomID { get; set; }
        public int floorID { get; set; }
        public int branch_id { get; set; }
        public int userID { get; set; }
        public string floorRoomNo  { get; set; }
        public string roomTypeID  { get; set; }
      //  public string json  { get; set; }
        public string spType { get; set; }
    }
}