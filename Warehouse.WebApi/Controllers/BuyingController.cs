using Microsoft.AspNetCore.Http;
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
    public class BuyingController : ControllerBase
    {
        private readonly IBuyingService _buyingService;
        private readonly IUserService _userService;
        public BuyingController(IBuyingService buyingService, IUserService userService)
        {
            _buyingService = buyingService;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddBuying([FromForm] AddBuyingDto buyging)
        {
            var user = _userService.GetLoggedUser();
            var result = await _buyingService.AddBuying(buyging,(int)user.Data);
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

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetBuyingByUser()
        {
            var user = _userService.GetLoggedUser();
            var response = await _buyingService.GetBuyingsByUser((int)user.Data);
            return Ok(response);
        }
    }
}
