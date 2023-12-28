using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class GuestBookingRecord
    {

        public string company_name { get; set; }
        public string branch_name { get; set; }
        public int partyID { get; set; }
        public string partyFirstName { get; set; }
        public string partyLastName { get; set; }
        public string partyCNIC { get; set; }
        public string partyMobile { get; set; }
        public string partyEmail { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public string rooms { get; set; }
        public string roomServices { get; set; }
    }
}