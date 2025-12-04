using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Core.Entities
{
    public class StockItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
