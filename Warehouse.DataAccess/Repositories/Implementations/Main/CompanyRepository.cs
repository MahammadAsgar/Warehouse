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
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
        {
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<Company> GetCompany(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Company> GetCompanyByUser(int userId)
        {
            return await GetAsQueryable()
                 .Where(x => x.ApplicationUserId == userId)
                 .FirstOrDefaultAsync();
        }
    }
}
