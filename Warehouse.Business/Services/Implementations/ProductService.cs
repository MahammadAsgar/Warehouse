using AutoMapper;
using Warehouse.Business.Dtos.Get;
using Warehouse.Business.Dtos.Post;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;
using Warehouse.DataAccess.UnitOfWorks;

namespace Warehouse.Business.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<ServiceResult> AddProduct(AddProductDto product)
        {
            var request = _mapper.Map<Product>(product);
            request.IsActive = true;
            await _unitOfWork.Repository<Product>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetProductDto>(request);
            return new ServiceResult(true, response.Id);
        }

        public Task<ServiceResult> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> GetProduct(int id)
        {
            var request = await _productRepository.GetProduct(id);
            var response = _mapper.Map<GetProductDto>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetProductByCategory(int categoryId)
        {
            var request = await _productRepository.GetProductsByCategory(categoryId);
            var response = _mapper.Map<IEnumerable<GetProductDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetProductByMeature(int meatureId)
        {
            var request = await _productRepository.GetProductsByMeatureType(meatureId);
            var response = _mapper.Map<IEnumerable<GetProductDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetProducts()
        {
            var request = await _productRepository.GetProducts();
            var response = _mapper.Map<IEnumerable<GetProductDto>>(request);
            return new ServiceResult(true, response);
        }

        public Task<ServiceResult> UpdateProduct(AddProductDto product, int id)
        {
            throw new NotImplementedException();
        }
    }
}
