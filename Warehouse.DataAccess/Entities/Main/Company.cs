using Warehouse.DataAccess.Entities.Base;
using Warehouse.DataAccess.Entities.Users;

namespace Warehouse.DataAccess.Entities.Main
{
    public class Company : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Selling> Sellings { get; set; }
        public ICollection<Buying> Buyings { get; set; }
        public ICollection<Product> Products { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Partner> Partners { get; set; }
    }
}
