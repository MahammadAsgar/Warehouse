using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.Main
{
    public interface IBuyingService
    {
        Task<ServiceResult> AddBuying(AddBuyingDto buyingDto, int userId);
        Task<ServiceResult> GetBuying(int id);
        Task<ServiceResult> GetBuyings();
        Task<ServiceResult> GetBuyingsByUser(int userId);
    }
}
