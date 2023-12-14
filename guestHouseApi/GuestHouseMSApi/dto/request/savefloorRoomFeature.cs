using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class savefloorRoomFeature
    {
        public int floorRoomFeatureID { get; set; }
        public string floorRoomName { get; set; }
        public int floorID { get; set; }
        public int branch_id { get; set; }
        public int roomFeatureID { get; set; }
        public int userID { get; set; }
        public string json { get; set; }
        public string sptype  { get; set; }
    }
}