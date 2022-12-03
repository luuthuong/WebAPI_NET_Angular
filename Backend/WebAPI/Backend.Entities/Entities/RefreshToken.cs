using Backend.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities.Entities
{
    [Table("RefreshToken",Schema = SchemaConstants.App)]
    public class RefreshToken
    {
        public string Token { get; set; }
        public string OriginalToken { get; set; }
        public DateTimeOffset Expires { get; set; }
        public bool IsExpired { get => DateTimeOffset.UtcNow >= Expires;}
        public DateTimeOffset Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTimeOffset? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
