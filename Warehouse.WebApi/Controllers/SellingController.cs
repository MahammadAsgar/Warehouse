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
    public class SellingController : ControllerBase
    {
        private readonly ISellingService _sellingService;
        private readonly IUserService _userService;
        public SellingController(ISellingService sellingService, IUserService userService)
        {
            _sellingService = sellingService;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddSelling([FromForm] AddSellingDto selling)
        {
            var user = _userService.GetLoggedUser();
            var result = await _sellingService.AddSelling(selling, (int)user.Data);
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

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetSellingByUser()
        {
            var user = _userService.GetLoggedUser();
            var response = await _sellingService.GetSellingByUser((int)user.Data);
            return Ok(response);
        }
    }
}
