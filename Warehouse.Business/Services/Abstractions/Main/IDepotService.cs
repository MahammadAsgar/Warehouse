using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.Main
{
    public interface IDepotService
    {
        Task<ServiceResult> GetDepot();
    }
}
