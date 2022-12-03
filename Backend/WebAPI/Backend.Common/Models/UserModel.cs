using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Models
{
    public class UserUpdateModel
    {
        public string DisplayName { get; set; }
        public string Emai { get; set; }
        public bool EnableEmailNotification { get; set; }
        public IEnumerable<Guid> Roles { get; set; }
        public void Format()
        {
            DisplayName = DisplayName?.Trim() ?? string.Empty;
            Emai = Emai?.Trim() ?? string.Empty;
        }
    }

    public class UserModel : UserUpdateModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    public class UpdateUserPassWord
    {
        public string Password { get; set; }
    }

    public class UserFilterModel
    {
        public string SearchText { get; set; }
    }
    public class UserInformation: BaseModel
    {
        public string DisplayName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
