using Microsoft.AspNetCore.Mvc;
using System.Net;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;

namespace Warehouse.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddCategory([FromForm] AddCategoryDto category)
        {
            return Ok(await _categoryService.AddCategory(category));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> UpdateCategory([FromForm] AddCategoryDto category, int id)
        {
            return Ok(await _categoryService.UpdateCategory(category, id));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> DeleteCategory(int id)
        {
            return Ok(await _categoryService.DeleteCategory(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetCategory(int id)
        {
            return Ok(await _categoryService.GetCategory(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetActiveCategories()
        {
            return Ok(await _categoryService.GetActiveCategories());
        }
    }
}
