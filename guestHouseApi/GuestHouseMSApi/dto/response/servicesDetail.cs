using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class ServicesDetail
    {
        public int serviceTypeID { get; set; }
        public string serviceBookingDate { get; set; }
        public string serviceTypeTitle { get; set; }
        public int serviceQuantity { get; set; }
        public int serviceID { get; set; }
        public string serviceTitle { get; set; }
        public float amount { get; set; }
        public int serviceParentID { get; set; }
        public string serviceParentTitle { get; set; }
          public int measurementUnitID { get; set; }
        public string measurementUnitTitle { get; set; }
        public int branch_id { get; set; }
        public string branch_name { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public string serviceImagePath { get; set; }
        public string serviceImageExt { get; set; }
    }
}