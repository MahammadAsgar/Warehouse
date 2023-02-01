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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
        {
        }

        public async Task<Product> GetProduct(int id)
        {
            return await GetAsQueryable()
                 .Include(x => x.ProductFiles)
                 .Include(x => x.Category)
                 .Include(x => x.MeatureType)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await GetAsQueryable()
                .Include(x => x.ProductFiles)
                .Include(x => x.Category)
                .Include(x => x.MeatureType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            return await GetAsQueryable()
                .Include(x => x.ProductFiles)
                .Include(x => x.Category)
                .Include(x => x.MeatureType)
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByMeatureType(int meatureId)
        {
            return await GetAsQueryable()
               .Include(x => x.ProductFiles)
               .Include(x => x.Category)
               .Include(x => x.MeatureType)
               .Where(x => x.MeatureTypeId == meatureId)
               .ToListAsync();
        }
    }
}
