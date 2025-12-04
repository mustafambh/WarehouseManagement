using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.DTOs.Suppliers;
using WarehouseManagement.Application.Services.Interfaces;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetAllAsync()
        {
            var supplier = await _supplierService.GetAllAsync();

            return Ok(supplier);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetByIdAsync(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);

            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDto>> CreateAsync(SupplierCreateDto dto)
        {
            var supplier = await _supplierService.CreateAsync(dto);

            return Created($"api/Supplier/{supplier.Id}", supplier);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(int id, SupplierUpdateDto dto)
        {
            var supplier = await _supplierService.UpdateAsync(id, dto);

            if (supplier.Success)
            {
                return NotFound(supplier.Error);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var supplier = await _supplierService.DeleteAsync(id);

            if (supplier.Success)
            {
                return NotFound(supplier.Error);
            }

            return Ok();
        }
    }
}
