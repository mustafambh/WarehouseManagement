namespace WarehouseManagement.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public ISupplierRepository Suppliers { get; }
        public IStockItemRepository StockItems { get; }
        public IStockTransactionRepository StockTransactions { get; }

        Task<int> SaveChangesAsync();
    }
}
