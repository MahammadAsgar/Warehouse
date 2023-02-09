using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Business.Dtos.Post.Main
{
    public class ProductSearchModelDto
    {
        public string? Name { get; set; }
        public string? CategoryTitle { get; set; }
        public DateTime? SellingDate { get; set; }
        public DateTime? BuyingDate { get; set; }
    }
}
