using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class ParentService
    {
        public int parentServiceID { get; set; }
        public string serviceTitle { get; set; }
        public string serviceImagePath { get; set; }
        public string serviceImageExt { get; set; }
        public float serviceCharges { get; set; }
    }
}