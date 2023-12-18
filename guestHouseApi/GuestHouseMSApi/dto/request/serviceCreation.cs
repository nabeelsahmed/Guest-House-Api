using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class ServiceCreation
    {
        public int serviceID { get; set; }
        public int serviceParentID { get; set; }
        public int serviceTypeID { get; set; }
        public string serviceTitle { get; set; }
        public int branch_id { get; set; }
        public float serviceCharges { get; set; }
        public int measurementUnitID { get; set; }
        public string serviceImagePath { get; set; }
        public string serviceImageExt { get; set; }
        public int userID { get; set; }
        public string spType { get; set; }
    }
}