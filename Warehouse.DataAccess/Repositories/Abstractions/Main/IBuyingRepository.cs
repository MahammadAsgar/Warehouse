using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.DataAccess.Repositories.Abstractions.Main
{
    public interface IBuyingRepository:IGenericRepository<Buying>
    {
        Task<Buying> GetBuying(int id);
        Task<IEnumerable<Buying>> GetAllBuyings();
        Task<IEnumerable<Buying>> GetActiveBuyings();
        Task<IEnumerable<Buying>> GetBuyingsByUser(int userId);
    }
}
