using Microsoft.AspNetCore.Identity;

namespace Warehouse.DataAccess.Entities.Users
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
