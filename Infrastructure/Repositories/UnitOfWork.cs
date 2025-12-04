using WarehouseManagement.Core.Interfaces;
using WarehouseManagement.Infrastructure.Data;
using WarehouseManagement.Infrastructure.Repositories;

namespace WarehouseManagement.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public ISupplierRepository Suppliers { get; }
        public IStockItemRepository StockItems { get; }
        public IStockTransactionRepository StockTransactions { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context);
            Suppliers = new SupplierRepository(_context);
            StockItems = new StockItemRepository(_context);
            StockTransactions = new StockTransactionRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
