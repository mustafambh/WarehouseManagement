using System.ComponentModel.DataAnnotations;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Application.DTOs.StockTransactions
{
    public class StockTransactionCreateDto
    {
        [Required]
        public int ProductId { get; set; }
        public int? SupplierId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string TransactionType { get; set; } // IN or OUT
    }
}
