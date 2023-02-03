using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.DataAccess.Repositories.Abstractions.Main
{
    public interface IStockRepository:IGenericRepository<Stock>
    {
        Task<Stock> GetStock(int id);
        Task<IEnumerable<Stock>> GetAllStocks();
        Task<IEnumerable<Stock>> GetActiveStocks();
        Task<Stock> GetStockByProduct(int productId);
    }
}
