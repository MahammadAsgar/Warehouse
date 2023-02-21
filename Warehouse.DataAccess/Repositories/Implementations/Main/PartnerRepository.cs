using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Context;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;

namespace Warehouse.DataAccess.Repositories.Implementations.Main
{
    public class PartnerRepository : GenericRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
        {
        }

        public async Task<Partner> GetPartner(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.Companies)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Partner>> GetPartners()
        {
            return await GetAsQueryable()
                .Include(x => x.Companies)
                .ToListAsync();
        }

        public async Task<IEnumerable<Partner>> GetPartnersByCompany(int companyId)
        {
            return await GetAsQueryable()
                .Include(x => x.Companies)
                .Where(x => x.Companies.Any(y => y.Id == companyId))
                .ToListAsync();
        }
    }
}
