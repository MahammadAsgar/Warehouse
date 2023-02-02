using AutoMapper;
using Warehouse.Business.Dtos.Get.Main;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Models;
using Warehouse.DataAccess.Repositories.Abstractions.Main;
using Warehouse.DataAccess.UnitOfWorks;

namespace Warehouse.Business.Services.Implementations.Main
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

        public async Task<ServiceResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product != null)
            {
                product.IsActive = false;
                _unitOfWork.Repository<Product>().Update(product);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
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

        public async Task<ServiceResult> GetAllProducts()
        {
            var request = await _productRepository.GetAllProducts();
            var response = _mapper.Map<IEnumerable<GetProductDto>>(request);
            return new ServiceResult(true, response);
        }
        public async Task<ServiceResult> GetActiveProducts()
        {
            var request = await _productRepository.GetActiveProducts();
            var response = _mapper.Map<IEnumerable<GetProductDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> UpdateProduct(AddProductDto product, int id)
        {
            var result = await _productRepository.GetProduct(id);
            if (result != null)
            {
                if (!string.IsNullOrEmpty(product.Name))
                {
                    result.Name = product.Name;
                }

                if (!string.IsNullOrEmpty(product.Description))
                {
                    result.Description = product.Description;
                }

                if (product.Width.HasValue)
                {
                    result.Width = product.Width.Value;
                }

                if (product.Height.HasValue)
                {
                    result.Height = product.Height.Value;
                }

                if (product.Lenght.HasValue)
                {
                    result.Lenght = product.Lenght.Value;
                }
                if (product.Volume.HasValue)
                {
                    result.Volume = product.Volume.Value;
                }
                if (product.Weight.HasValue)
                {
                    result.Weight = product.Weight.Value;
                }
                if (product.CategoryId.HasValue)
                {
                    result.CategoryId = product.CategoryId.Value;
                }
                if (product.MeatureTypeId.HasValue)
                {
                    result.MeatureTypeId = product.MeatureTypeId.Value;
                }
                if (product.UnitOfMeasure.HasValue)
                {
                    result.UnitOfMeasure = product.UnitOfMeasure.Value;
                }
                _unitOfWork.Repository<Product>().Update(result);
                _unitOfWork.Commit();
                var response = _mapper.Map<Product>(result);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> SearchProduct(int currentPage, int pageSize, string sortField, ProductSearchModelDto documentSearchModel)
        {
            if (pageSize > 100)
                pageSize = 100;

            var product = _mapper.Map<ProductSeachModel>(documentSearchModel);
            var query = _productRepository.SearcProduct(product, sortField);

            var page = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            SearchResult<IEnumerable<GetProductDto>> response = new SearchResult<IEnumerable<GetProductDto>>()
            {
                Value = _mapper.Map<IEnumerable<GetProductDto>>(page.Select(p => p)),
                DataCount = query.Count(),
                CurrentPage = currentPage,
                PageSize = pageSize
            };

            return new ServiceResult(true, response);
        }
    }
}
