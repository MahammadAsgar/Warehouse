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
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        public StockRepository(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
        {
        }

        public async Task<IEnumerable<Stock>> GetActiveStocks()
        {
            return await GetAsQueryable()
                 .Include(x => x.Product)
                 .Include(x => x.MeasureType)
                 .Where(x => x.IsActive == true)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Stock>> GetAllStocks()
        {
            return await GetAsQueryable()
                .Include(x => x.Product)
                .Include(x => x.MeasureType)
                .ToListAsync();
        }

        public async Task<Stock> GetStock(int id)
        {
            return await GetAsQueryable()
                            .Include(x => x.Product)
                            .Include(x => x.MeasureType)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Stock> GetStockByProduct(int productId)
        {
            return await GetAsQueryable()
                .Include(x => x.Product)
                .Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync();
        }
    }
}
