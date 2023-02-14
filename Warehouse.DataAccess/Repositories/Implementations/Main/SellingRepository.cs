using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Context;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;

namespace Warehouse.DataAccess.Repositories.Implementations.Main
{
    public class SellingRepository : GenericRepository<Selling>, ISellingRepository
    {
        public SellingRepository(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
        {
        }

        public async Task<IEnumerable<Selling>> GetActiveSellings()
        {
            return await GetAsQueryable()
                .Include(x => x.MeasuredProducts)
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Selling>> GetAllSellings()
        {
            return await GetAsQueryable()
                .Include(x => x.MeasuredProducts)
                .ToListAsync();
        }

        public async Task<Selling> GetSelling(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.MeasuredProducts)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Selling>> GetSellingsByUser(int userId)
        {
            return await GetAsQueryable()
               .Include(x => x.MeasuredProducts)
               .Where(x => x.ApplicationUserId == userId&&x.IsActive==true)
               .ToListAsync();
        }
    }
}
