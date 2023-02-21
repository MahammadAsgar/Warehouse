using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Entities.Main
{
    public class Depot : EntityBase
    {
        public ICollection<Stock> Stocks { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
