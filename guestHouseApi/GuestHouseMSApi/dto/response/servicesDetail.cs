using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class ServicesDetail
    {
        public int serviceTypeID { get; set; }
        public string serviceDate { get; set; }
        public string serviceTypeTitle { get; set; }
        public float serviceQuantity { get; set; }
        public int serviceID { get; set; }
        public string serviceTitle { get; set; }
        public float amount { get; set; }
        public int serviceParentID { get; set; }
        public string serviceParentTitle { get; set; }
    }
}