using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class FloorRooms
    {
        public int floorID { get; set; }
        public string floorNo { get; set; }
        public int branch_id { get; set; }
        public string branch_name { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public int num { get; set; }
        public string rooms { get; set; }
    }
}