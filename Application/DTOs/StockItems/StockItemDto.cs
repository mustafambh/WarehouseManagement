using System.ComponentModel.DataAnnotations;
using WarehouseManagement.Application.DTOs.StockItems;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Application.DTOs.StockItems
{
    public class StockItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; } 
    }
}