using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.Main
{
    public interface IProductFileService
    {
        Task<ServiceResult> AddRangeAsync(AddProductDto productDto, int id);
        Task<ServiceResult> UpdateRangeAsync(AddProductDto productDto, int id);
    }
}
