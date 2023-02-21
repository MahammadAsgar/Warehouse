using System.ComponentModel.DataAnnotations;

namespace Warehouse.Business.Dtos.Post.User
{
    public class AddClaimDto
    {
        [Required(ErrorMessage = "user id boş ola bilməz")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "claim adı boş ola bilməz")]
        public string ClaimName { get; set; }
        [Required(ErrorMessage = "claim tipi boş ola bilməz")]
        public string ClaimType { get; set; }
    }
}
