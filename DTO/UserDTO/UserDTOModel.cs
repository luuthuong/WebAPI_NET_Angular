using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO
{
    public class UserDTOModel : DTOBase
    {
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? Sex { get; set; }
        public string? Adress { get; set; }
        public DateTime? DateofBirth { get; set; }

        public UserDTOModel (UserModel user)
        {
            Id = user.Id;
            UserName = user.UserName;
            DisplayName = user.DisplayName;
            Sex = user.Sex;
            Adress = user.Adress;
            DateofBirth = user.DateofBirth;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
        }
        public UserDTOModel() { }
    }
}
