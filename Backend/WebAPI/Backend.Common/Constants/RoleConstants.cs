using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Constants
{
    public class RoleConstants
    {
        public static Guid AdminId = new Guid("02b5492d-33b7-454b-ac71-a4a817eadd6d");
        public static Guid ReaderId = new Guid("b3fb35f4-a16e-4d86-9cd2-7a23a22f26b7");
        public const string Admin = "Admin";
        public const string Reader = "Reader";
    }
}
