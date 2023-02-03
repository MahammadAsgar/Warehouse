using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Context;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;

namespace Warehouse.DataAccess.Repositories.Implementations.Main
{
    public class DepotRepository : GenericRepository<Depot>, IDepotRepository
    {
        public DepotRepository(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
        {
        }

        public async Task<IEnumerable<Depot>> GetActiveDepot()
        {
            return await GetAsQueryable()
                .Include(x => x.Stocks)
                .ThenInclude(x => x.Product)
                .Include(x => x.Stocks)
                .ThenInclude(x => x.MeasureType)
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Depot>> GetAllDepot()
        {
            return await GetAsQueryable()
                .Include(x => x.Stocks)
                .ThenInclude(x => x.Product)
                .Include(x => x.Stocks)
                .ThenInclude(x => x.MeasureType)
                .ToListAsync();
        }
        public async Task<Depot> GetCurrentDepot()
        {
            return await GetAsQueryable()
                .Include(x => x.Stocks)
                .ThenInclude(x => x.Product)
                .Include(x => x.Stocks)
                .ThenInclude(x => x.MeasureType)
                .FirstOrDefaultAsync();
        }

        public async Task<Depot> GetDepot(int id)
        {
            return await GetAsQueryable()
                  .Include(x => x.Stocks)
                  .ThenInclude(x => x.Product)
                  .Include(x => x.Stocks)
                  .ThenInclude(x => x.MeasureType)
                  .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Depot> GetDepotByStock(int stockId)
        {
            return await GetAsQueryable()
                .Include(x => x.Stocks)
                .Where(x => x.Stocks.Any(x => x.Id == stockId))
                .FirstOrDefaultAsync();
        }
    }
}
