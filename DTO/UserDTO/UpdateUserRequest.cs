using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO
{
    public  class UpdateUserRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DisplayName { get; set; }
        public bool? Sex { get; set; }
        public string? Adress { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
