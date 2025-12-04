using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Application.DTOs.StockItems;
using WarehouseManagement.Application.Services.Interfaces;

namespace WarehouseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockItemController : ControllerBase
    {
        private readonly IStockItemService _stockItemService;

        public StockItemController(IStockItemService stockItemService)
        {
            _stockItemService = stockItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockItemDto>>> GetAllAsync()
        {
            var stockitem = await _stockItemService.GetAllAsync();

            return Ok(stockitem);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockItemDto>> GetByIdAsync(int id)
        {
            var stockitem = await _stockItemService.GetByProductIdAsync(id);

            return Ok(stockitem);
        }
    }
}
