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
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<ServiceResult> AddCategory(AddCategoryDto category)
        {
            var request = _mapper.Map<Category>(category);
            request.IsActive = true;
            await _unitOfWork.Repository<Category>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetCategoryDto>(request);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> DeleteCategory(int id)
        {
            var result = await _categoryRepository.GetCategory(id);
            if (result != null)
            {
                result.IsActive = false;
                _unitOfWork.Repository<Category>().Update(result);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetAllCategories()
        {
            var request = await _categoryRepository.GetAllCategories();
            var response = _mapper.Map<IEnumerable<GetCategoryDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetActiveCategories()
        {
            var request = await _categoryRepository.GetActiveCategories();
            var response = _mapper.Map<IEnumerable<GetCategoryDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetCategory(int id)
        {
            var request = await _categoryRepository.GetCategory(id);
            var response = _mapper.Map<GetCategoryDto>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> UpdateCategory(AddCategoryDto category, int id)
        {
            var result = await _categoryRepository.GetCategory(id);
            if (result != null)
            {
                if (!string.IsNullOrEmpty(category.Name))
                {
                    result.Name = category.Name;
                }

                if (!string.IsNullOrEmpty(category.Description))
                {
                    result.Description = category.Description;
                }

                _unitOfWork.Repository<Category>().Update(result);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }
    }
}
