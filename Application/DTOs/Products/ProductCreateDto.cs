using System.ComponentModel.DataAnnotations;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Application.DTOs.Products
{
    public class ProductCreateDto
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}
