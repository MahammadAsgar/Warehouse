using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Warehouse.DataAccess.Context;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Extensions;
using Warehouse.DataAccess.Models;
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
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await GetAsQueryable()
                .Include(x => x.ProductFiles)
                .Include(x => x.Category)
                .Include(x => x)
                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await GetAsQueryable()
                .Include(x => x.ProductFiles)
                .Include(x => x.Category)
                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetActiveProducts()
        {
            return await GetAsQueryable()
                .Include(x => x.ProductFiles)
                .Include(x => x.Category)
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            return await GetAsQueryable()
                .Include(x => x.ProductFiles)
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId && x.IsActive == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByMeatureType(int meatureId)
        {
            return await GetAsQueryable()
               .Include(x => x.ProductFiles)
               .Include(x => x.Category)
               .ToListAsync();
        }

        public IQueryable<Product> SearcProduct(ProductSeachModel searchModel)
        {
            var data = GetAsQueryable()
                         .Include(x => x.Category)
                         .Include(x => x.ProductFiles)
                         .Where(GeneratePredicate(searchModel))
                         .OrderBy("Id");
            return data;
        }

        private Expression<Func<Product, bool>> GeneratePredicate(ProductSeachModel searchModel)
        {
            var predicate = PredicateBuilder.True<Product>();
            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                predicate = predicate.And(x => x.Name == searchModel.Name);
            }

            if (!string.IsNullOrEmpty(searchModel.CategoryTitle))
            {
                predicate = predicate.And(x => x.Category.Name == searchModel.CategoryTitle);
            }

    

            return predicate;
        }
    }
}
