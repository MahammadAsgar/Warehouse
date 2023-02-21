
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.Main
{
    public interface IPartnerService
    {
        Task<ServiceResult> AddPartner(AddPartnerDto partnerDto);
        Task<ServiceResult> GetPartnersByCompany(int companyId);
        Task<ServiceResult> GetPartner(int id);
        Task<ServiceResult> GetPartners();
    }
}
