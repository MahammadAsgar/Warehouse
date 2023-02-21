using Microsoft.AspNetCore.Mvc;
using System.Net;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;

namespace Warehouse.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeatureTypeController : ControllerBase
    {
        private readonly IMeatureTypeService _meatureTypeService;
        public MeatureTypeController(IMeatureTypeService meatureTypeService)
        {
            _meatureTypeService = meatureTypeService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddMeatureType([FromForm] AddMeasureTypeDto meatureType)
        {
            return Ok(await _meatureTypeService.AddMeatureType(meatureType));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> UpdateMeatureType([FromForm] AddMeasureTypeDto meatureType, int id)
        {
            return Ok(await _meatureTypeService.UpdateMeatureType(meatureType, id));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> DeleteMeatureType(int id)
        {
            return Ok(await _meatureTypeService.DeleteMeatureType(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetMeatureType(int id)
        {
            return Ok(await _meatureTypeService.GetMeatureType(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetAllMeatureTypes()
        {
            return Ok(await _meatureTypeService.GetAllMeatureTypes());
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetActiveMeatureTypes()
        {
            return Ok(await _meatureTypeService.GetActiveMeatureTypes());
        }
    }
}
