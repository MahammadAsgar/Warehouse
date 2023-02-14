using Warehouse.DataAccess.Entities.Base;
using Warehouse.DataAccess.Entities.Users;

namespace Warehouse.DataAccess.Entities.Main
{
    public class Selling:EntityBase
    {
        //public int MeasuredProductId { get; set; }
        public List<MeasuredProduct> MeasuredProducts { get; set; }
        public double? UnitOfMeasure { get; set; }
        public bool IsActive { get; set; }
        public DateTime SellingDate { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

