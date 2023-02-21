using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.DataAccess.Repositories.Abstractions.Main
{
    public interface IPartnerRepository : IGenericRepository<Partner>
    {
        Task<Partner> GetPartner(int id);
        Task<IEnumerable<Partner>> GetPartners();
        Task<IEnumerable<Partner>> GetPartnersByCompany(int companyId);
    }
}
