using Microsoft.AspNetCore.Identity;
using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.DataAccess.Entities.Users
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        //public int? CompanyId { get; set; }
       // public Company? Company { get; set; }
    }
}
