using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.Main
{
    public interface ISellingService
    { 
        Task<ServiceResult> AddSelling(AddSellingDto sellingDto);
        Task<ServiceResult> GetSelling(int id);
        Task<ServiceResult> GetSellings();
    }
}
