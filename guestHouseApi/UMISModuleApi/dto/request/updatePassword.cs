using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMISModuleApi.Entities
{
    public class UpdatePassword
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}