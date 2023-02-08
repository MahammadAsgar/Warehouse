using AutoMapper;
using Microsoft.VisualBasic;
using Warehouse.Business.Dtos.Get.Main;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;
using Warehouse.DataAccess.UnitOfWorks;

namespace Warehouse.Business.Services.Implementations.Main
{
    public class BuyingService : IBuyingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBuyingRepository _buyingRepository;
        private readonly IDepotRepository _depotRepository;
        private readonly IStockRepository _stockRepository;
        public BuyingService(IMapper mapper, IUnitOfWork unitOfWork, IBuyingRepository buyingRepository, IDepotRepository depotRepository, IStockRepository stockRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _buyingRepository = buyingRepository;
            _depotRepository = depotRepository;
            _stockRepository = stockRepository;
        }

        public async Task<ServiceResult> AddBuying(AddBuyingDto buyingDto, int userId)
        {
            var request = _mapper.Map<Buying>(buyingDto);
            request.IsActive = true;
            request.BuyingDate = DateTime.Now;
            request.Price = buyingDto.Price * buyingDto.UnitOfMeasure;
            request.ApplicationUserId=userId;
            var stock = await _stockRepository.GetStockByProduct(buyingDto.ProductId);
            var depot = await _depotRepository.GetCurrentDepot();
            await _unitOfWork.Repository<Buying>().AddAsync(request);
            if (stock != null)
            {
                stock.UnitOfMeasure += buyingDto.UnitOfMeasure;
                _unitOfWork.Repository<Stock>().Update(stock);
            }

            else
            {                
                stock = new Stock();
                stock.IsActive = true;
                stock.ProductId = buyingDto.ProductId;
                stock.UnitOfMeasure = buyingDto.UnitOfMeasure;
                stock.MeasureTypeId = buyingDto.MeasureTypeId;
                await _unitOfWork.Repository<Stock>().AddAsync(stock);
                if (depot == null)
                {
                    depot=new Depot();
                    var stocks = new List<Stock>();
                    stocks.Add(stock);
                    depot.Stocks = stocks;
                    await _unitOfWork.Repository<Depot>().AddAsync(depot);
                }
                else
                {
                    depot.Stocks.Add(stock);
                    _unitOfWork.Repository<Depot>().Update(depot);
                }
            }
            _unitOfWork.Commit();

            var response = _mapper.Map<GetBuyingDto>(request);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> GetBuying(int id)
        {
            var request = await _buyingRepository.GetBuying(id);
            var response = _mapper.Map<GetBuyingDto>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetBuyings()
        {
            var request = await _buyingRepository.GetActiveBuyings();
            var response = _mapper.Map<List<GetBuyingDto>>(request);
            return new ServiceResult(true, response);
        }  
        
        public async Task<ServiceResult> GetBuyingsByUser(int userId)
        {
            var request = await _buyingRepository.GetBuyingsByUser(userId);
            var response = _mapper.Map<List<GetBuyingDto>>(request);
            return new ServiceResult(true, response);
        }
    }
}
