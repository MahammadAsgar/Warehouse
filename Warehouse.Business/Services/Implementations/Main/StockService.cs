using AutoMapper;
using Warehouse.Business.Dtos.Get.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;

namespace Warehouse.Business.Services.Implementations.Main
{
    public class StockService : IStockService
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        public StockService(IMapper mapper, IStockRepository stockRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        public async Task<ServiceResult> GetStock(int id)
        {
            var stock = await _stockRepository.GetStock(id);
            var response = _mapper.Map<GetStockDto>(stock);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetStocks()
        {
            var stock = await _stockRepository.GetActiveStocks();
            var response = _mapper.Map<IEnumerable<GetStockDto>>(stock);
            return new ServiceResult(true, response);
        }
    }
}
