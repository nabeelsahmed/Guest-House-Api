using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMISModuleApi.dto.request
{
    public class userCreation
    {
        public int userID { get; set; }
        public string userFullName { get; set; }
        public string userEmail { get; set; }
        public string userMobile { get; set; }
        public string userPassword { get; set; }
        public int usermode { get; set; }
        public string userImageDoc { get; set; }
        public int isDeleted { get; set; }
    }
}