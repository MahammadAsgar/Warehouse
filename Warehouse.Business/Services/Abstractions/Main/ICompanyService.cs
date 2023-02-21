using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.Main
{
    public interface ICompanyService
    {
        Task<ServiceResult> AddCompany(AddCompanyDto companyDto, int userId);
        Task<ServiceResult> GetCompany(int id);
        Task<ServiceResult> GetCompanyByUser(int userId);
        Task<ServiceResult> GetCompanies();
    }
}
