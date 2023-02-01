using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Business.Dtos.Get;
using Warehouse.Business.Dtos.Post;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;
using Warehouse.DataAccess.UnitOfWorks;

namespace Warehouse.Business.Services.Implementations
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

        public Task<ServiceResult> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> GetCategories()
        {
            var request = await _categoryRepository.GetCategories();
            var response = _mapper.Map<IEnumerable<GetCategoryDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetCategory(int id)
        {
            var request = await _categoryRepository.GetCategory(id);
            var response = _mapper.Map<GetCategoryDto>(request);
            return new ServiceResult(true, response);
        }

        public Task<ServiceResult> UpdateCategory(AddCategoryDto category, int id)
        {
            throw new NotImplementedException();
        }
    }
}
