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
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly IPartnerRepository _partnerRepository;
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper, ICompanyRepository companyRepository, IPartnerRepository partnerRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _companyRepository = companyRepository;
            _partnerRepository = partnerRepository;
        }

        public async Task<ServiceResult> AddCompany(AddCompanyDto companyDto, int userId)
        {
            var company = _mapper.Map<Company>(companyDto);
            company.IsActive = true;
            company.ApplicationUserId = userId;
            if (companyDto.PartnerIds != null)
            {
                company.Partners = (await _unitOfWork.Repository<Partner>().GetAllAsync(x => companyDto.PartnerIds.Contains(x.Id))).ToList();
            }
            await _unitOfWork.Repository<Company>().AddAsync(company);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetCompanyDto>(company);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> GetCompanies()
        {
            var companies = await _companyRepository.GetCompanies();
            var response = _mapper.Map<IEnumerable<GetCompanyDto>>(companies);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetCompany(int id)
        {
            var company = await _companyRepository.GetCompany(id);
            var response = _mapper.Map<GetCompanyDto>(company);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetCompanyByUser(int userId)
        {
            var company = await _companyRepository.GetCompanyByUser(userId);
            var response = _mapper.Map<GetCompanyDto>(company);
            return new ServiceResult(true, response);
        }
    }
}
