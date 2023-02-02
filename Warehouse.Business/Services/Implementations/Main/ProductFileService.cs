using AutoMapper;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;
using Warehouse.Business.Services.Abstractions.Storage;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.UnitOfWorks;

namespace Warehouse.Business.Services.Implementations.Main
{
    public class ProductFileService : IProductFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorage _storage;
        private readonly IMapper _mapper;

        public ProductFileService(IUnitOfWork unitOfWork, IStorage storage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _storage = storage;
            _mapper = mapper;
        }
        public async Task<ServiceResult> AddRangeAsync(AddProductDto productDto, int id)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-product", productDto.Files);
            var product = _unitOfWork.Repository<Product>().Get(x => x.Id == id);
            _unitOfWork.Repository<ProductFile>().AddRange(result.Select(x => new ProductFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Product = product
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> UpdateRangeAsync(AddProductDto productDto, int id)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-product", productDto.Files);

            var product = _unitOfWork.Repository<Product>().Get(x => x.Id == id);
            var entity = await _unitOfWork.Repository<ProductFile>().GetAllAsync(x => x.Product.Id == id);
            _unitOfWork.Repository<ProductFile>().DeleteRange(entity);

            _unitOfWork.Repository<ProductFile>().UpdateRange(result.Select(x => new ProductFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Product = product
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }
    }
}
