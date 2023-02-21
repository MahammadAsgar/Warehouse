using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Entities.Main
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
