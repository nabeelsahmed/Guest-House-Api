using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestHouseMSApi.Entities
{
    public class PartyStatus
    {
        public int partyID { get; set; }
        public string partyFirstName { get; set; }
        public string partyLastName { get; set; }
        public string partyCNIC { get; set; }
        public string partyMobile { get; set; }
        public string Status { get; set; }
    }
}