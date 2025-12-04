using System.ComponentModel.DataAnnotations;
using WarehouseManagement.Application.DTOs.Categories;
using WarehouseManagement.Application.DTOs.StockTransactions;

namespace WarehouseManagement.Application.DTOs.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }

        public static implicit operator ProductDto(StockTransactionDto v)
        {
            throw new NotImplementedException();
        }
    }
}
