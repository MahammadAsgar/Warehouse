using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.Main
{
    public interface IProductService
    {
        Task<ServiceResult> AddProduct(AddProductDto product, int userId);
        Task<ServiceResult> UpdateProduct(AddProductDto product, int id);
        Task<ServiceResult> DeleteProduct(int id);
        Task<ServiceResult> GetProduct(int id);
        Task<ServiceResult> GetProductByCategory(int categoryId);
        Task<ServiceResult> GetProductByMeature(int meatureId);
        Task<ServiceResult> GetAllProducts();
        Task<ServiceResult> GetActiveProducts();
        Task<ServiceResult> SearchProduct(int currentPage, int pageSize, ProductSearchModelDto documentSearchModel);
    }
}
