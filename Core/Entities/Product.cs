using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public string SKU {  get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public StockItem StockItem { get; set; }

        public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();

    }
}
