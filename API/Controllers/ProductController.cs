using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.DTOs.Products;
using WarehouseManagement.Application.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WarehouseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllAsync()
        {
            var product = await _productService.GetAllAsync();

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetByIdAsync(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateAsync(ProductCreateDto dto)
        {
            var result = await _productService.CreateAsync(dto);

            if(!result.Success)
            {
                if(result.Number == 409)
                {
                    return  Conflict(result.Error);
                }
                else if (result.Number == 404)
                {
                    return NotFound(result.Error);
                }
            }
            return Created($"api/Product/{result.Data!.Id}", result.Data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var Update = await _productService.UpdateAsync(id,dto); 

            if(!Update.Success)
            {
                if (Update.Number == 409)
                {
                    return Conflict(Update.Error);
                }
                else if (Update.Number == 404)
                {
                    return NotFound(Update.Error);
                }
            }

            return Ok(Update.Error);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var Delete = await _productService.DeleteAsync(id);


            if (!Delete.Success)
            {
                if (Delete.Number == 404)
                {
                    return NotFound(Delete.Error);
                }
            }

            return Ok(Delete.Error);
        }
    }
}
