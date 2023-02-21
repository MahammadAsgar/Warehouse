using System.ComponentModel.DataAnnotations;

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
