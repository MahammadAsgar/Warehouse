using AutoMapper;
using Warehouse.Business.Dtos.Get.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;

namespace Warehouse.Business.Services.Implementations.Main
{
    public class DepotService : IDepotService
    {
        private readonly IMapper _mapper;
        private readonly IDepotRepository _depotRepository;
        public DepotService(IMapper mapper, IDepotRepository depotRepository)
        {
            _mapper = mapper;
            _depotRepository = depotRepository;
        }

        public async Task<ServiceResult> GetDepot()
        {
            var depot = await _depotRepository.GetCurrentDepot();
            var response = _mapper.Map<GetDepotDto>(depot);
            return new ServiceResult(true, response);
        }
    }
}
