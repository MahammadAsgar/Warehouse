using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Entities.Main
{
    public class File: EntityBase
    {
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}
