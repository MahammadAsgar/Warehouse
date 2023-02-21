using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.Main
{
    public interface IStockService
    {
        Task<ServiceResult> GetStock(int id);
        Task<ServiceResult> GetStocks();
    }
}
