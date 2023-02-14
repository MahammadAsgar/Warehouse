using Warehouse.DataAccess.Entities.Base;
using Warehouse.DataAccess.Entities.Users;

namespace Warehouse.DataAccess.Entities.Main
{
    public class Buying:EntityBase
    {
        public int MeasuredProductId { get; set; }
        public MeasuredProduct MeasuredProduct { get; set; }
        public double? UnitOfMeasure { get; set; }
        public bool IsActive { get; set; }
        public DateTime BuyingDate { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
