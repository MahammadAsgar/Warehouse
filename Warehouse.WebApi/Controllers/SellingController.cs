using Microsoft.AspNetCore.Mvc;
using System.Net;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;

namespace Warehouse.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SellingController : ControllerBase
    {
        private readonly ISellingService _sellingService;
        public SellingController(ISellingService sellingService)
        {
            _sellingService = sellingService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddSelling([FromForm] AddSellingDto selling)
        {
            var result = await _sellingService.AddSelling(selling);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetSelling(int id)
        {
            var result = await _sellingService.GetSelling(id);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetSellings()
        {
            var result = await _sellingService.GetSellings();
            return Ok(result);
        }
    }
}
