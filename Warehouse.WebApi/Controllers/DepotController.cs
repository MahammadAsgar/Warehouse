using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;

namespace Warehouse.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepotController : ControllerBase
    {
        private readonly IDepotService _depotService;
        public DepotController(IDepotService depotService)
        {
            _depotService = depotService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetDepot()
        {
            var result = await _depotService.GetDepot();
            return Ok(result);
        }
    }
}
