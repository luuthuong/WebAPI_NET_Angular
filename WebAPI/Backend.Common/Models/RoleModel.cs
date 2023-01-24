using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Models
{
    public class RoleUpdateModel
    {
        public string Name { get; set; }
    }

    public class RoleModel : RoleUpdateModel
    {
        public Guid Id { get; set; }
    }

    public class RoleFilterModel
    {
        public string SearchText { get; set; }
    }
}
