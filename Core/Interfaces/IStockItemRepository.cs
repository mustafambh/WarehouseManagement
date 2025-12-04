using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Core.Interfaces
{
    public interface IStockItemRepository : IGenericRepository<StockItem>
    {
        Task<StockItem?> GetByProductIdAsync(int productId);
        Task<StockItem?> GetWithProductByProductIdAsync(int productId);
    }
}
