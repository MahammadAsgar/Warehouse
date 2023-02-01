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

        public Task<ServiceResult> DeleteMeatureType(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> GetMeatureType(int id)
        {
            var request = await _meatureTypeRepository.GetMeatureType(id);
            var response = _mapper.Map<IEnumerable<GetMeatureTypeDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetMeatureTypes()
        {
            var request = await _meatureTypeRepository.GetMeatureTypes();
            var response = _mapper.Map<GetMeatureTypeDto>(request);
            return new ServiceResult(true, response);
        }

        public Task<ServiceResult> UpdateMeatureType(AddMeatureTypeDto meatureType, int id)
        {
            throw new NotImplementedException();
        }
    }
}
