using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Models;

namespace Warehouse.DataAccess.Repositories.Abstractions.Main
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetActiveProducts();
        Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
        Task<IEnumerable<Product>> GetProductsByMeatureType(int meatureId);
        IQueryable<Product> SearcProduct(ProductSeachModel searchModel, string sortField);
    }
}
