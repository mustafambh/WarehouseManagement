using System.ComponentModel.DataAnnotations;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Application.DTOs.StockTransactions
{
    public class StockTransactionDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } // IN or OUT
        public DateTime CreatedAt { get; set; }
    }
}
