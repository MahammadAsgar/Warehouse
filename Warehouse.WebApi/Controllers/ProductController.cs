using Microsoft.AspNetCore.Mvc;
using System.Net;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.Main;

namespace Warehouse.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductFileService _productFileService;
        public ProductController(IProductService productService, IProductFileService productFileService)
        {
            _productService = productService;
            _productFileService = productFileService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> AddProduct([FromForm] AddProductDto product)
        {
            var result = await _productService.AddProduct(product);
            if (result.Success)
            {
                product.Files = Request.Form.Files;
                await _productFileService.AddRangeAsync(product, (int)result.Data);
            }
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> UpdateProduct([FromForm] AddProductDto product, int id)
        {
            var result = await _productService.UpdateProduct(product, id);
            if (result.Success)
            {
                product.Files = Request.Form.Files;
                await _productFileService.UpdateRangeAsync(product, (int)result.Data);
            }
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> DeleteProduct(int id)
        {
            return Ok(await _productService.DeleteProduct(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetProduct(int id)
        {
            return Ok(await _productService.GetProduct(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetActiveProducts()
        {
            return Ok(await _productService.GetActiveProducts());
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetProductsByCategory(int categoryId)
        {
            return Ok(await _productService.GetProductByCategory(categoryId));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> GetProductsByMeature(int meatureId)
        {
            return Ok(await _productService.GetProductByMeature(meatureId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> SearchProduct( [FromForm] ProductSearchModelDto documentSearchModel, int currentPage = 1, int pageSize = 10)
        {
            var result = await _productService.SearchProduct(currentPage, pageSize,  documentSearchModel);
            return Ok(result);
        }
    }
}
