using AutoMapper;
using Warehouse.Business.Dtos.Get.Main;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;
using Warehouse.DataAccess.Repositories.Implementations.Main;
using Warehouse.DataAccess.UnitOfWorks;

namespace Warehouse.Business.Services.Implementations.Main
{
    public class MeatureTypeService : IMeatureTypeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMeatureTypeRepository _meatureTypeRepository;
        public MeatureTypeService(IMapper mapper, IUnitOfWork unitOfWork, IMeatureTypeRepository meatureTypeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _meatureTypeRepository = meatureTypeRepository;
        }

        public async Task<ServiceResult> AddMeatureType(AddMeatureTypeDto meatureType)
        {
            var request = _mapper.Map<MeatureType>(meatureType);
            request.IsActive = true;
            await _unitOfWork.Repository<MeatureType>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetMeatureTypeDto>(request);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> DeleteMeatureType(int id)
        {
            var result = await _meatureTypeRepository.GetMeatureType(id);
            if (result != null)
            {
                result.IsActive = false;
                _unitOfWork.Repository<MeatureType>().Update(result);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetMeatureType(int id)
        {
            var request = await _meatureTypeRepository.GetMeatureType(id);
            var response = _mapper.Map<GetMeatureTypeDto>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetAllMeatureTypes()
        {
            var request = await _meatureTypeRepository.GetAllMeatureTypes();
            var response = _mapper.Map<List<GetMeatureTypeDto>>(request);
            return new ServiceResult(true, response);
        }
        public async Task<ServiceResult> GetActiveMeatureTypes()
        {
            var request = await _meatureTypeRepository.GetActiveMeatureTypes();
            var response = _mapper.Map<List<GetMeatureTypeDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> UpdateMeatureType(AddMeatureTypeDto meatureType, int id)
        {
            var result = await _meatureTypeRepository.GetMeatureType(id);
            if (result != null)
            {
                if (!string.IsNullOrEmpty(meatureType.Name))
                {
                    result.Name = meatureType.Name;
                }

                if (!string.IsNullOrEmpty(meatureType.Description))
                {
                    result.Description = meatureType.Description;
                }

                _unitOfWork.Repository<MeatureType>().Update(result);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }
    }
}
