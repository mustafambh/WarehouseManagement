using WarehouseManagement.Application.DTOs.StockItems;

namespace WarehouseManagement.Application.Services.Interfaces
{
    public interface IStockItemService
    {
        Task<IEnumerable<StockItemDto>> GetAllAsync();
        Task<StockItemDto> GetByProductIdAsync(int id);
    }
}
