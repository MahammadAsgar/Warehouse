using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.DataAccess.Models
{
    public class ProductSeachModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryTitle { get; set; }
        public string MeatureTypeTitle { get; set; }
        public double? Volume { get; set; }
        public double? Weight { get; set; }
    }
}
