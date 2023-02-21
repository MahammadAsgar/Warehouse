

using Microsoft.AspNetCore.Mvc;
using System.Net;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;
using Warehouse.Business.Services.Implementations.Main;
using Warehouse.Infrasturucture.Extensions;

namespace Warehouse.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;
        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddPartner([FromForm] AddPartnerDto partner)
        {
            var result = await _partnerService.AddPartner(partner);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetPartner(int id)
        {
            var result = await _partnerService.GetPartner(id);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetPartners()
        {
            var result = await _partnerService.GetPartners();
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetPartnersByCompany(int companyId)
        {
            var result = await _partnerService.GetPartnersByCompany(companyId);
            return Ok(result);
        }

    }
}
