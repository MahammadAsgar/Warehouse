using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Business.Dtos.Post.Main
{
    public class AddCompanyDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> PartnerIds { get; set; }
    }
}
