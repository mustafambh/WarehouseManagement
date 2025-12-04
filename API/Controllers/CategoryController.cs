using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.DTOs.Categories;
using WarehouseManagement.Application.Services.Interfaces;

namespace WarehouseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetByIdAsync(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateAsync(CategoryCreateDTO dto)
        {
            var category = await _categoryService.CreateAsync(dto);

            if (category == null) return Conflict("Category with this name already exists");

            return Created($"api/Category/{category.Id}", category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, CategoryUpdateDTO dto)
        {
            var updated = await _categoryService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound($"Category with id {id} not found");

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var delete = await _categoryService.DeleteAsync(id);

            if (!delete)
                return NotFound($"Category with id {id} not found");

            return NoContent();
        }
    }
}
