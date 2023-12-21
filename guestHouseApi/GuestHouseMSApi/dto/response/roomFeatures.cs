using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class RoomFeatures
    {
        public int roomFeatureID { get; set; }
        public string roomFeatureTitle { get; set; }
        public int roomFeatureParentID { get; set; }
        public string roomFeatureParentTitle { get; set; }
    }
}