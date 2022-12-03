using Backend.Common.Constants;
using Backend.Common.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities.Entities
{
    [Table("User", Schema = SchemaConstants.App)]
    public class User: IdentityUser<Guid>
    {
        public string DisplayName { get; set; }
        public StatusEnum Status { get; set; }
        public bool Sex { get; set; }
        public string Adress { get; set; }
        public DateTime? DateofBirth { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public bool EnableEmailNotification { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public DateTime LastLogin { get; set; }
        public string Intro { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
