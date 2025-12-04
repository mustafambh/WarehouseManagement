using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.DTOs.StockTransactions;
using WarehouseManagement.Application.Services.Interfaces;

namespace WarehouseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTransactionController : ControllerBase
    {
        private readonly IStockTransactionServices _stockTransactionServices;

        public StockTransactionController(IStockTransactionServices stockTransactionServices)
        {
            _stockTransactionServices = stockTransactionServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockTransactionDto>>> GetAllAsync()
        {
            var result = await _stockTransactionServices.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockTransactionDto>> GetByIdAsync(int id)
        {
            var result = await _stockTransactionServices.GetByIdAsync(id);

            if (result == null)
                return NotFound($"StockTransaction with id {id} not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<StockTransactionDto>> CreateAsync(StockTransactionCreateDto dto)
        {
            var result = await _stockTransactionServices.CreateAsync(dto);

            if (!result.Success)
                return StatusCode(result.Number, result.Error);

            return Ok("Stock transaction created successfully");
        }
    }
}
