

using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.DataAccess.Repositories.Abstractions.Main
{
    public interface IDepotRepository : IGenericRepository<Depot>
    {
        Task<Depot> GetDepot(int id);
        Task<IEnumerable<Depot>> GetAllDepot();
        Task<IEnumerable<Depot>> GetActiveDepot();
        Task<Depot> GetDepotByStock(int stockId);
        Task<Depot> GetCurrentDepot();
    }
}
