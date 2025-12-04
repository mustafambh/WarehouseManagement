using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Core.Entities;
using WarehouseManagement.Core.Interfaces;
using WarehouseManagement.Infrastructure.Data;

namespace WarehouseManagement.Infrastructure.Repositories
{
    public class StockItemRepository : GenericRepository<StockItem>, IStockItemRepository
    {
        private readonly AppDbContext _context;

        public StockItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<StockItem>> GetAllAsync()
        {
            return await _context.StockItems
                .Include(x => x.Product)
                .ToListAsync();
        }

        public async Task<StockItem?> GetByProductIdAsync(int productId)
        {
            return await _context.StockItems
                .FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task<StockItem?> GetWithProductByProductIdAsync(int productId)
        {
            return await _context.StockItems
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.ProductId == productId);
        }

    }
}



