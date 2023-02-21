using Microsoft.AspNetCore.Mvc;
using System.Net;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;
using Warehouse.Business.Services.Abstractions.User;

namespace Warehouse.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        public CompanyController(ICompanyService companyService, IUserService userService)
        {
            _companyService = companyService;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddCompany([FromForm] AddCompanyDto company)
        {
            var user = _userService.GetLoggedUser().Data;
            var result = await _companyService.AddCompany(company, (int)user);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetCompany(int id)
        {
            return Ok(await _companyService.GetCompany(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetCompanies()
        {
            return Ok(await _companyService.GetCompanies());
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetCompaniesByUser()
        {
            var user = _userService.GetLoggedUser().Data;
            return Ok(await _companyService.GetCompanyByUser((int)user));
        }
    }
}
