using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Business.Dtos.Post.User
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int Gender { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifrələr eyni deyil")]
        public string ConfirmPassword { get; set; }
    }
}
