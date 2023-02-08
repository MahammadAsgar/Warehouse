using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Context;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;

namespace Warehouse.DataAccess.Repositories.Implementations.Main
{
    public class BuyingRepository : GenericRepository<Buying>, IBuyingRepository
    {
        public BuyingRepository(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
        {
        }

        public async Task<IEnumerable<Buying>> GetActiveBuyings()
        {
            return await GetAsQueryable()
                .Include(x => x.Product)
                .Include(x => x.MeasureType)
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Buying>> GetAllBuyings()
        {
            return await GetAsQueryable()
                .Include(x => x.Product)
                .Include(x => x.MeasureType)
                .ToListAsync();
        }

        public async Task<Buying> GetBuying(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.Product)
                .Include(x => x.MeasureType)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Buying>> GetBuyingsByUser(int userId)
        {
            return await GetAsQueryable()
                .Include(x => x.Product)
                .Include(x => x.MeasureType)
                .Where(x => x.ApplicationUserId == userId&&x.IsActive==true)
                .ToListAsync();
        }
    }
}
