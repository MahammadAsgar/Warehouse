using Microsoft.AspNetCore.Mvc;
using System.Net;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;

namespace Warehouse.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetStock(int id)
        {
            var result = await _stockService.GetStock(id);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetStocks()
        {
            var result = await _stockService.GetStocks();
            return Ok(result);
        }
    }
}
