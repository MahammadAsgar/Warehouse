using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.DataAccess.Repositories.Abstractions.Main
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<Category>> GetActiveCategories();
        Task<Category> GetCategory(int id);
    }
}
