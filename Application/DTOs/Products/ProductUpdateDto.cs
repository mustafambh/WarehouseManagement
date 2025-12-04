using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Application.DTOs.Products
{
    public class ProductUpdateDto
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
