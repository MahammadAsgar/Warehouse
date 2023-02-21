using AutoMapper;
using Warehouse.Business.Dtos.Get.Main;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;
using Warehouse.DataAccess.UnitOfWorks;

namespace Warehouse.Business.Services.Implementations.Main
{
    public class SellingService : ISellingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISellingRepository _sellingRepository;
        private readonly IDepotRepository _depotRepository;
        private readonly IStockRepository _stockRepository;
        public SellingService(IMapper mapper, IUnitOfWork unitOfWork, ISellingRepository sellingRepository, IDepotRepository depotRepository, IStockRepository stockRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sellingRepository = sellingRepository;
            _depotRepository = depotRepository;
            _stockRepository = stockRepository;
        }
        public async Task<ServiceResult> AddSelling(AddSellingDto sellingDto, int userId)
        {
            var request = _mapper.Map<Selling>(sellingDto);
            request.IsActive = true;
            request.SellingDate = DateTime.Now;
            //   request.Price = sellingDto.Price * sellingDto.UnitOfMeasure;
            request.ApplicationUserId = userId;
            var stock = await _stockRepository.GetStockByProduct(sellingDto.ProductId);

            await _unitOfWork.Repository<Selling>().AddAsync(request);
            if (stock != null)
            {
                stock.UnitOfMeasure -= sellingDto.UnitOfMeasure;
                _unitOfWork.Repository<Stock>().Update(stock);

                if (stock.UnitOfMeasure == sellingDto.UnitOfMeasure)
                {
                    stock.IsActive = false;

                    _unitOfWork.Repository<Stock>().Update(stock);
                }
                _unitOfWork.Commit();
                var response = _mapper.Map<GetSellingDto>(request);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);

        }

        public async Task<ServiceResult> GetSelling(int id)
        {
            var request = await _sellingRepository.GetSelling(id);
            var response = _mapper.Map<GetSellingDto>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetSellingByUser(int userId)
        {
            var request = await _sellingRepository.GetSellingsByUser(userId);
            var response = _mapper.Map<List<GetSellingDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetSellings()
        {
            var request = await _sellingRepository.GetActiveSellings();
            var response = _mapper.Map<List<GetSellingDto>>(request);
            return new ServiceResult(true, response);
        }
    }
}
