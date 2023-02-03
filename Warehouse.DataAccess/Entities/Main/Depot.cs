using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Entities.Main
{
    public class Depot : EntityBase 
    {
        public ICollection<Stock> Stocks { get; set; }
        public bool IsActive { get; set; }
    }
}
