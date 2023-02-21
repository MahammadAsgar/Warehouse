using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Context;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;

namespace Warehouse.DataAccess.Repositories.Implementations.Main
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await GetAsQueryable()
                 .Include(x => x.Products)
                 .ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetActiveCategories()
        {
            return await GetAsQueryable()
                 .Include(x => x.Products)
                 .Where(x => x.IsActive == true)
                 .ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
