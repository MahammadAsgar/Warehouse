using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.Main
{
    public interface ISellingService
    {
        Task<ServiceResult> AddSelling(AddSellingDto sellingDto, int userId);
        Task<ServiceResult> GetSelling(int id);
        Task<ServiceResult> GetSellings();
        Task<ServiceResult> GetSellingByUser(int userId);
    }
}
