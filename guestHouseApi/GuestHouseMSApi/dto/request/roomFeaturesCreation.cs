using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class RoomFeaturesCreation
    {
        public int roomFeatureID { get; set; }
        public string roomFeatureTitle { get; set; }
        public int roomFeatureParentID { get; set; }

        public int userID { get; set; }
        public string spType { get; set; }
    }
}