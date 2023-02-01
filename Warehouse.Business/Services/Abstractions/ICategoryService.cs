using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Business.Dtos.Post;
using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ServiceResult> AddCategory(AddCategoryDto category);
        Task<ServiceResult> UpdateCategory(AddCategoryDto category, int id);
        Task<ServiceResult> DeleteCategory(int id);
        Task<ServiceResult> GetCategory(int id);
        Task<ServiceResult> GetCategories();
    }
}
