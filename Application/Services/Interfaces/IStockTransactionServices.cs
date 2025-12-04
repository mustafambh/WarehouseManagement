using WarehouseManagement.Application.Common;
using WarehouseManagement.Application.DTOs.Products;
using WarehouseManagement.Application.DTOs.StockTransactions;

namespace WarehouseManagement.Application.Services.Interfaces
{
    public interface IStockTransactionServices
    {
        Task<IEnumerable<StockTransactionDto>> GetAllAsync();
        Task<StockTransactionDto> GetByIdAsync(int id);
        Task<ServiceResult<StockTransactionDto>> CreateAsync(StockTransactionCreateDto dto);
    }
}
