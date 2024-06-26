﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Models
{
    public class UserUpdateModel
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool EnableEmailNotification { get; set; }
        public IEnumerable<Guid> RoleIds { get; set; }

        public void Format()
        {
            DisplayName = DisplayName?.Trim() ?? string.Empty;
            Email = Email?.Trim() ?? string.Empty;
        }
    }

    public class UserModel : UserUpdateModel
    {
        public Guid Id { get; set; }
        public IEnumerable<RoleModel> Roles { get; set; }

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
