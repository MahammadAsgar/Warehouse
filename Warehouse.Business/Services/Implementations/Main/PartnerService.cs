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
    public class PartnerService : IPartnerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPartnerRepository _partnerRepository;
        public PartnerService(IMapper mapper, IUnitOfWork unitOfWork, IPartnerRepository partnerRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _partnerRepository = partnerRepository;
        }

        public async Task<ServiceResult> AddPartner(AddPartnerDto partnerDto)
        {
            var partner = _mapper.Map<Partner>(partnerDto);
            partner.IsActive = true;
            await _unitOfWork.Repository<Partner>().AddAsync(partner);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetPartnerDto>(partner);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> GetPartner(int id)
        {
            var partner = await _partnerRepository.GetPartner(id);
            var response = _mapper.Map<GetPartnerDto>(partner);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetPartners()
        {
            var partners = await _partnerRepository.GetPartners();
            var response = _mapper.Map<IEnumerable<GetPartnerDto>>(partners);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetPartnersByCompany(int companyId)
        {
            var partners = await _partnerRepository.GetPartnersByCompany(companyId);
            var response = _mapper.Map<IEnumerable<GetPartnerDto>>(partners);
            return new ServiceResult(true, response);
        }
    }
}
