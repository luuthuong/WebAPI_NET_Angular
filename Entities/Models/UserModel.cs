using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserModel:IdentityUser
    {
        public string? DisplayName { get; set; }
        public bool? Sex { get; set; }
        
        public string? Adress { get; set; }
        public DateTime? DateofBirth { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public bool? isDeactived { get; set; } = false;
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiredTime { get; set; }
    }
}
