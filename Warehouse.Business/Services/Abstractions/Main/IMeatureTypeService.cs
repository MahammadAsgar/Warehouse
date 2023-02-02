using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.Main
{
    public interface IMeatureTypeService
    {
        Task<ServiceResult> AddMeatureType(AddMeatureTypeDto meatureType);
        Task<ServiceResult> UpdateMeatureType(AddMeatureTypeDto meatureType, int id);
        Task<ServiceResult> DeleteMeatureType(int id);
        Task<ServiceResult> GetMeatureType(int id);
        Task<ServiceResult> GetAllMeatureTypes();
        Task<ServiceResult> GetActiveMeatureTypes();
    }
}
