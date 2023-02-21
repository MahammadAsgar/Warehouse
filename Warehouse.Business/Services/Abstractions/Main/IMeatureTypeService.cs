using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.Main
{
    public interface IMeatureTypeService
    {
        Task<ServiceResult> AddMeatureType(AddMeasureTypeDto meatureType);
        Task<ServiceResult> UpdateMeatureType(AddMeasureTypeDto meatureType, int id);
        Task<ServiceResult> DeleteMeatureType(int id);
        Task<ServiceResult> GetMeatureType(int id);
        Task<ServiceResult> GetAllMeatureTypes();
        Task<ServiceResult> GetActiveMeatureTypes();
    }
}
