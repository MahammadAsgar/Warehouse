using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;

namespace Warehouse.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuyingController : ControllerBase
    {
        private readonly IBuyingService _buyingService;
        public BuyingController(IBuyingService buyingService)
        {
            _buyingService = buyingService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddBuying([FromForm] AddBuyingDto buyging)
        {
            var result = await _buyingService.AddBuying(buyging);
            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetBuying(int id)
        {
            var result = await _buyingService.GetBuying(id);
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetActiveBuyings()
        {
            var result = await _buyingService.GetBuyings();
            return Ok(result);
        }
    }
}
